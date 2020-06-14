using APBD_cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Configuration
{
    public class ConfectionaryConfig : IEntityTypeConfiguration<Confectionary>
    {
        public void Configure(EntityTypeBuilder<Confectionary> builder)
        {
            builder.HasKey(e => e.IdConfectionary);
            builder.Property(e => e.IdConfectionary).ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Type).HasMaxLength(40).IsRequired();
            builder.ToTable("Confectionary");

            builder.HasMany(confectionary => confectionary.Confectionary_Orders)
                   .WithOne(conficOrder => conficOrder.Confectionary)
                   .HasForeignKey(conficOrder => conficOrder.IdConfection)
                   .IsRequired();

        }
    }
}
