using REMOTEMIND_EASY.Core.Domain.Common;


namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalValue { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
