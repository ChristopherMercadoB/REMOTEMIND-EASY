using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Repositories
{
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllNotAdmin()
        {
            var users =  await _context.Set<User>().ToListAsync();
            return users.Where(u => u.RoleId != 1).ToList();
        }

        public async Task<User> LoginAsync(LoginViewModel vm)
        {
            vm.Password = PasswordEncryption.HashPassword(vm.Password);
            var user =  await _context.Set<User>().FirstOrDefaultAsync(p =>p.Username == vm.Username && p.Password == vm.Password);
            return user;
        }
    }
}
