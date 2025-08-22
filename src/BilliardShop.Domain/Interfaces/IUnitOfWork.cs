using BilliardShop.Domain.Entities;

namespace BilliardShop.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // User Management Repositories
    IGenericRepository<VaiTroNguoiDung> VaiTroNguoiDungRepository { get; }
    IGenericRepository<NguoiDung> NguoiDungRepository { get; }
    IGenericRepository<DiaChiNguoiDung> DiaChiNguoiDungRepository { get; }

    // Product Management Repositories
    IGenericRepository<DanhMucSanPham> DanhMucSanPhamRepository { get; }
    IGenericRepository<ThuongHieu> ThuongHieuRepository { get; }
    IGenericRepository<SanPham> SanPhamRepository { get; }
    IGenericRepository<HinhAnhSanPham> HinhAnhSanPhamRepository { get; }
    IGenericRepository<ThuocTinhSanPham> ThuocTinhSanPhamRepository { get; }

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
    IGenericRepository<CaiDatHeThong> CaiDatHeThongRepository { get; }
    IGenericRepository<BaiViet> BaiVietRepository { get; }
    IGenericRepository<BinhLuanBaiViet> BinhLuanBaiVietRepository { get; }
    IGenericRepository<NhatKyHeThong> NhatKyHeThongRepository { get; }

    // Transaction Methods
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
    
    // Transaction Management
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}