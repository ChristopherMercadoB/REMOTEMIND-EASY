using REMOTEMIND_EASY.Core.Domain.Common;

namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Questions 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<UserResponse> UserResponses { get; set; }
    }
}
