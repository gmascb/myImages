using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyImages.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyImages.Data
{
    public class ContextApp : DbContext
    {
        public ContextApp()
            :base()
        {

        }

        public virtual DbSet<ImageModel> Image { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.GetValue(typeof(string), "DbCoreConnectionString");

                optionsBuilder.UseSqlServer((string)connectionString);
            }
        }


    }
}

