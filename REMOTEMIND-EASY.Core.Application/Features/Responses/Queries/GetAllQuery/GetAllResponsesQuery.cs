using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.Responses;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Wrappers;

namespace REMOTEMIND_EASY.Core.Application.Features.Responses.Queries.GetAllQuery
{
    public class GetAllResponsesQuery : IRequest<Response<List<ResponsesDTO>>>
    {
    }

    public class GetAllResponsesQueryHandler : IRequestHandler<GetAllResponsesQuery, Response<List<ResponsesDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IResponseRepository _repository;

        public GetAllResponsesQueryHandler(IMapper mapper, IResponseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<ResponsesDTO>>> Handle(GetAllResponsesQuery request, CancellationToken cancellationToken)
        {

            var result = await _repository.GetAllAsync();
            if (!result.Any())
            {
                throw new ApiException("No hay registros");
            }

            var quest = _mapper.Map<List<ResponsesDTO>>(result);
            return new Response<List<ResponsesDTO>>(quest);

        }
    }
}
