using REMOTEMIND_EASY.Core.Application.ViewModels.Response;
using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.ViewModels.UserResponse
{
    public class UserResponseSaveViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        [Required(ErrorMessage = "Favor llenar este campo")]
        public int ResponseId { get; set; }
        public int UserId { get; set; }
        public List<ResponseViewModel> Responses { get; set; }
    }
}
