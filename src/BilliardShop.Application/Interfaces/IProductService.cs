using BilliardShop.Domain.Entities;

namespace BilliardShop.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<SanPham>> GetFeaturedProductsAsync(int count = 10);
    Task<IEnumerable<SanPham>> GetProductsByCategoryAsync(string categorySlug, int pageNumber = 1, int pageSize = 12);
    Task<SanPham?> GetProductBySlugAsync(string productSlug);
    Task<IEnumerable<DanhMucSanPham>> GetAllCategoriesAsync();
    Task<DanhMucSanPham?> GetCategoryBySlugAsync(string categorySlug);
    Task<int> GetTotalProductsInCategoryAsync(string categorySlug);
    Task<IEnumerable<SanPham>> SearchProductsAsync(string searchTerm, string? categorySlug = null, decimal? minPrice = null, decimal? maxPrice = null, int pageNumber = 1, int pageSize = 12);
    Task<int> GetSearchResultsCountAsync(string searchTerm, string? categorySlug = null, decimal? minPrice = null, decimal? maxPrice = null);
}
