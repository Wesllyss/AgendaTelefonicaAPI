
namespace AgendaTelefonica.Models
{
    public class Contato
    {   

        public required int ContatoId { get; set;}
        public required string nome { get; set; }
        public  string? Telefone { get; set; }
        public string? Endereco { get; set; }

    }
}