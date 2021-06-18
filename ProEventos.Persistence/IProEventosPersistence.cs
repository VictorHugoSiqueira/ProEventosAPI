using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence
{
    public interface IProEventosPersistence
    {
        //geral
        void Add<T>(T entity) where T: class;
        
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;
            
        void DeleteRange<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //EVENTOS

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);

        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);

        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes);

        //PALESTRANTES

        Task<Palestrante[]> GetAllPalestrantesByTemaAsync(string nome, bool includeEventos);

        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);

        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);

    }
}
