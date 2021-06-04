using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

    public class RegisterPersonContext : DbContext
    {
        public RegisterPersonContext (DbContextOptions<RegisterPersonContext> options)
            : base(options)
        {
        }

        public DbSet<TabApp.Models.Person> Person { get; set; }
    }
