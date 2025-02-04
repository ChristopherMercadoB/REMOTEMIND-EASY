using REMOTEMIND_EASY.Core.Domain.Entities;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Repositories
{
    public interface IUserResponseRepository : IGenericRepository<UserResponse>
    {
        Task<List<UserResponse>> GetAllInclude(List<string> prop);
        Task AddMany(List<UserResponse> userResponse);
    }
}
