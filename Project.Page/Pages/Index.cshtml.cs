using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Page.Pages;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "Home page";
    }
}