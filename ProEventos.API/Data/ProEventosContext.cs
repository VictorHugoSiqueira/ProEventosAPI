using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Persistence
{
    public class ProEventosContext : DbContext
    {

        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        
        public DbSet<Evento> Eventos { get; set; }
    }
}
