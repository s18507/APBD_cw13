using APBD_cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Configuration
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee_confectionary>
    {
        public void Configure(EntityTypeBuilder<Employee_confectionary> builder)
        {

            builder.HasKey(e => e.IdEmployee);
            builder.Property(e => e.IdEmployee).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(60).IsRequired();
            builder.ToTable("Employee");

            builder.HasMany(emp => emp.Orders)
                      .WithOne(order => order.Employee)
                      .HasForeignKey(order => order.IdEmployee)
                      .IsRequired();

        }
    }
}
