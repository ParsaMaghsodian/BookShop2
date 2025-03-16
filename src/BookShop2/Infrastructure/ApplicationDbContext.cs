using BookShop2.Infrastructure.DataModels;
using BookShop2.Infrastructure.FluentApi;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BookShop2.Infrastructure;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Seeding
        builder.Entity<BookData>().HasData(
            new BookData
            {
                Id = 1,
                Name = "ASP.NET Core in Action",
                Description = "Build professional-grade full-stack web applications using C# and ASP.NET Core. In ASP.NET Core in Action, Third Edition",
                Author = "Andrew Lock",
                Date = new DateTime(2023, 10, 01),
                Pages = 984,
                Price = 50
            },
            new BookData
            {
                Id = 2,
                Name = "Pro ASP.NET Core 7",
                Description = "Now in its tenth edition, this industry-leading guide to ASP.NET Core teaches everything you need to know to create easy, extensible, and cloud-native web applications",
                Author = "Adam Freeman",
                Date = new DateTime(2023, 11, 01),
                Pages = 1256,
                Price = 65
            });
        builder.ApplyConfiguration(new BookDataConfiguration());
        base.OnModelCreating(builder);
    }

    public DbSet<BookData> Books { get; set; }

}
