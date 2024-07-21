using AutoMapper;
using MediatR;
using REMOTEMIND_EASY.Core.Application.DTO_S.Questions;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Wrappers;

namespace REMOTEMIND_EASY.Core.Application.Features.Questions.Queries.GetAllQuery
{
    public class GetAllQuestionQuery : IRequest<Response<List<QuestionDTO>>>
    {
    }

    public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQuery, Response<List<QuestionDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _repository;

        public GetAllQuestionQueryHandler(IMapper mapper, IQuestionRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<List<QuestionDTO>>> Handle(GetAllQuestionQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            if (!result.Any())
            {
                throw new ApiException("No hay registros");
            }

            var quest = _mapper.Map<List<QuestionDTO>>(result);
            return new Response<List<QuestionDTO>>(quest);
        }
    }
}
