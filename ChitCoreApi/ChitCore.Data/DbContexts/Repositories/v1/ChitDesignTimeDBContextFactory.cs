using ChitCore.Data.v1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChitCore.Data.DbContexts.Repositories.v1
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ChitDbContext>
    {
        public ChitDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ChitDbContext>();

            var connectionString = configuration.GetConnectionString("chitConnectionString");

            builder.UseSqlServer(connectionString);

            return new ChitDbContext(builder.Options);
        }
    }
}
