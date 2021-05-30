using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDemo2.Models
{
    public class MyIdentityDbContext: IdentityDbContext<MyIdentityUser,MyIdentityRolecs,string>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext>options):base(options)
        {

        }
    }
}
