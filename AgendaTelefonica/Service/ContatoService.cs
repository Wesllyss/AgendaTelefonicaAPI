using AgendaTelefonica.Interfaces;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Services
{
    public class ContatoService
    {
        private IContatoRepository _repository;

        public ContatoService(IContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Contato>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Contato?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Contato contato)
        {
            if (string.IsNullOrWhiteSpace(contato.nome))
            {
                throw new Exception("O nome do contato é obrigatório. ");
            }
            
            await _repository.AddAsync(contato);
        }

        public async Task UpdateAsync(Contato contato)
        {
            if (await _repository.ContatoExistsAsync(contato.ContatoId))
            {
                await _repository.UpdateAsync(contato);
            }

            else
            {
                throw new Exception("Contato não encontrado.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            if (await _repository.ContatoExistsAsync(id))
            {
                await _repository.DeleteAsync(id);
            }
            else
            {
                throw new Exception("Contato não encontrado.");
            }
        }
    }
}