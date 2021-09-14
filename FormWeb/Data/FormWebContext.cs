using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FormWeb.Models;

namespace FormWeb.Data
{
    public class FormWebContext : DbContext
    {
        public FormWebContext (DbContextOptions<FormWebContext> options)
            : base(options)
        {
            
        }

        public DbSet<FormWeb.Models.Pessoa> Pessoa { get; set; }
    }
}
