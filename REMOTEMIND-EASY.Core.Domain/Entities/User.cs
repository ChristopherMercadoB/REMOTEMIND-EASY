﻿using REMOTEMIND_EASY.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int TestDone { get; set; }
        public int? EnterpriseId { get; set; }
        public Role Role { get; set; }
        public List<Result> Results { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
