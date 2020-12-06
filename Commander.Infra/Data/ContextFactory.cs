
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Commander.Infra.Data
 {
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
           
            var connString = AppConfig.Config.GetConnectionString("DefaultConnection");

            builder.UseMySql(
                       connString,
                        new MySqlServerVersion(new Version(8, 0, 21)),
                        mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            return new ApplicationContext(builder.Options);
        }
   }

 }
