using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Page.Pages.Admin;

public class Index : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "پنل مدیریت";
    }
}