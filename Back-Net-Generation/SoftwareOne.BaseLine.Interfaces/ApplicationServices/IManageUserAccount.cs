using SoftwareOne.BaseLine.EntitiesDto.Request;
using SoftwareOne.BaseLine.EntitiesDto.Response;

namespace SoftwareOne.BaseLine.Interfaces.ApplicationServices
{
    public interface IManageUserAccount
    {
        Task<LoginAuthentication> LoginApplicationAsync(LoginRequest loginRequest);

        string ValidateSession(string? token);
    }
}