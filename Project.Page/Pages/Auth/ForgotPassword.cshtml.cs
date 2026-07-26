using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Auth.Password;
using Project.Page.Contracts.Auth;

namespace Project.Page.Pages.Auth;

public class ForgotPassword(IForgotPasswordUseCase forgotPasswordUseCase) : PageModel
{
    [BindProperty] public ForgotPasswordRequest ForgotPasswordRequest { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var result =
            await forgotPasswordUseCase.ExecuteAsync(ForgotPasswordRequest.Username, ForgotPasswordRequest.Password);
        return new JsonResult(result);
    }
}