using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfiguration;

public class DeviceGroupEntityConfiguration : IEntityTypeConfiguration<DeviceGroup>
{
    public void Configure(EntityTypeBuilder<DeviceGroup> modelBuilder)
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
            .HasOne(group => group.NavParentDeviceGroups)
            .WithMany()
            .HasPrincipalKey(group => group.Id)
            .HasForeignKey(x => x.ParentDeviceGroupId);

        modelBuilder.HasCheckConstraint("CK_No_Self_Reference",
            "1 = case when ParentDeviceGroupId = Id then 0 else 1 end");
    }
}