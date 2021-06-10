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
        builder.Entity<Item>().HasMany(x => x.Repair).WithOne(x => x.Item).HasForeignKey(x => x.ItemID).IsRequired();
        builder.Entity<Person>().HasMany(x => x.SendMessage).WithOne(x => x.Sender);
        builder.Entity<Person>().HasMany(x => x.ReciveMessage).WithOne(x => x.Addressee);
    }

    public DbSet<TabApp.Models.Person> Person { get; set; }

    public DbSet<TabApp.Models.Worker> Worker { get; set; }

    public DbSet<TabApp.Models.PersonWorker> PersonWorker { get; set; }

    public DbSet<TabApp.Models.Invoice> Invoice { get; set; }

    public DbSet<TabApp.Models.Repair> Repair { get; set; }

    public DbSet<TabApp.Models.Service> Service { get; set; }

    public DbSet<TabApp.Models.Item> Item { get; set; }
}
