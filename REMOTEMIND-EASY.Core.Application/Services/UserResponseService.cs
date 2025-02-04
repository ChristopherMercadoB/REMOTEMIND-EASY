using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class UserResponseService:GenericService<UserResponseViewModel, UserResponseSaveViewModel, UserResponse>, IUserResponseService
    {
        private readonly IUserResponseRepository _repository;
        private readonly IMapper _mapper;

        public UserResponseService(IUserResponseRepository repository, IMapper mapper):base(mapper, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateMany(List<UserResponseSaveViewModel> vm)
        {
            var entities = _mapper.Map<List<UserResponse>>(vm);
            await _repository.AddMany(entities);
        }
    }
}
