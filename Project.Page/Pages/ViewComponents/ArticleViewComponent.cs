using Microsoft.AspNetCore.Mvc;

namespace Project.Page.Pages.ViewComponents;

public class ArticleViewComponent : ViewComponent
{
    public IViewComponentResult InvokeAsync()
    {
        
        return View();
    }
}