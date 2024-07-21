using AutoMapper;
using REMOTEMIND_EASY.Core.Application.DTO_S.Questions;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Mapping
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            #region Question
            CreateMap<Questions, QuestionDTO>()
                .ReverseMap();
            #endregion
        }
    }
}
