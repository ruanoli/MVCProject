using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Context
{
    public class AppContatoDbContext : DbContext
    {
        public AppContatoDbContext(DbContextOptions<AppContatoDbContext> options) : base (options)
        {
            
        }

        public DbSet<Contato>? Contatos {get; set;}
    }
}