using REMOTEMIND_EASY.Core.Domain.Entities;

namespace REMOTEMIND_EASY.Core.Application.Helpers
{
    public static class CalculateStress
    {
        public static int Calculate(List<Responses> responses)
        {
            int prom = 0;
            foreach (Responses response in responses)
            {
                prom += response.Value;
            }

            return prom/responses.Count;
        }
    }
}
