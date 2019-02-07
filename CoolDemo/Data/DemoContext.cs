using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoolDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class DemoContext : IdentityDbContext<ApplicationUser>
{
        public DemoContext (DbContextOptions<DemoContext> options)
            : base(options)
        {

        }

        public DbSet<CoolDemo.Models.Pet> Pet { get; set; }
        public DbSet<Owner> Owners { get; set; }
}
