using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SecurityDemo2.Models
{
    public class MyIdentityRolecs : IdentityRole
    {
        public string Description { get; set; }

        public MyIdentityRolecs()
        {

        }

        public MyIdentityRolecs(string role): base(role)
        {

        }
    }
}
