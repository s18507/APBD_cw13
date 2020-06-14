using APBD_cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Configuration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer_confectionary>
    {
        public void Configure(EntityTypeBuilder<Customer_confectionary> builder)
        {

            builder.HasKey(e => e.IdClient);
            builder.Property(e => e.IdClient).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(60).IsRequired();
            builder.ToTable("Customer");

            builder.HasMany(emp => emp.Orders)
                      .WithOne(order => order.Customer)
                      .HasForeignKey(order => order.IdClient)
                      .IsRequired();

        }
    }
}
