using ClienteAPI.Data;
using ClienteAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacionesGeneralesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InformacionesGeneralesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InformacionesGenerales/ListadoGeneral
        [HttpGet("ListadoGeneral")]
        public async Task<ActionResult<IEnumerable<InformacionGeneral>>> GetListadoGeneral()
        {
            return await _context.InformacionesGenerales
                                 .OrderBy(i => i.FechaCreacion)
                                 .ThenBy(i => i.Cliente.Apellidos)
                                 .ToListAsync();
        }
    }
}
