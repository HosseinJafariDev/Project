using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.Application.UseCases.Auth.Register;
using Project.Page.Contracts.Auth;
using Project.Page.Mappers;

namespace Project.Page.Pages.Auth;

public class SignUp(IRegisterUseCase registerUseCase) : PageModel
{
    [BindProperty] public SignUpRequest SignUpRequest { get; set; }


    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var result = await registerUseCase.ExecuteAsync(SignUpRequest.ToRegisterInputDto());
        return new JsonResult(result);
    }
}