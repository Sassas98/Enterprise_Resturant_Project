using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Configurations {
    internal class DishConfiguration : IEntityTypeConfiguration<Dish> {
        public void Configure(EntityTypeBuilder<Dish> builder) {
            builder.ToTable("Dish");
            builder.HasKey(k => k.Id);
            builder.HasOne(x => x.Order)
                .WithMany(x => x.Dishes)
                .HasForeignKey(x => x.OrderId);
        }
    }
}