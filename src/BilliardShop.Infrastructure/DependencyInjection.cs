using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BilliardShop.Domain.Interfaces;
using BilliardShop.Domain.Interfaces.Repositories;
using BilliardShop.Infrastructure.Data;
using BilliardShop.Infrastructure.Repositories;

namespace BilliardShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database Context
        services.AddDbContext<BilliardShopDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(BilliardShopDbContext).Assembly.FullName));
        });

        // Register Generic Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        // Register Specific Repositories - User Management
        services.AddScoped<IVaiTroNguoiDungRepository, VaiTroNguoiDungRepository>();
        services.AddScoped<INguoiDungRepository, NguoiDungRepository>();
        services.AddScoped<IDiaChiNguoiDungRepository, DiaChiNguoiDungRepository>();

        // Register Specific Repositories - Product Management
        services.AddScoped<IDanhMucSanPhamRepository, DanhMucSanPhamRepository>();
        services.AddScoped<IThuongHieuRepository, ThuongHieuRepository>();
        services.AddScoped<ISanPhamRepository, SanPhamRepository>();

        // Register Specific Repositories - System
        services.AddScoped<ICaiDatHeThongRepository, CaiDatHeThongRepository>();
        services.AddScoped<INhatKyHeThongRepository, NhatKyHeThongRepository>();

        // Register Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}