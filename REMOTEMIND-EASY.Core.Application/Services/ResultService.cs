﻿using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Exceptions;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.Result;
using REMOTEMIND_EASY.Core.Domain.Entities;


namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class ResultService : GenericService<ResultViewModel, ResultSaveViewModel, Result>, IResultService
    {
        private readonly IResultRepository _repository;
        private readonly IUserResponseRepository _userResponseRepository;
        private readonly IMapper _mapper;

        public ResultService(IResultRepository repository, IMapper mapper, IUserResponseRepository userResponseRepository):base(mapper, repository)
        {
            _repository = repository;
            _mapper = mapper;
            _userResponseRepository = userResponseRepository;
        }

        public async Task CreateResult(int userId)
        {
            List<int?> values = new List<int?>();
            var result = await _userResponseRepository.GetAllInclude(new List<string> { "Response" });
            if (!result.Any())
            {
                throw new ApiException("No hay registros");
            }
            result = result.Where(e => e.UserId == userId).Select(x => new UserResponse
            {
                Id = x.Id,
                UserId = x.UserId,
                QuestionId = x.QuestionId,
                ResponseId = x.ResponseId,
                Value = x.Response.Value
            }).ToList();


            foreach (var item in result)
            {
                values.Add(item.Value);
            }

            var total = CalculateStress.Calculate(values);

            var create = await _repository.AddAsync(new Result()
            {
                UserId = userId,
                Name = "Test",
                TotalValue = (int)total
            });
        }

        public async Task<List<ResultViewModel>> GetResultByUser(int userId)
        {
            var results = await _repository.GetAllAsync();
            return results.Where(e=>e.UserId == userId).Select(x=>new ResultViewModel
            {
                Id = x.Id,
                Name = x.Name,
                TotalValue = x.TotalValue,
                UserId = x.UserId,
                Recomendation = StressLevel.GetStressLevel(x.TotalValue)
            }).ToList();
        }
    }
}
