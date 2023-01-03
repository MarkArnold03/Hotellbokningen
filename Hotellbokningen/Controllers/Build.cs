using Hotellbokningen.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen.Controllers
{
    public class Build
    {
        public HotelDatabase BuildApp()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();

            
            var options = new DbContextOptionsBuilder<HotelDatabase>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new HotelDatabase(options.Options))
            {
               
                var dataInitializer = new DataInitializer();
                dataInitializer.MigrateAndSeed(dbContext);
               

                dbContext.Database.Migrate();
            }

            var dbContextReturned = new HotelDatabase(options.Options);
            return dbContextReturned;
        }
    }
}
