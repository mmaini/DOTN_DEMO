using Microsoft.AspNetCore.Identity;

namespace DOTN_DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
