using BookShop2.Infrastructure.DataModels;
using BookShop2.Infrastructure.FluentApi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BookShop2.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Seeding
        builder.Entity<BookCategory>().HasData(
            new BookCategory
            {
                Id = 1,
                Name = "Technical"
            },
            new BookCategory
            {
                Id = 2,
                Name = "Fiction"
            },
            new BookCategory
            {
                Id = 3,
                Name = "Children"
            },
            new BookCategory
            {
                Id = 4,
                Name = "Novel"
            }
            );
        builder.ApplyConfiguration(new BookDataConfiguration());
        builder.ApplyConfiguration(new BookCategoryConfiguration());
        base.OnModelCreating(builder);
    }

    public DbSet<BookData> Books { get; set; }
    public DbSet<BookCategory> Categories { get; set; }

}
