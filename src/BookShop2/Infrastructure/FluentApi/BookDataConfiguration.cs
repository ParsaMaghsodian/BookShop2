using BookShop2.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.FluentApi;

public class BookDataConfiguration : IEntityTypeConfiguration<BookData>
{
    public void Configure(EntityTypeBuilder<BookData> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
        builder.Property(x => x.Description).HasMaxLength(1000);
        builder.Property(x => x.Date).HasColumnType("date");
        builder.Property(x => x.Author).HasMaxLength(50);
        builder.Property(x => x.Pages).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.ToTable(x => x.HasCheckConstraint("CK_BookData_Price", "[Price] >=0 AND [Price]<=1000"));
        builder.ToTable(x => x.HasCheckConstraint("CK_BookData_Pages", "[Pages] >=0 AND [Pages]<=10000"));
        builder.Property(x=>x.Language).IsRequired();
        builder.HasOne(x => x.BookCategory).WithMany().HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Restrict); 
        
    }
}
