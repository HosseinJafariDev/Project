using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Page.Pages.Admin;

[Authorize(Roles = "Admin,Author")]
public class Index : PageModel
{
    public void OnGet()
    {
        ViewData["Title"] = "پنل مدیریت";
    }
}