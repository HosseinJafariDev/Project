namespace Project.Application.UseCases.Auth.Register;

public class RegisterUseCase(IRegisterService registerService) : IRegisterUseCase
{
    public async Task<RegisterOutputDto> ExecuteAsync(RegisterInputDto input)
    {
        var result = await registerService.RegisterAsync(input);
        return result;
    }
}