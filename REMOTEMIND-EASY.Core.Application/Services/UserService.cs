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

        public async Task<UserViewModel> Login(LoginViewModel vm)
        {
            var user = await _repository.LoginAsync(vm);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public async Task Rgister(UserSaveViewModel vm)
        {
            var user = _mapper.Map<User>(vm);
            user.Password = PasswordEncryption.HashPassword(vm.Password);
            await _repository.AddAsync(user);
        }
    }
}
