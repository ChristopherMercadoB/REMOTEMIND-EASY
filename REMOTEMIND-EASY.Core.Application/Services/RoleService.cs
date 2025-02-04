using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.Role;
using REMOTEMIND_EASY.Core.Domain.Entities;

namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RoleViewModel>> GetAll()
        {
            var roles = await _repository.GetAll();
            var roleVm = _mapper.Map<List<RoleViewModel>>(roles);
            return roleVm;
        }
    }
}
