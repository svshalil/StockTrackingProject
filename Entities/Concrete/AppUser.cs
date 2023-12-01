using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<long>
    {
        public string? FirstName { get; set; }
        public string? SurName { get; set; }
        public string? Picture { get; set; }
    }
}
