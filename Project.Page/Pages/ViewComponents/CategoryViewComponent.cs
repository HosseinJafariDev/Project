using Microsoft.AspNetCore.Mvc;

namespace Project.Page.Pages.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    public IViewComponentResult InvokeResult()
    {
        return View();
    }
}