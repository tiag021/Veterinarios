using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto2.Models
{
    public class Animais
    {

        public Animais()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string raca { get; set; }

        public string especies { get; set; }

        public DateTime aniversario { get; set; }

        public double weight { get; set; }

        public string foto { get; set; }
        
       [ForeignKey(nameof(Donos))] //[ForeignKey("Donos")]
        public int DonosFK { get; set; }

        public Donos Donos { get; set; }
    }
}
