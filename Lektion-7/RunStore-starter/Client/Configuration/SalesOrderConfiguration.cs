using System;
using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrders>
{
    public void Configure(EntityTypeBuilder<SalesOrders> builder)
    {
        builder.ToTable("salesorders");

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.OrderNumber)
            .HasColumnName("orderNumber")
            .HasColumnType("VARCHAR(15)")
            .IsRequired();

        builder.HasIndex(c => c.OrderNumber).IsUnique();

        builder.Property(c => c.OrderDate)
            .HasColumnName("orderDate");

    }
}
