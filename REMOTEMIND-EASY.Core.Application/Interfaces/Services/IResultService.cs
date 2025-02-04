using Microsoft.AspNetCore.Http;
using REMOTEMIND_EASY.Core.Application.ViewModels.Result;
using REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IResultService : IGenericService<ResultViewModel, ResultSaveViewModel, Result>
    {
        Task CreateResult(int userId);
        Task<List<ResultViewModel>> GetResultByUser(int userId);
    }
}
