using AutoMapper;
using REMOTEMIND_EASY.Core.Application.DTO_S.Questions;
using REMOTEMIND_EASY.Core.Application.DTO_S.Responses;
using REMOTEMIND_EASY.Core.Application.DTO_S.Result;
using REMOTEMIND_EASY.Core.Application.DTO_S.UserResponse;
using REMOTEMIND_EASY.Core.Application.Features.UserResponses.Command;
using REMOTEMIND_EASY.Core.Application.ViewModels.Question;
using REMOTEMIND_EASY.Core.Application.ViewModels.Response;
using REMOTEMIND_EASY.Core.Application.ViewModels.Role;
using REMOTEMIND_EASY.Core.Application.ViewModels.User;
using REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse;
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

            CreateMap<Questions, QuestionViewModel>()
                .ReverseMap();

            CreateMap<Questions, QuestionSaveViewModel>()
                .ReverseMap();
            #endregion

            #region Responses
            CreateMap<Responses, ResponsesDTO>()
                .ReverseMap();

            CreateMap<Responses, ResponseViewModel>()
                .ReverseMap();

            CreateMap<Responses, ResponseSaveViewModel>()
                .ReverseMap();
            #endregion

            #region Result
            CreateMap<ResultDTO, Result>()
                .ReverseMap();
            #endregion

            #region UserResponse
            CreateMap<UserResponse, UserResponseDTO>()
                .ReverseMap();

            CreateMap<UserResponse, UserResponseSaveViewModel>()
                .ReverseMap();

            CreateMap<UserResponse, UserResponseViewModel>()
                .ReverseMap();
            #endregion

            #region User
            CreateMap<User, UserSaveViewModel>()
               .ReverseMap();

            CreateMap<User, UserViewModel>()
               .ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleViewModel>()
               .ReverseMap();
            #endregion

            #region Command
            CreateMap<UserResponse, CreateUserResponseCommand>()
                .ReverseMap();
            #endregion
        }
    }
}
