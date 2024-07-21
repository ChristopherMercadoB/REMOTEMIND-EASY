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
    public class ResponseRepository : GenericRepository<Responses>, IResponseRepository
    {
        private readonly ApplicationContext _context;

        public ResponseRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }
    }
}
