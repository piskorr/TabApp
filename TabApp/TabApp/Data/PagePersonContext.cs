using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

    public class PagePersonContext : DbContext
    {
        public PagePersonContext (DbContextOptions<PagePersonContext> options)
            : base(options)
        {
        }

        public DbSet<TabApp.Models.Person> Person { get; set; }

        public DbSet<TabApp.Models.Worker> Worker { get; set; }

        public DbSet<TabApp.Models.PersonWorker> PersonWorker { get; set; }
    }
