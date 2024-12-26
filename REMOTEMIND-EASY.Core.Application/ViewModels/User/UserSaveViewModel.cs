using REMOTEMIND_EASY.Core.Application.ViewModels.Role;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace REMOTEMIND_EASY.Core.Application.ViewModels.User
{
    public class UserSaveViewModel
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]

        public string Username { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coiciden")]
        [Required(ErrorMessage = "Debe colocar una contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]

        public int RoleId { get; set; }
        [NotMapped]
        public List<RoleViewModel>? Roles { get; set; }

    }
}
