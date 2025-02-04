using System.ComponentModel.DataAnnotations;

namespace REMOTEMIND_EASY.Core.Application.ViewModels.Question
{
    public class QuestionSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Title { get; set; }
    }
}
