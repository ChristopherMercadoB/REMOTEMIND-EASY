using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EnterpriseId { get; set; }
        public string  Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        //public int TestsDone { get; set; }
        //public int PromTests { get; set; }
        //public int? EmployeeId { get; set; }


    }
}
