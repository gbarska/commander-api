using Commander.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt): base(opt)
        {
        }
       public DbSet<Command> Commands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);

          modelBuilder.Entity<Command>(eb =>
            {
                eb.Property(e => e.HowTo).HasColumnType("nvarchar(5000)").IsRequired();
                eb.Property(e => e.Line).HasColumnType("nvarchar(5000)").IsRequired();
                eb.Property(e => e.Platform).HasColumnType("nvarchar(5000)").IsRequired();
            });
        }

    }
}