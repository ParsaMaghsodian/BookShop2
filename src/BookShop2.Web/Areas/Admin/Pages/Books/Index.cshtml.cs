using BookShop2.Application.DTO;
using BookShop2.Infrastructure;
using BookShop2.Infrastructure.DataModels;
using Mapster;
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
        public IList<BookDTO>? BookList { get; set; }
        public void OnGet()
        {
            var bookDataList = _db.Books?.ToList() ?? new List<BookData>();
            BookList = bookDataList.Adapt<List<BookDTO>>();
        }
    }
}
