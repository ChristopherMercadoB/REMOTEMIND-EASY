using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.Result;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Wrappers;

namespace REMOTEMIND_EASY.Core.Application.Features.Results.Queries.GetAll
{
    public class GetAllResultQuery : IRequest<Response<List<ResultDTO>>>
    {
    }

    public class GetAllResultQueryHandler : IRequestHandler<GetAllResultQuery, Response<List<ResultDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IResultRepository _repository;

        public GetAllResultQueryHandler(IMapper mapper, IResultRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<ResultDTO>>> Handle(GetAllResultQuery request, CancellationToken cancellationToken)
        {
            var results = await _repository.GetAllAsync();
            if (!results.Any())
            {
                throw new ApiException("No hay registros");
            }

            var res = _mapper.Map<List<ResultDTO>>(results);
            return new Response<List<ResultDTO>>(res);
        }
    }
}
