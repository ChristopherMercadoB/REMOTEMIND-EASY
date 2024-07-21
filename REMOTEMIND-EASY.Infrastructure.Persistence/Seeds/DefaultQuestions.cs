using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Seeds
{
    public static class DefaultQuestions
    {
        public static async Task SeeAsync(IQuestionRepository question)
        {
            var ques = await question.GetAllAsync();
            if (ques == null || ques.Count <=0)
            {
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "En el último mes, ¿con qué frecuencia ha sentido que no podía controlar las cosas importantes en su vida?" });
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "En el último mes, ¿con qué frecuencia ha sentido nerviosismo y estrés?" });
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "En el último mes, ¿con qué frecuencia ha sentido que no podía hacer frente a todas las cosas que tenía que hacer?" });
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "En el último mes, ¿con qué frecuencia ha sentido que las dificultades se acumulaban tanto que no podía superarlas?" });
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "En los últimos tres meses, ¿ha experimentado un cambio significativo en su situación laboral que le haya causado estrés?" });
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "¿Con qué frecuencia se siente abrumado por su carga de trabajo?" });
                await question.AddAsync(new Core.Domain.Entities.Questions() { Title = "¿Le resulta difícil relajarse después de un día de trabajo?" });
            }
        }
    }
}
