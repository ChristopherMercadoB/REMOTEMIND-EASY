using Microsoft.AspNetCore.Identity;


namespace REMOTEMIND_EASY.Infrastructure.Identity.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? Identification { get; set; }
    }
}
