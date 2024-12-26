using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Domain.Entities;


namespace REMOTEMIND_EASY.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel vm);
        Task<List<User>> GetAllNotAdmin();
    }
}
