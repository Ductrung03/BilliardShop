using Microsoft.EntityFrameworkCore.Storage;
using BilliardShop.Domain.Entities;
using BilliardShop.Domain.Interfaces;
using BilliardShop.Domain.Interfaces.Repositories;
using BilliardShop.Infrastructure.Data;

namespace BilliardShop.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly BilliardShopDbContext _context;
    private IDbContextTransaction? _transaction;
    private bool _disposed = false;

    // User Management Repositories
    private IVaiTroNguoiDungRepository? _vaiTroNguoiDungRepository;
    private INguoiDungRepository? _nguoiDungRepository;
    private IDiaChiNguoiDungRepository? _diaChiNguoiDungRepository;

    // Product Management Repositories - Updated with specific interfaces
    private IDanhMucSanPhamRepository? _danhMucSanPhamRepository;
    private IThuongHieuRepository? _thuongHieuRepository;
    private ISanPhamRepository? _sanPhamRepository;
    private IHinhAnhSanPhamRepository? _hinhAnhSanPhamRepository;
    private IThuocTinhSanPhamRepository? _thuocTinhSanPhamRepository;

    // Inventory Management Repositories
    private IGenericRepository<NhaCungCap>? _nhaCungCapRepository;
    private IGenericRepository<BienDongKhoHang>? _bienDongKhoHangRepository;

    // Order Management Repositories
    private IGenericRepository<TrangThaiDonHang>? _trangThaiDonHangRepository;
    private IGenericRepository<PhuongThucThanhToan>? _phuongThucThanhToanRepository;
    private IGenericRepository<PhuongThucVanChuyen>? _phuongThucVanChuyenRepository;
    private IGenericRepository<DonHang>? _donHangRepository;
    private IGenericRepository<ChiTietDonHang>? _chiTietDonHangRepository;

    // Promotions & Discounts Repositories
    private IGenericRepository<MaGiamGia>? _maGiamGiaRepository;
    private IGenericRepository<SuDungMaGiamGia>? _suDungMaGiamGiaRepository;

    // Customer Interactions Repositories
    private IGenericRepository<DanhGiaSanPham>? _danhGiaSanPhamRepository;
    private IGenericRepository<DanhSachYeuThich>? _danhSachYeuThichRepository;
    private IGenericRepository<GioHang>? _gioHangRepository;

    // System Settings & Blog Repositories
    private ICaiDatHeThongRepository? _caiDatHeThongRepository;
    private IGenericRepository<BaiViet>? _baiVietRepository;
    private IGenericRepository<BinhLuanBaiViet>? _binhLuanBaiVietRepository;
    private INhatKyHeThongRepository? _nhatKyHeThongRepository;

    public UnitOfWork(BilliardShopDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    // User Management Repository Properties
    public IVaiTroNguoiDungRepository VaiTroNguoiDungRepository
        => _vaiTroNguoiDungRepository ??= new VaiTroNguoiDungRepository(_context);

    public INguoiDungRepository NguoiDungRepository
        => _nguoiDungRepository ??= new NguoiDungRepository(_context);

    public IDiaChiNguoiDungRepository DiaChiNguoiDungRepository
        => _diaChiNguoiDungRepository ??= new DiaChiNguoiDungRepository(_context);

    // Product Management Repository Properties - Updated with specific implementations
    public IDanhMucSanPhamRepository DanhMucSanPhamRepository
        => _danhMucSanPhamRepository ??= new DanhMucSanPhamRepository(_context);

    public IThuongHieuRepository ThuongHieuRepository
        => _thuongHieuRepository ??= new ThuongHieuRepository(_context);

    public ISanPhamRepository SanPhamRepository
        => _sanPhamRepository ??= new SanPhamRepository(_context);

    public IHinhAnhSanPhamRepository HinhAnhSanPhamRepository
        => _hinhAnhSanPhamRepository ??= new HinhAnhSanPhamRepository(_context);

    public IThuocTinhSanPhamRepository ThuocTinhSanPhamRepository
        => _thuocTinhSanPhamRepository ??= new ThuocTinhSanPhamRepository(_context);

    // Inventory Management Repository Properties
    public IGenericRepository<NhaCungCap> NhaCungCapRepository
        => _nhaCungCapRepository ??= new GenericRepository<NhaCungCap>(_context);

    public IGenericRepository<BienDongKhoHang> BienDongKhoHangRepository
        => _bienDongKhoHangRepository ??= new GenericRepository<BienDongKhoHang>(_context);

    // Order Management Repository Properties
    public IGenericRepository<TrangThaiDonHang> TrangThaiDonHangRepository
        => _trangThaiDonHangRepository ??= new GenericRepository<TrangThaiDonHang>(_context);

    public IGenericRepository<PhuongThucThanhToan> PhuongThucThanhToanRepository
        => _phuongThucThanhToanRepository ??= new GenericRepository<PhuongThucThanhToan>(_context);

    public IGenericRepository<PhuongThucVanChuyen> PhuongThucVanChuyenRepository
        => _phuongThucVanChuyenRepository ??= new GenericRepository<PhuongThucVanChuyen>(_context);

    public IGenericRepository<DonHang> DonHangRepository
        => _donHangRepository ??= new GenericRepository<DonHang>(_context);

    public IGenericRepository<ChiTietDonHang> ChiTietDonHangRepository
        => _chiTietDonHangRepository ??= new GenericRepository<ChiTietDonHang>(_context);

    // Promotions & Discounts Repository Properties
    public IGenericRepository<MaGiamGia> MaGiamGiaRepository
        => _maGiamGiaRepository ??= new GenericRepository<MaGiamGia>(_context);

    public IGenericRepository<SuDungMaGiamGia> SuDungMaGiamGiaRepository
        => _suDungMaGiamGiaRepository ??= new GenericRepository<SuDungMaGiamGia>(_context);

    // Customer Interactions Repository Properties
    public IGenericRepository<DanhGiaSanPham> DanhGiaSanPhamRepository
        => _danhGiaSanPhamRepository ??= new GenericRepository<DanhGiaSanPham>(_context);

    public IGenericRepository<DanhSachYeuThich> DanhSachYeuThichRepository
        => _danhSachYeuThichRepository ??= new GenericRepository<DanhSachYeuThich>(_context);

    public IGenericRepository<GioHang> GioHangRepository
        => _gioHangRepository ??= new GenericRepository<GioHang>(_context);

    // System Settings & Blog Repository Properties
    public ICaiDatHeThongRepository CaiDatHeThongRepository
        => _caiDatHeThongRepository ??= new CaiDatHeThongRepository(_context);

    public IGenericRepository<BaiViet> BaiVietRepository
        => _baiVietRepository ??= new GenericRepository<BaiViet>(_context);

    public IGenericRepository<BinhLuanBaiViet> BinhLuanBaiVietRepository
        => _binhLuanBaiVietRepository ??= new GenericRepository<BinhLuanBaiViet>(_context);

    public INhatKyHeThongRepository NhatKyHeThongRepository
        => _nhatKyHeThongRepository ??= new NhatKyHeThongRepository(_context);

    // Transaction Methods
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    // Transaction Management
    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            throw new InvalidOperationException("Transaction is already started.");
        }

        _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("No transaction started.");
        }

        try
        {
            await SaveChangesAsync(cancellationToken);
            await _transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction == null)
        {
            throw new InvalidOperationException("No transaction started.");
        }

        try
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
        finally
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    // Dispose Pattern
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}