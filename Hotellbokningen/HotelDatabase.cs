﻿using Hotellbokningen.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotellbokningen
{
    public class HotelDatabase : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HotelBooking> Bookings { get; set; }
        public HotelDatabase()
        {

        }

        public HotelDatabase(DbContextOptions<HotelDatabase> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelBookingen;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
            }
           
        }
    }
}
