using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.Result;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.Wrappers;

namespace REMOTEMIND_EASY.Core.Application.Features.Results.Queries.GetByUserId
{
    public class GetResultByUserIdQuery : IRequest<Response<List<ResultDTO>>>
    {
        public string UserId { get; set; }
    }

    public class GetResultByUserIdQueryHandler : IRequestHandler<GetResultByUserIdQuery, Response<List<ResultDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IResultRepository _repository;
        private readonly IAccountService _service;

        public GetResultByUserIdQueryHandler(IMapper mapper, IResultRepository repository, IAccountService service)
        {
            _mapper = mapper;
            _repository = repository;
            _service = service;
        }

        public async Task<Response<List<ResultDTO>>> Handle(GetResultByUserIdQuery request, CancellationToken cancellationToken)
        {
            var isRegistered = await _service.IsUserRegistered(userId: request.UserId);
            if (isRegistered == false)
            {
                throw new ApiException("No hay usuario registrado con ese ID");
            }
            var result = await _repository.GetAllAsync();
            if (!result.Any())
            {
                throw new ApiException("No hay registros");
            }
            result = result.Where(e=> e.UserId == request.UserId).ToList();

            var res = _mapper.Map<List<ResultDTO>>(result);
            return new Response<List<ResultDTO>>(res);
        }
    }
}
