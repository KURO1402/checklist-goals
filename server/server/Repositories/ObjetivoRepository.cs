using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Repositories
{
    public class ObjetivoRepository: IObjetivoRepository
    {
        private readonly ApplicationDbContext _context;
        public ObjetivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Objetivo> CrearObjetivoAsync(Objetivo objetivo)
        {
            await _context.Objetivos.AddAsync(objetivo);
            await _context.SaveChangesAsync();
            return objetivo;
        }

        public async Task<List<Objetivo>> ObtenerObjetivosPorUsuarioAsync(int idUsuario)
        {
            return await _context.Objetivos
                .Where(o => o.Id == idUsuario)
                .OrderByDescending(o => o.FechaCreacion)
                .ToListAsync();
        }
    }
}
