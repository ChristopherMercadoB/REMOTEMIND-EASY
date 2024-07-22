using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.Result;
using REMOTEMIND_EASY.Core.Application.DTO_S.UserResponse;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.Wrappers;

namespace REMOTEMIND_EASY.Core.Application.Features.UserResponses.Queries.GetByUserIdQuery
{
    public class GetUserResponseByUserIdQuery : IRequest<Response<List<UserResponseDTO>>>
    {
        public string UserId { get; set; }
    }

    public class GetUserResponseByUserIdQueryHandler : IRequestHandler<GetUserResponseByUserIdQuery, Response<List<UserResponseDTO>>>
    {

        private readonly IMapper _mapper;
        private readonly IUserResponseRepository _repository;
        private readonly IAccountService _service;

        public GetUserResponseByUserIdQueryHandler(IMapper mapper, IUserResponseRepository repository, IAccountService service)
        {
            _mapper = mapper;
            _repository = repository;
            _service = service;
        }

        public async Task<Response<List<UserResponseDTO>>> Handle(GetUserResponseByUserIdQuery request, CancellationToken cancellationToken)
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
            result = result.Where(e => e.UserId == request.UserId).ToList();

            var res = _mapper.Map<List<UserResponseDTO>>(result);
            return new Response<List<UserResponseDTO>>(res);
        }
    }
}
