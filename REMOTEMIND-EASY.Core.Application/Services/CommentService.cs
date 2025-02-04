using AutoMapper;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.ViewModels.Comment;
using REMOTEMIND_EASY.Core.Domain.Entities;


namespace REMOTEMIND_EASY.Core.Application.Services
{
    public class CommentService :GenericService<CommentViewModel, CommentSaveViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMachineLearningService _machineLearningService;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IMachineLearningService machineLearningService, IMapper mapper):base(mapper, repository)
        {
            _repository = repository;
            _machineLearningService = machineLearningService;
            _mapper = mapper;
        }

        public async Task CreateComment(CommentSaveViewModel vm, string path)
        {
            var Comment = new Comment()
            {
                EmployeeId = vm.EmployeeId,
                EnterpriseId = vm.EnterpriseId,
                Text = vm.Text,
                Date = DateTime.Now,
                Sentiment = _machineLearningService.GetSentiment(vm.Text, path)
            };

            await _repository.AddAsync(Comment);
        }

        public async Task<List<CommentViewModel>> GetAllCommentsByEnterprise(int? enterpriseId)
        {

            var comments = await _repository.GetAllIncludeAsync(new List<string> { "User"});
            return comments.Where(e => e.EnterpriseId == enterpriseId).Select(x => new CommentViewModel
            {
                EnterpriseId = x.EnterpriseId,
                Text = x.Text,
                Date = x.Date,
                EmployeeId = x.EmployeeId,
                Sentiment = x.Sentiment,
                UserName = x.User.Name

            }).OrderByDescending(e=>e.Date).ToList();
        }
    }
}
