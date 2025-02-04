using REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IUserResponseService:IGenericService<UserResponseViewModel, UserResponseSaveViewModel, UserResponse>
    {
        Task CreateMany(List<UserResponseSaveViewModel> vm);
    }
}
