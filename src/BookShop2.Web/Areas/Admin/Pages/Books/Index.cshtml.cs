using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop2.Web.Areas.Admin.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<BookData> ? BookList { get; set; }
        public void OnGet()
        {
              BookList = _db.Books?.ToList() ?? new List<BookData>();
        }
    }
}
