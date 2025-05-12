using BookShop2.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Infrastructure.FluentApi;

public class CommentDataConfiguration : IEntityTypeConfiguration<CommentData>
{
    public void Configure(EntityTypeBuilder<CommentData> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Note).HasMaxLength(300).IsRequired();
        builder.Property(x => x.TimeCreation).HasColumnType("date");
        builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
    }
}
