using BilliardShop.Application.Interfaces;
using BilliardShop.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilliardShop.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductController> _logger;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _productService = productService;
        _logger = logger;
    }

    public async Task<IActionResult> Index(string? categorySlug, int page = 1)
    {
        if (string.IsNullOrEmpty(categorySlug))
        {
            // Show all products or redirect to a default category
            categorySlug = "all";
        }

        var viewModel = new ProductListViewModel
        {
            CurrentPage = page,
            PageSize = 12
        };

        // Get category info if specified
        if (categorySlug != "all")
        {
            viewModel.CurrentCategory = await _productService.GetCategoryBySlugAsync(categorySlug);
            if (viewModel.CurrentCategory == null)
            {
                return NotFound();
            }

            viewModel.Products = await _productService.GetProductsByCategoryAsync(categorySlug, page, viewModel.PageSize);
            viewModel.TotalProducts = await _productService.GetTotalProductsInCategoryAsync(categorySlug);
        }

        viewModel.AllCategories = await _productService.GetAllCategoriesAsync();

        return View(viewModel);
    }

    public async Task<IActionResult> Details(string slug)
    {
        if (string.IsNullOrEmpty(slug))
        {
            return NotFound();
        }

        var product = await _productService.GetProductBySlugAsync(slug);
        if (product == null)
        {
            return NotFound();
        }

        var viewModel = new ProductDetailViewModel
        {
            Product = product,
            RelatedProducts = await _productService.GetProductsByCategoryAsync(
                product.DanhMuc.DuongDanDanhMuc,
                1,
                4
            )
        };

        // Remove the current product from related products
        viewModel.RelatedProducts = viewModel.RelatedProducts
            .Where(p => p.Id != product.Id)
            .Take(3);

        return View(viewModel);
    }

    public async Task<IActionResult> Search(string q, string? categorySlug, decimal? minPrice, decimal? maxPrice, int page = 1)
    {
        var viewModel = new ProductListViewModel
        {
            CurrentPage = page,
            PageSize = 12,
            SearchTerm = q
        };

        viewModel.Products = await _productService.SearchProductsAsync(q, categorySlug, minPrice, maxPrice, page, viewModel.PageSize);
        viewModel.TotalProducts = await _productService.GetSearchResultsCountAsync(q, categorySlug, minPrice, maxPrice);
        viewModel.AllCategories = await _productService.GetAllCategoriesAsync();

        if (!string.IsNullOrEmpty(categorySlug))
        {
            viewModel.CurrentCategory = await _productService.GetCategoryBySlugAsync(categorySlug);
        }

        return View("Index", viewModel);
    }
}
