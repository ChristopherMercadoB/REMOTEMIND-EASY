using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Sentiment { get; set; }
        public int? EnterpriseId { get; set; }
        public string UserName { get; set; }
    }
}
