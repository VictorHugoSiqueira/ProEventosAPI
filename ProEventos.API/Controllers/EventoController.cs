using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Persistence;
using ProEventos.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EventoController : ControllerBase
    {

        private readonly ProEventosContext _context;

        public EventoController(ProEventosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }
        
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }

        [HttpPost]
        public string Post()
        {
            return "exemplo de post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"exemplo Put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "exemplo delete";
        }
    }
}