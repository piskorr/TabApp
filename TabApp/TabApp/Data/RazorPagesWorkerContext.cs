using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

    public class RazorPagesWorkerContext : DbContext
    {
        public RazorPagesWorkerContext (DbContextOptions<RazorPagesWorkerContext> options)
            : base(options)
        {
        }

        public DbSet<TabApp.Models.Worker> Worker { get; set; }
    }
