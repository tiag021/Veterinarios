using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto2.Models
{
    public class Consultas
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Observacoes { get; set; }

        public decimal Preco { get; set; }

        [ForeignKey(nameof(Animais))]

        public int AnimaisFK { get; set; }

        public Animais Animais { get; set; }
    }
}
