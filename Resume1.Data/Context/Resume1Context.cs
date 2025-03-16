using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Resume1.domain.Models.Auth;

//using Resume1.Domain
using Resume1.Data.Context;

namespace Resume1.Data.Context
{
    public class Resume1Context:DbContext
    {
        public Resume1Context(DbContextOptions<Resume1Context> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
    }
}
 