using AgendaTelefonica.Models;
using AgendaTelefonica.Interfaces;
using Microsoft.EntityFrameworkCore;
using AgendaTelefonica.context;

namespace AgendaTelefonica.Repositores
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ContatoContext _context;
        public ContatoRepository ( ContatoContext context)
        {
            
            _context = context;
        }

        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            return await _context.Contatos.ToListAsync();
        }
        
        public async Task<Contato?> GetByIdAsync(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task AddAsync(Contato contato)
        {
            _context.Contatos.Add(contato);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ContatoExistsAsync(int id)
        {
            return await _context.Contatos.AnyAsync(c => c.ContatoId == id);
        }
    }
}