using APBD_cw13.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_cw13.Configuration
{
    public class Confectionary_OrderConfig : IEntityTypeConfiguration<Confectionary_Order>
    {
         public void Configure(EntityTypeBuilder<Confectionary_Order> builder)
		{
			builder.HasKey(e => new { e.IdConfection, e.IdOrder });
			builder.Property(e => e.Notes).HasMaxLength(255).IsRequired();
			builder.ToTable("Confectionary_Order");

		}
	}
}
