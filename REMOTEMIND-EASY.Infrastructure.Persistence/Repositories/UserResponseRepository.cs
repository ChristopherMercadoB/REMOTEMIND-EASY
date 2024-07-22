using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Repositories
{
    public class UserResponseRepository : GenericRepository<UserResponse>, IUserResponseRepository
    {
        private readonly ApplicationContext _context;

        public UserResponseRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<UserResponse>> GetAllInclude(List<string> prop)
        {
            var query =  _context.Set<UserResponse>().AsQueryable();
            foreach (var item in prop)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }
    }
}
