using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Wrappers;
using REMOTEMIND_EASY.Core.Domain.Entities;

namespace REMOTEMIND_EASY.Core.Application.Features.UserResponses.Command
{
    public class CreateUserResponseCommand : IRequest<Response<UserResponse>>
    {
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }
        public string? UserId { get; set; }
    }

    public class CreateUserResponseCommandHandler : IRequestHandler<CreateUserResponseCommand, Response<UserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserResponseRepository _repository;

        public CreateUserResponseCommandHandler(IMapper mapper, IUserResponseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<UserResponse>> Handle(CreateUserResponseCommand request, CancellationToken cancellationToken)
        {
            var res = _mapper.Map<UserResponse>(request);
            res = await _repository.AddAsync(res);
            return new Response<UserResponse>(res);
        }
    }
}
