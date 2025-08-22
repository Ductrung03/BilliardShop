using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BilliardShop.Domain.Entities;

namespace BilliardShop.Infrastructure.Data.Configurations;

public class SuDungMaGiamGiaConfiguration : IEntityTypeConfiguration<SuDungMaGiamGia>
{
    public void Configure(EntityTypeBuilder<SuDungMaGiamGia> builder)
    {
        builder.HasOne(e => e.MaGiamGia)
            .WithMany(e => e.SuDungMaGiamGias)
            .HasForeignKey(e => e.MaMaGiamGia)
            .HasConstraintName("FK_SuDungMaGiamGia_MaGiamGia")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.NguoiDung)
            .WithMany()
            .HasForeignKey(e => e.MaNguoiDung)
            .HasConstraintName("FK_SuDungMaGiamGia_NguoiDung")
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.DonHang)
            .WithMany(e => e.SuDungMaGiamGias)
            .HasForeignKey(e => e.MaDonHang)
            .HasConstraintName("FK_SuDungMaGiamGia_DonHang")
            .OnDelete(DeleteBehavior.Restrict);
    }
}