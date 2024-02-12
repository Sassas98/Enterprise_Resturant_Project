using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configurations {
    internal class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.ToTable("Order");
            builder.HasKey(k => k.Id);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);
        }
    }
}