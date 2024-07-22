using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.UserResponse;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Wrappers;

namespace REMOTEMIND_EASY.Core.Application.Features.UserResponses.Queries.GetAllQuery
{
    public class GetAllUserResponseQuery : IRequest<Response<List<UserResponseDTO>>>
    {
    }

    public class GetAllUserResponseQueryHandler : IRequestHandler<GetAllUserResponseQuery, Response<List<UserResponseDTO>>>
    {

        private readonly IMapper _mapper;
        private readonly IUserResponseRepository _repository;

        public GetAllUserResponseQueryHandler(IMapper mapper, IUserResponseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<UserResponseDTO>>> Handle(GetAllUserResponseQuery request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetAllAsync();
            if (!res.Any())
            {
                throw new ApiException("No hay registros");
            }

            var entity = _mapper.Map<List<UserResponseDTO>>(res);
            return new Response<List<UserResponseDTO>>(entity);
        }
    }
}
