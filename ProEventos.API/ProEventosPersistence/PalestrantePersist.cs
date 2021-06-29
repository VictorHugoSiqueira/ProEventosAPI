using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Persistence.Contratos;

namespace ProEventosPersistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        
        private readonly ProEventosContext context;
        public PalestrantePersist(ProEventosContext context)
        {
            this.context = context;
      
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes;

            query = query.OrderBy(e=>e.Id);


            if (includeEventos)
            {
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);   
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {

            IQueryable<Palestrante> query = context.Palestrantes;
            query = query.OrderBy(p => p.Id);


            if (includeEventos)
            {
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            }
            query = query.OrderBy(p=>p.Id)
                .Where(p=>p.Nome.ToLower().Contains(nome.ToLower));
            
            return await query.ToArrayAsync();

        }
        public async Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos)
        {

            IQueryable<Palestrante> query = context.Palestrantes;
            query = query.OrderBy(p => p.Id);


            if (includeEventos)
            {
                query.Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);

            }
            query = query.OrderBy(p => p.Id).Where(p=>p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}
