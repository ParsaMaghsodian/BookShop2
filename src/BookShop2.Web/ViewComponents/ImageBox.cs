using Microsoft.AspNetCore.Mvc;

namespace BookShop2.Web.ViewComponents;

[ViewComponent]
public class ImageBox : ViewComponent
{
    public IViewComponentResult Invoke(byte[] ? contents, string style, string alt , string classboot)
    {
        var viewModel = new ImageBoxViewModel
        {
            ImageBase64 = contents != null ? Convert.ToBase64String(contents) : null,
            Style = style,
            Alt = alt , 
            Class = classboot
        };
        return View("Default",viewModel);
    }
  
}


public class ImageBoxViewModel
{
    public string  ? ImageBase64 { get; set; }
    public required string  Style { get; set; }
    public required string Alt { get; set; }
    public required string Class { get; set; }
}
