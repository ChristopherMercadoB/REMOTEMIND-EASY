using REMOTEMIND_EASY.Core.Domain.Entities;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Repositories
{
    public interface IRoleRepository 
    {
        Task<List<Role>> GetAll();
    }
}
