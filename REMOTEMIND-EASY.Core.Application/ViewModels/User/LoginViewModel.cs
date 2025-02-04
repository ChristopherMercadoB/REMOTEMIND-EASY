using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Este campo no puede ser nulo")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo no puede ser nulo")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool HasError { get; set; } = false;
        public string? Error { get; set; }
    }
}
