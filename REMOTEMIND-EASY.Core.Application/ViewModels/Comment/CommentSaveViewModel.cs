using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.ViewModels.Comment
{
    public class CommentSaveViewModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Este campo es requerido")]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Sentiment { get; set; }
        public int? EnterpriseId { get; set; }
    }
}
