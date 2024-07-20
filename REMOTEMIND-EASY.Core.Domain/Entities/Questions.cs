using REMOTEMIND_EASY.Core.Domain.Common;

namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Questions:BaseEntity
    {
        public string Description { get; set; }
        public List<Responses> Responses { get; set; }
    }
}
