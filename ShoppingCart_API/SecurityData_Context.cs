using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace ShoppingCart_API
{
    public class SecurityData_Context : IdentityDbContext<IdentityUser>
    {
        public SecurityData_Context(DbContextOptions<SecurityData_Context> options) : base(options)
        {
        }
    }
}
