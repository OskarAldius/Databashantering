using System;
using Client.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Client.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.FirstName)
            .HasColumnName("firstName")
            .HasColumnType("VARCHAR(20)")
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasColumnName("lastName")
            .HasColumnType("VARCHAR(40)")
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasColumnType("VARCHAR(128)")
            .IsRequired();

        builder.HasIndex(c => c.Email).IsUnique();

        builder.Property(c => c.Phone)
            .HasColumnName("phone")
            .HasColumnType("VARCHAR(15)");

    }
}
