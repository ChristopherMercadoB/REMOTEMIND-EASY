﻿using REMOTEMIND_EASY.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Repositories
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<List<Comment>> GetAllIncludeAsync(List<string> props);
    }
}
