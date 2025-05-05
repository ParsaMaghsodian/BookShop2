using BookShop2.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.FluentApi;

public class RatingDataConfiguartion : IEntityTypeConfiguration<RatingData>
{
    public void Configure(EntityTypeBuilder<RatingData> builder)
    {
        builder.ToTable("RatingData");
        builder.HasKey(k => new { k.OrderId, k.BookId });
        builder.Property(x => x.TimeCreation).HasColumnType("date");
        builder.HasOne(o => o.Order).WithOne(r => r.Rating).HasForeignKey<RatingData>(x=>x.OrderId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(b => b.Book).WithMany(r => r.Ratings).HasForeignKey(f => f.BookId).OnDelete(DeleteBehavior.NoAction);
    }
}
