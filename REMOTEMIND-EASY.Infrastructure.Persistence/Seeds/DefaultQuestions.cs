using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Seeds
{
    public static class DefaultQuestions
    {
        public static async Task SeedAsync(ApplicationContext context)
        {
            if (!await context.Set<Questions>().AnyAsync())
            {
                await context.Questions.AddRangeAsync(
                    new Questions { Title = "En el último mes, ¿con qué frecuencia ha sentido que no podía controlar las cosas importantes en su vida?" },
                    new Questions { Title = "En el último mes, ¿con qué frecuencia ha sentido nerviosismo y estrés?" },
                    new Questions { Title = "En el último mes, ¿con qué frecuencia ha sentido que no podía hacer frente a todas las cosas que tenía que hacer?" },
                    new Questions { Title = "En el último mes, ¿con qué frecuencia ha sentido que las dificultades se acumulaban tanto que no podía superarlas?" },
                    new Questions { Title = "En los últimos tres meses, ¿ha experimentado un cambio significativo en su situación laboral que le haya causado estrés?" },
                    new Questions { Title = "¿Con qué frecuencia se siente abrumado por su carga de trabajo?" },
                    new Questions { Title = "¿Le resulta difícil relajarse después de un día de trabajo?" }
                    );

                await context.SaveChangesAsync();
            }
        }
    }
}
