using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.Result;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.Wrappers;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System.Text.Json.Serialization;


namespace REMOTEMIND_EASY.Core.Application.Features.Results.Command.CreateCommand
{
    public class CreateResultCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        [JsonIgnore]
        public int TotalValue { get; set; }
        public string? UserId { get; set; }
    }

    public class CreateResultCommandHandler : IRequestHandler<CreateResultCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IResultRepository _repository;
        private readonly IUserResponseRepository _userResponseRepository;
        private readonly IAccountService _service;

        public CreateResultCommandHandler(IMapper mapper, IResultRepository repository, IUserResponseRepository userResponseRepository, IAccountService service)
        {
            _mapper = mapper;
            _repository = repository;
            _userResponseRepository = userResponseRepository;
            _service = service;
        }

        public async Task<Response<int>> Handle(CreateResultCommand request, CancellationToken cancellationToken)
        {
            List<int?> values = new List<int?>();
            var isRegistered = await _service.IsUserRegistered(userId: request.UserId);
            if (isRegistered == false)
            {
                throw new ApiException("No hay usuario registrado con ese ID");
            }
            var result = await _userResponseRepository.GetAllInclude(new List<string> { "Response"});
            if (!result.Any())
            {
                throw new ApiException("No hay registros");
            }
            result = result.Where(e => e.UserId == request.UserId).Select(x => new UserResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                QuestionId = x.QuestionId,
                ResponseId = x.ResponseId,
                Value = x.Response.Value
            }).ToList();


            foreach (var item in result)
            {
                values.Add(item.Value);
            }

            var total = CalculateStress.Calculate(values);

            var create = await _repository.AddAsync(new Result()
            {
                UserId = request.UserId,
                Name = request.Name,
                TotalValue = (int)total
            });


            return new Response<int>(create.Id);
        }
    }
}
