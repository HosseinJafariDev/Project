using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Auth.Logout;

namespace Project.Page.Pages.Auth;

public class Logout(ILogoutUseCase logoutUseCase) : PageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        await logoutUseCase.ExecuteAsync();
        return RedirectToPage("/Auth/Login");
    }
}