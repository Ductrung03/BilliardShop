using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BilliardShop.Domain.Entities;
using BilliardShop.Domain.Common;

namespace BilliardShop.Infrastructure.Data;

public class BilliardShopDbContext : DbContext
{
    public BilliardShopDbContext(DbContextOptions<BilliardShopDbContext> options) : base(options)
    {
    }

    // User Management
    public DbSet<VaiTroNguoiDung> VaiTroNguoiDungs { get; set; }
    public DbSet<NguoiDung> NguoiDungs { get; set; }
    public DbSet<DiaChiNguoiDung> DiaChiNguoiDungs { get; set; }

    // Product Management
    public DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }
    public DbSet<ThuongHieu> ThuongHieus { get; set; }
    public DbSet<SanPham> SanPhams { get; set; }
    public DbSet<HinhAnhSanPham> HinhAnhSanPhams { get; set; }
    public DbSet<ThuocTinhSanPham> ThuocTinhSanPhams { get; set; }

    // Inventory Management
    public DbSet<NhaCungCap> NhaCungCaps { get; set; }
    public DbSet<BienDongKhoHang> BienDongKhoHangs { get; set; }

    // Order Management
    public DbSet<TrangThaiDonHang> TrangThaiDonHangs { get; set; }
    public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
    public DbSet<PhuongThucVanChuyen> PhuongThucVanChuyens { get; set; }
    public DbSet<DonHang> DonHangs { get; set; }
    public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    // Promotions & Discounts
    public DbSet<MaGiamGia> MaGiamGias { get; set; }
    public DbSet<SuDungMaGiamGia> SuDungMaGiamGias { get; set; }

    // Customer Interactions
    public DbSet<DanhGiaSanPham> DanhGiaSanPhams { get; set; }
    public DbSet<DanhSachYeuThich> DanhSachYeuThichs { get; set; }
    public DbSet<GioHang> GioHangs { get; set; }

    // System Settings & Blog
    public DbSet<CaiDatHeThong> CaiDatHeThongs { get; set; }
    public DbSet<BaiViet> BaiViets { get; set; }
    public DbSet<BinhLuanBaiViet> BinhLuanBaiViets { get; set; }
    public DbSet<NhatKyHeThong> NhatKyHeThongs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all configurations from assembly
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Configure table names to match SQL Server schema
        ConfigureTableNames(modelBuilder);

        // Configure primary keys to match SQL Server identity columns
        ConfigurePrimaryKeys(modelBuilder);

        // Configure indexes
        ConfigureIndexes(modelBuilder);

        // Configure check constraints
        ConfigureCheckConstraints(modelBuilder);
    }

    private static void ConfigureTableNames(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VaiTroNguoiDung>().ToTable("VaiTroNguoiDung");
        modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
        modelBuilder.Entity<DiaChiNguoiDung>().ToTable("DiaChiNguoiDung");
        modelBuilder.Entity<DanhMucSanPham>().ToTable("DanhMucSanPham");
        modelBuilder.Entity<ThuongHieu>().ToTable("ThuongHieu");
        modelBuilder.Entity<SanPham>().ToTable("SanPham");
        modelBuilder.Entity<HinhAnhSanPham>().ToTable("HinhAnhSanPham");
        modelBuilder.Entity<ThuocTinhSanPham>().ToTable("ThuocTinhSanPham");
        modelBuilder.Entity<NhaCungCap>().ToTable("NhaCungCap");
        modelBuilder.Entity<BienDongKhoHang>().ToTable("BienDongKhoHang");
        modelBuilder.Entity<TrangThaiDonHang>().ToTable("TrangThaiDonHang");
        modelBuilder.Entity<PhuongThucThanhToan>().ToTable("PhuongThucThanhToan");
        modelBuilder.Entity<PhuongThucVanChuyen>().ToTable("PhuongThucVanChuyen");
        modelBuilder.Entity<DonHang>().ToTable("DonHang");
        modelBuilder.Entity<ChiTietDonHang>().ToTable("ChiTietDonHang");
        modelBuilder.Entity<MaGiamGia>().ToTable("MaGiamGia");
        modelBuilder.Entity<SuDungMaGiamGia>().ToTable("SuDungMaGiamGia");
        modelBuilder.Entity<DanhGiaSanPham>().ToTable("DanhGiaSanPham");
        modelBuilder.Entity<DanhSachYeuThich>().ToTable("DanhSachYeuThich");
        modelBuilder.Entity<GioHang>().ToTable("GioHang");
        modelBuilder.Entity<CaiDatHeThong>().ToTable("CaiDatHeThong");
        modelBuilder.Entity<BaiViet>().ToTable("BaiViet");
        modelBuilder.Entity<BinhLuanBaiViet>().ToTable("BinhLuanBaiViet");
        modelBuilder.Entity<NhatKyHeThong>().ToTable("NhatKyHeThong");
    }

    private static void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
    {
        // Configure primary key column names to match SQL Server schema
        modelBuilder.Entity<VaiTroNguoiDung>().Property(e => e.Id).HasColumnName("MaVaiTro");
        modelBuilder.Entity<NguoiDung>().Property(e => e.Id).HasColumnName("MaNguoiDung");
        modelBuilder.Entity<DiaChiNguoiDung>().Property(e => e.Id).HasColumnName("MaDiaChi");
        modelBuilder.Entity<DanhMucSanPham>().Property(e => e.Id).HasColumnName("MaDanhMuc");
        modelBuilder.Entity<ThuongHieu>().Property(e => e.Id).HasColumnName("MaThuongHieu");
        modelBuilder.Entity<SanPham>().Property(e => e.Id).HasColumnName("MaSanPham");
        modelBuilder.Entity<HinhAnhSanPham>().Property(e => e.Id).HasColumnName("MaHinhAnh");
        modelBuilder.Entity<ThuocTinhSanPham>().Property(e => e.Id).HasColumnName("MaThuocTinh");
        modelBuilder.Entity<NhaCungCap>().Property(e => e.Id).HasColumnName("MaNhaCungCap");
        modelBuilder.Entity<BienDongKhoHang>().Property(e => e.Id).HasColumnName("MaBienDong");
        modelBuilder.Entity<TrangThaiDonHang>().Property(e => e.Id).HasColumnName("MaTrangThai");
        modelBuilder.Entity<PhuongThucThanhToan>().Property(e => e.Id).HasColumnName("MaPhuongThucThanhToan");
        modelBuilder.Entity<PhuongThucVanChuyen>().Property(e => e.Id).HasColumnName("MaPhuongThucVanChuyen");
        modelBuilder.Entity<DonHang>().Property(e => e.Id).HasColumnName("MaDonHang");
        modelBuilder.Entity<ChiTietDonHang>().Property(e => e.Id).HasColumnName("MaChiTietDonHang");
        modelBuilder.Entity<MaGiamGia>().Property(e => e.Id).HasColumnName("MaMaGiamGia");
        modelBuilder.Entity<SuDungMaGiamGia>().Property(e => e.Id).HasColumnName("MaSuDung");
        modelBuilder.Entity<DanhGiaSanPham>().Property(e => e.Id).HasColumnName("MaDanhGia");
        modelBuilder.Entity<DanhSachYeuThich>().Property(e => e.Id).HasColumnName("MaYeuThich");
        modelBuilder.Entity<GioHang>().Property(e => e.Id).HasColumnName("MaGioHang");
        modelBuilder.Entity<CaiDatHeThong>().Property(e => e.Id).HasColumnName("MaCaiDat");
        modelBuilder.Entity<BaiViet>().Property(e => e.Id).HasColumnName("MaBaiViet");
        modelBuilder.Entity<BinhLuanBaiViet>().Property(e => e.Id).HasColumnName("MaBinhLuan");
        modelBuilder.Entity<NhatKyHeThong>().Property(e => e.Id).HasColumnName("MaNhatKy");
    }

    private static void ConfigureIndexes(ModelBuilder modelBuilder)
    {
        // User indexes
        modelBuilder.Entity<NguoiDung>()
            .HasIndex(e => e.Email)
            .HasDatabaseName("IX_NguoiDung_Email");

        modelBuilder.Entity<NguoiDung>()
            .HasIndex(e => e.TenDangNhap)
            .HasDatabaseName("IX_NguoiDung_TenDangNhap");

        // Product indexes
        modelBuilder.Entity<SanPham>()
            .HasIndex(e => e.MaCodeSanPham)
            .HasDatabaseName("IX_SanPham_MaCodeSanPham");

        modelBuilder.Entity<SanPham>()
            .HasIndex(e => e.DuongDanSanPham)
            .HasDatabaseName("IX_SanPham_DuongDanSanPham");

        // Order indexes
        modelBuilder.Entity<DonHang>()
            .HasIndex(e => e.SoDonHang)
            .HasDatabaseName("IX_DonHang_SoDonHang");

        // Unique constraints
        modelBuilder.Entity<DanhSachYeuThich>()
            .HasIndex(e => new { e.MaNguoiDung, e.MaSanPham })
            .IsUnique()
            .HasDatabaseName("UK_DanhSachYeuThich_NguoiDung_SanPham");
    }

    private static void ConfigureCheckConstraints(ModelBuilder modelBuilder)
    {
        // Gender check constraint
        modelBuilder.Entity<NguoiDung>()
            .HasCheckConstraint("CK_NguoiDung_GioiTinh", "[GioiTinh] IN ('M', 'F', 'K')");

        // Address type check constraint
        modelBuilder.Entity<DiaChiNguoiDung>()
            .HasCheckConstraint("CK_DiaChiNguoiDung_LoaiDiaChi", "[LoaiDiaChi] IN ('GiaoHang', 'ThanhToan', 'CaHai')");

        // Inventory movement type check constraint
        modelBuilder.Entity<BienDongKhoHang>()
            .HasCheckConstraint("CK_BienDongKhoHang_LoaiBienDong", "[LoaiBienDong] IN ('NHAP', 'XUAT', 'DIEU_CHINH')");

        // Payment status check constraint
        modelBuilder.Entity<DonHang>()
            .HasCheckConstraint("CK_DonHang_TrangThaiThanhToan", "[TrangThaiThanhToan] IN ('ChoThanhToan', 'DaThanhToan', 'ThatBai', 'HoanTien')");

        // Discount type check constraint
        modelBuilder.Entity<MaGiamGia>()
            .HasCheckConstraint("CK_MaGiamGia_LoaiGiamGia", "[LoaiGiamGia] IN ('PhanTram', 'SoTienCoDinh')");

        // Rating range check constraint
        modelBuilder.Entity<DanhGiaSanPham>()
            .HasCheckConstraint("CK_DanhGiaSanPham_DiemDanhGia", "[DiemDanhGia] BETWEEN 1 AND 5");

        // Article status check constraint
        modelBuilder.Entity<BaiViet>()
            .HasCheckConstraint("CK_BaiViet_TrangThai", "[TrangThai] IN ('NhapBan', 'ChoXuatBan', 'XuatBan')");

        // Comment status check constraint
        modelBuilder.Entity<BinhLuanBaiViet>()
            .HasCheckConstraint("CK_BinhLuanBaiViet_TrangThai", "[TrangThai] IN ('ChoDuyet', 'DaDuyet', 'BiTuChoi')");

        // System log action check constraint
        modelBuilder.Entity<NhatKyHeThong>()
            .HasCheckConstraint("CK_NhatKyHeThong_HanhDong", "[HanhDong] IN ('THEM', 'SUA', 'XOA')");
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateAuditableEntities();
        return base.SaveChanges();
    }

    private void UpdateAuditableEntities()
    {
        var entries = ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.NgayTao = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.NgayCapNhatCuoi = DateTime.UtcNow;
                    break;
            }
        }
    }
}