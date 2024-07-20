using REMOTEMIND_EASY.Core.Domain.Common;

namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Responses:BaseEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string? UserId { get; set; }
        public List<Questions> Questions { get; set; }
    }
}
