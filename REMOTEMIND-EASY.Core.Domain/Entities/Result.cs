using REMOTEMIND_EASY.Core.Domain.Common;


namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Result:BaseEntity
    {
        public string Name { get; set; }
        public int TotalValue { get; set; }
        public string? UserId { get; set; }
    }
}
