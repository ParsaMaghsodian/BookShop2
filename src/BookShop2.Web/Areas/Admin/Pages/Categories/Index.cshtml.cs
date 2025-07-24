using BookShop2.Application.DTO;
using BookShop2.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Categories;

public class IndexModel : PageModel
{
    private readonly ICategoryService _categoryService;
    public IndexModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [BindProperty]
    public IList<BookCategoryViewModel> Categories { get; set; }
    [TempData]
    public string StatusMessage { get; set; }
    public async Task OnGetAsync()
    {
        Categories = await _categoryService.GetAllCategoriesAsync();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        await _categoryService.UpdateOrAddCategoriesAsync(Categories);
        await _categoryService.DeleteCategoriesAsync(Categories);
        StatusMessage = "Operation succeed";
        return RedirectToPage("./Index");

    }
}
