using Microsoft.AspNetCore.Mvc;

namespace Project.Page.Pages.ViewComponents;

public class ArticleViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}