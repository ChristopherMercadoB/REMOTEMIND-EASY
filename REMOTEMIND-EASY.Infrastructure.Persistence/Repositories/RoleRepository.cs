using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAll()
        {
            return await _context.Set<Role>().ToListAsync();
        }
    }
}
