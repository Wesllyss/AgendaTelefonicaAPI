using AgendaTelefonica.Models;
using Microsoft.EntityFrameworkCore;


namespace AgendaTelefonica.context
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options) 
            : base(options)
        {
        }

        public DbSet<Contato> Contatos { get ; set; } = null!;
    }
}