using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;

namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Entity> _repository;

        public GenericService(IMapper mapper, IGenericRepository<Entity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Create(SaveViewModel vm)
        {
            var entity = _mapper.Map<Entity>(vm);
            await _repository.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(entity);
        }

        public async Task<List<ViewModel>> GetAll()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(entities);
        }

        public async Task<SaveViewModel> GetById(int id)
        {
            return _mapper.Map<SaveViewModel>(await _repository.GetByIdAsync(id));
        }

        public async Task Update(int id, SaveViewModel vm)
        {
            var entity = _mapper.Map<Entity>(vm);
            await _repository.UpdateAsync(id, entity);
        }
    }
}
