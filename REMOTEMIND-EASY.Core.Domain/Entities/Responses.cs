using REMOTEMIND_EASY.Core.Domain.Common;

namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Responses
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }
        public List<Questions> Questions { get; set; }
    }
}
