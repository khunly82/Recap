using Microsoft.EntityFrameworkCore;
using Recap.DAL.Configurations;
using Recap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.DAL
{
    public class MyContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<CalendarEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalendarEventConfiguration());
        }
    }
}
