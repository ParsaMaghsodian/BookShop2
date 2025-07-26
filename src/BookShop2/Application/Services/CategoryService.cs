using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _db;
    public CategoryService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task DeleteCategoriesAsync(IList<BookCategoryViewModel> categories)
    {
        foreach (var category in categories)
        {
            if (category.IsChecked == true && !string.IsNullOrEmpty(category.Name))
            {
                var bookCategory = category.Adapt<BookCategory>();
                _db.Entry(bookCategory).State = EntityState.Deleted;
            }
        }
        await _db.SaveChangesAsync();
    }

    public async Task<IList<BookCategoryViewModel>> GetAllCategoriesAsync()
    {
        return await _db.Categories
            .Select(c => new BookCategoryViewModel { Name = c.Name, Id = c.Id, OriginalName = c.Name })
            .ToListAsync();
    }

    public async Task UpdateOrAddCategoriesAsync(IList<BookCategoryViewModel> categories)
    {
        if (categories != null && categories.Count != 0)
        {
            foreach (var category in categories)
            {
                if (category.Id != 0 && category.Name != category.OriginalName && !string.IsNullOrEmpty(category.Name))
                {
                    var bookCategory = category.Adapt<BookCategory>();
                    _db.Entry(bookCategory).State = EntityState.Modified;
                }
                if (category.Id == 0 && !string.IsNullOrEmpty(category.Name))
                {
                    var bookCategory = category.Adapt<BookCategory>();
                    _db.Entry(bookCategory).State = EntityState.Added;
                }
            }
            await _db.SaveChangesAsync();
        }

    }
}