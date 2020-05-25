using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FaceShop.Repository
{
    public class SqlServerDbContext : DbContext 
    {
        public string ConnectionString { get; set; }

        public string AppConfigName { get; set; } = "appsettings.json";

        public SqlServerDbContext()
        {
        }

        public SqlServerDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(this.AppConfigName).Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(this.ConnectionString), (Action<SqlServerDbContextOptionsBuilder>)null);
        }
    }
}
