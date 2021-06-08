using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

public class PagePersonContext : DbContext
{
    public PagePersonContext(DbContextOptions<PagePersonContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<Message>().HasOne(x => x.Addressee).WithMany(x => x.ReciveMessage);
        //builder.Entity<Message>().HasOne(x => x.Sender).WithMany(x => x.SendMessage);

        builder.Entity<Person>().HasMany(x => x.SendMessage).WithOne(x => x.Sender);
        builder.Entity<Person>().HasMany(x => x.ReciveMessage).WithOne(x => x.Addressee);

    }

    public DbSet<TabApp.Models.Person> Person { get; set; }

    public DbSet<TabApp.Models.Worker> Worker { get; set; }

    public DbSet<TabApp.Models.PersonWorker> PersonWorker { get; set; }

    public DbSet<TabApp.Models.Invoice> Invoice { get; set; }
}
