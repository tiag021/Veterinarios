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

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Species { get; set; }

        public DateTime BrithDate { get; set; }

        public double Weight { get; set; }

        public string Photo { get; set; }


        //Relacoes
        // [] e usado para fazer anotacoes
        [ForeignKey(nameof(Dono))]  //[ForeignKey("Dono")]
        public int DonoFK { get; set; }
        public Donos Dono { get; set; }

        public ICollection<Consultas> Consultas { get; set; }

    }
}