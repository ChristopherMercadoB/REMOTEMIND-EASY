using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class UserService : GenericService<UserViewModel, UserSaveViewModel, User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public UserService(IMapper mapper, IUserRepository repository):base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<UserViewModel>> GetAllByEnterprise(int id)
        {
            var users = await _repository.GetAllAsync();
            return users.Where(e => e.EnterpriseId == id).Select(x => new UserViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Username = x.Username,
                RoleId = x.RoleId,

            }).ToList();
        }

        public async Task<UserViewModel> Login(LoginViewModel vm)
        {
            var user = await _repository.LoginAsync(vm);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task<UserSaveViewModel> Rgister(UserSaveViewModel vm)
        {
            var allUsers = await _repository.GetAllAsync();
            var userWithSameUsername = allUsers.FirstOrDefault(e=>e.Username == vm.Username);
            if (userWithSameUsername != null) 
            { 
                vm.HasError = true;
                vm.Error = $"El nombre de usuario '{vm.Username}' ya esta siendo usado";
                return vm;
            }


            var user = _mapper.Map<User>(vm);
            user.Password = PasswordEncryption.HashPassword(vm.Password);
            await _repository.AddAsync(user);
            return vm;
        }
    }
}
