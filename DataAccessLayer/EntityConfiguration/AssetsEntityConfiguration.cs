using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccesLayer.EntityConfiguration;

public class AssetsEntityConfiguration : IEntityTypeConfiguration<Assets>
{
    public void Configure(EntityTypeBuilder<Assets> modelBuilder)
    {
        modelBuilder
            .HasKey(x => x.Id);

        modelBuilder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        modelBuilder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(512);

        modelBuilder
            .Property(x => x.SerialNumber)
            .IsRequired()
            .HasMaxLength(512);

        modelBuilder
            .Property(x => x.FirmwareVersion)
            .IsRequired()
            .HasMaxLength(5);

        modelBuilder
            .Property(x => x.CreatedOnDateTime)
            .IsRequired()
            .HasColumnType("datetime2(0)");

        modelBuilder
            .Property(x => x.LastModifiedOnDateTime)
            .HasColumnType("datetime2(0)");

        modelBuilder
            .Property(x => x.Active)
            .IsRequired();
        
        modelBuilder
            .HasOne(asset => asset.NavDeviceGroups)
            .WithMany(group => group.NavAssets)
            .HasPrincipalKey(group => group.Id)
            .HasForeignKey(asset => asset.DeviceGroupId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}