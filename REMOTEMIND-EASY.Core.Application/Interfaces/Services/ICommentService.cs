using REMOTEMIND_EASY.Core.Application.ViewModels.Comment;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Services
{
    public interface ICommentService:IGenericService<CommentViewModel, CommentSaveViewModel, Comment>
    {
        Task CreateComment(CommentSaveViewModel vm, string path);
        Task<List<CommentViewModel>> GetAllCommentsByEnterprise(int? enterpriseId);
    }
}
