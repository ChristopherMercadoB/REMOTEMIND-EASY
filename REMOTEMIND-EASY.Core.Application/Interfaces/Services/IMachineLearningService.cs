using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface IMachineLearningService
    {
        bool GetSentiment(string comment, string path);
    }
}
