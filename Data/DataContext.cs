using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetEnsekTechChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetEnsekTechChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MeterReading> MeterReadings {get; set;}
    }
}