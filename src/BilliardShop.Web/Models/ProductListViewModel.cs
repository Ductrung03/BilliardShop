using BilliardShop.Domain.Entities;

namespace BilliardShop.Web.Models;

public class ProductListViewModel
{
    public IEnumerable<SanPham> Products { get; set; } = new List<SanPham>();
    public DanhMucSanPham? CurrentCategory { get; set; }
    public IEnumerable<DanhMucSanPham> AllCategories { get; set; } = new List<DanhMucSanPham>();
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 12;
    public int TotalProducts { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalProducts / PageSize);
    public string? SearchTerm { get; set; }
}
