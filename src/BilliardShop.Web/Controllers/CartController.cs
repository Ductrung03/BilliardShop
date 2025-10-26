using BilliardShop.Application.Interfaces;
using BilliardShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilliardShop.Web.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IProductService _productService;

    public CartController(ICartService cartService, IProductService productService)
    {
        _cartService = cartService;
        _productService = productService;
    }

    private string GetSessionId()
    {
        var sessionId = HttpContext.Session.GetString("CartSessionId");
        if (string.IsNullOrEmpty(sessionId))
        {
            sessionId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("CartSessionId", sessionId);
        }
        return sessionId;
    }

    public async Task<IActionResult> Index()
    {
        // Tạm thời dùng session cho guest user
        var sessionId = GetSessionId();
        var cartItems = await _cartService.GetCartItemsAsync(null, sessionId);

        var viewModel = new CartViewModel();

        foreach (var item in cartItems)
        {
            var product = await _productService.GetProductBySlugAsync(item.SanPham.DuongDanSanPham);
            if (product != null)
            {
                var cartItemVM = new CartItemViewModel
                {
                    GioHangId = item.Id,
                    SanPhamId = item.MaSanPham,
                    TenSanPham = product.TenSanPham,
                    DuongDanSanPham = product.DuongDanSanPham,
                    HinhAnhUrl = product.HinhAnhs.FirstOrDefault()?.DuongDanHinhAnh,
                    Gia = product.GiaGoc,
                    GiaKhuyenMai = product.GiaKhuyenMai,
                    SoLuong = item.SoLuong,
                    SoLuongTonKho = product.SoLuongTonKho
                };
                viewModel.Items.Add(cartItemVM);
            }
        }

        viewModel.SubTotal = viewModel.Items.Sum(i => i.ThanhTien);
        viewModel.ShippingFee = 0; // Tính phí ship sau
        viewModel.Total = viewModel.SubTotal + viewModel.ShippingFee;

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
    {
        var sessionId = GetSessionId();
        var result = await _cartService.AddToCartAsync(null, sessionId, productId, quantity);

        if (result)
        {
            TempData["Success"] = "Đã thêm sản phẩm vào giỏ hàng";
        }
        else
        {
            TempData["Error"] = "Không thể thêm sản phẩm vào giỏ hàng";
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
    {
        if (quantity <= 0)
        {
            return Json(new { success = false, message = "Số lượng không hợp lệ" });
        }

        var result = await _cartService.UpdateQuantityAsync(cartItemId, quantity);

        if (result)
        {
            var sessionId = GetSessionId();
            var total = await _cartService.GetCartTotalAsync(null, sessionId);
            return Json(new { success = true, total });
        }

        return Json(new { success = false, message = "Không thể cập nhật số lượng" });
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int productId)
    {
        var sessionId = GetSessionId();
        var result = await _cartService.RemoveFromCartAsync(null, sessionId, productId);

        if (result)
        {
            TempData["Success"] = "Đã xóa sản phẩm khỏi giỏ hàng";
        }
        else
        {
            TempData["Error"] = "Không thể xóa sản phẩm";
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ClearCart()
    {
        var sessionId = GetSessionId();
        await _cartService.ClearCartAsync(null, sessionId);
        TempData["Success"] = "Đã xóa toàn bộ giỏ hàng";
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> GetCartCount()
    {
        var sessionId = GetSessionId();
        var count = await _cartService.GetCartItemCountAsync(null, sessionId);
        return Json(new { count });
    }
}
