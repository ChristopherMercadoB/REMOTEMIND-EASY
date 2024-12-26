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
                return "Su nivel de estres es estable";
            }
            else if (prom > 33 && prom < 66)
            {
                return "Le recomendamos mejorar su distrbucion";
            }

            return "Nivel de estres alto, le recomendamos visitar a un psicologo";
        }
    }
}
