using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data;

namespace BlazorApp1.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        } 
        public DbSet<BlazorApp1.Data.CustomerMaster> CustomerMaster { get; set; }
    }
}
