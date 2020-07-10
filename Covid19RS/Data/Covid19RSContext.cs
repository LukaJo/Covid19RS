using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Covid19RS.Models
{
    public class Covid19RSContext : DbContext
    {
        public Covid19RSContext (DbContextOptions<Covid19RSContext> options)
            : base(options)
        {
        }

        public DbSet<Covid19RS.Models.Covid19> Covid19 { get; set; }
    }
}
