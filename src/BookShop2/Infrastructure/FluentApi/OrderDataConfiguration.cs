using BookShop2.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.FluentApi;

public class OrderDataConfiguration : IEntityTypeConfiguration<OrderData>
{
    public void Configure(EntityTypeBuilder<OrderData> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.OrderId);
        builder.Property(x => x.Amount).IsRequired();
        builder.ToTable(x => x.HasCheckConstraint("CK_OrderData_Amount", "[Amount] >= 0 AND [Amount] <= 1000"));
        builder.Property(x => x.State).IsRequired();
        builder.Property(x => x.TimeCreation).HasColumnType("date");
        builder.HasOne(b => b.Book).WithMany().HasForeignKey(b=>b.BookId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(u => u.User).WithMany().HasForeignKey(u=>u.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
