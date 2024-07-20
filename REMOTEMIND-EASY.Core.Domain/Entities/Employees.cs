using REMOTEMIND_EASY.Core.Domain.Common;


namespace REMOTEMIND_EASY.Core.Domain.Entities
{
    public class Employees:BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
