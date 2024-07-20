using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Helpers
{
    public static class StressLevel
    {
        public static string GetStressLevel(int prom)
        {
            if (prom <= 33)
            {
                return "Nivel de estres bajo";
            }
            else if (prom > 33 && prom < 66)
            {
                return "Nivel de estre medio";
            }

            return "Nivel de estres alto";
        }
    }
}
