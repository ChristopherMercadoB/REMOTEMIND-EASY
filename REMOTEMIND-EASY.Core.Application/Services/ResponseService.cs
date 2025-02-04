using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.Response;
using REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class ResponseService : GenericService<ResponseViewModel, ResponseSaveViewModel, Responses>, IResponseService
    {
        private readonly IResponseRepository _repository;
        private readonly IMapper _mapper;

        public ResponseService(IResponseRepository repository, IMapper mapper):base(mapper, repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
