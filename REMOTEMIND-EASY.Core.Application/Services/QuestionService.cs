using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.Question;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class QuestionService : GenericService<QuestionViewModel, QuestionSaveViewModel, Questions>, IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _repository;

        public QuestionService(IMapper mapper, IQuestionRepository repository):base(mapper, repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


    }
}
