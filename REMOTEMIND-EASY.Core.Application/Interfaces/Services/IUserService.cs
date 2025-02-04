using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IUserService:IGenericService<UserViewModel, UserSaveViewModel, User>
    {
        Task<UserViewModel> Login(LoginViewModel vm);
        Task<UserSaveViewModel> Rgister(UserSaveViewModel vm);

        Task<List<UserViewModel>> GetAllByEnterprise(int id);
    }
}
