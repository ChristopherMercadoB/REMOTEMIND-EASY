using AutoMapper;
using REMOTEMIND_EASY.Core.Application.DTO_S.Questions;
using REMOTEMIND_EASY.Core.Application.DTO_S.Responses;
using REMOTEMIND_EASY.Core.Application.DTO_S.Result;
using REMOTEMIND_EASY.Core.Application.DTO_S.UserResponse;
using REMOTEMIND_EASY.Core.Application.Features.UserResponses.Command;
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

            #region Responses
            CreateMap<Responses, ResponsesDTO>()
                .ReverseMap();
            #endregion

            #region Result
            CreateMap<ResultDTO, Result>()
                .ReverseMap();
            #endregion

            #region UserResponse
            CreateMap<UserResponse, UserResponseDTO>()
                .ReverseMap();
            #endregion

            #region Command
            CreateMap<UserResponse, CreateUserResponseCommand>()
                .ReverseMap();
            #endregion
        }
    }
}
