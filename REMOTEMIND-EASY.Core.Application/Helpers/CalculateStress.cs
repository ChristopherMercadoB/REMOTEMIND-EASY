using REMOTEMIND_EASY.Core.Domain.Entities;

namespace REMOTEMIND_EASY.Core.Application.Helpers
{
    public static class CalculateStress
    {
        public static int? Calculate(List<int?> responses)
        {
            int? prom = 0;
            foreach (var item in responses)
            {
                prom += item;
            }
            
            var num = prom / 7;

            return num;
        }
    }
}
