using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuidaTuAbuelo.DataAccess;

namespace CuidaTuAbuelo.Models
{
    public class CuidaTuAbueloContext : DbContext
    {
        public CuidaTuAbueloContext (DbContextOptions<CuidaTuAbueloContext> options)
            : base(options)
        {
        }

        public DbSet<CuidaTuAbuelo.DataAccess.Users> Users { get; set; }

        public DbSet<CuidaTuAbuelo.DataAccess.Products> Products { get; set; }

        public DbSet<CuidaTuAbuelo.DataAccess.Services> Services { get; set; }

        public DbSet<CuidaTuAbuelo.DataAccess.Transactions> Transactions { get; set; }

        public DbSet<CuidaTuAbuelo.DataAccess.Stories> Stories { get; set; }
    }
}
