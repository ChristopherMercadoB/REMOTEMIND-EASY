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

        public async Task<int> CreateMany(List<UserResponseSaveViewModel> vm)
        {
            Random ran = new Random();
        Random:
            var number = ran.Next(1, vm.Count + 1);
            var many = await this.GetAll();
            var sameId = many.FirstOrDefault(e => e.TestId == number);
            if (sameId != null)
            {
                goto Random;
            }
            foreach (var item in vm)
            {
                item.TestId = number;
            }
            var entities = _mapper.Map<List<UserResponse>>(vm);
            await _repository.AddMany(entities);
            return number;
        }
    }
}
