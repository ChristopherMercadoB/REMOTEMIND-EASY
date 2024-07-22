using REMOTEMIND_EASY.Core.Application.DTO_S.Authentication;
using REMOTEMIND_EASY.Core.Application.Wrappers;


namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateApiAsync(AuthenticationRequest request);
        Task<Response<string>> RegisterEmployeeAsyncApi(RegisterRequest request);
        Task<Response<string>> RegisterEnterpriseAsyncApi(RegisterRequest request);
        Task<bool> IsUserRegistered(string userId, string email = " ");
    }
}
