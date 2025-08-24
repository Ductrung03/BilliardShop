using BilliardShop.Domain.Entities;
using BilliardShop.Domain.Interfaces.Repositories;

namespace BilliardShop.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // User Management Repositories
    IVaiTroNguoiDungRepository VaiTroNguoiDungRepository { get; }
    INguoiDungRepository NguoiDungRepository { get; }
    IDiaChiNguoiDungRepository DiaChiNguoiDungRepository { get; }

    // Product Management Repositories - Updated with specific interfaces
    IDanhMucSanPhamRepository DanhMucSanPhamRepository { get; }
    IThuongHieuRepository ThuongHieuRepository { get; }
    ISanPhamRepository SanPhamRepository { get; }
    IHinhAnhSanPhamRepository HinhAnhSanPhamRepository { get; }
    IThuocTinhSanPhamRepository ThuocTinhSanPhamRepository { get; }

    // Inventory Management Repositories
    IGenericRepository<NhaCungCap> NhaCungCapRepository { get; }
    IGenericRepository<BienDongKhoHang> BienDongKhoHangRepository { get; }

    // Order Management Repositories
    IGenericRepository<TrangThaiDonHang> TrangThaiDonHangRepository { get; }
    IGenericRepository<PhuongThucThanhToan> PhuongThucThanhToanRepository { get; }
    IGenericRepository<PhuongThucVanChuyen> PhuongThucVanChuyenRepository { get; }
    IGenericRepository<DonHang> DonHangRepository { get; }
    IGenericRepository<ChiTietDonHang> ChiTietDonHangRepository { get; }

    // Promotions & Discounts Repositories
    IGenericRepository<MaGiamGia> MaGiamGiaRepository { get; }
    IGenericRepository<SuDungMaGiamGia> SuDungMaGiamGiaRepository { get; }

    // Customer Interactions Repositories
    IGenericRepository<DanhGiaSanPham> DanhGiaSanPhamRepository { get; }
    IGenericRepository<DanhSachYeuThich> DanhSachYeuThichRepository { get; }
    IGenericRepository<GioHang> GioHangRepository { get; }

    // System Settings & Blog Repositories
    ICaiDatHeThongRepository CaiDatHeThongRepository { get; }
    IGenericRepository<BaiViet> BaiVietRepository { get; }
    IGenericRepository<BinhLuanBaiViet> BinhLuanBaiVietRepository { get; }
    INhatKyHeThongRepository NhatKyHeThongRepository { get; }

    // Transaction Methods
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    
    // Transaction Management
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}