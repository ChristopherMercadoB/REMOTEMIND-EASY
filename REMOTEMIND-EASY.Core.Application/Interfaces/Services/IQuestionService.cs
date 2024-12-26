using REMOTEMIND_EASY.Core.Application.ViewModels.Question;
using REMOTEMIND_EASY.Core.Domain.Entities;


namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IQuestionService : IGenericService<QuestionViewModel, QuestionSaveViewModel, Questions>
    {
    }
}
