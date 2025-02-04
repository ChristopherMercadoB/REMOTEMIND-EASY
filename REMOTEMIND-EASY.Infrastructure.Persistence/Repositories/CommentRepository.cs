using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Repositories
{
    public class CommentRepository:GenericRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationContext _context;

        public CommentRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public Task<List<Comment>> GetAllIncludeAsync(List<string> props)
        {
            var query = _context.Set<Comment>().AsQueryable();
            if (props != null || props.Count != 0)
            {
                foreach (var item in props)
                {
                    query = query.Include(item);
                }
            }

            return query.ToListAsync();
        }
    }
}
