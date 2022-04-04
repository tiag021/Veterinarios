using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto2.Models
{
    public class Consultas
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Obs{ get; set; }

        public decimal Preco { get; set; }


        //Relacoes
        [ForeignKey(nameof(Animal))]
        public int AnimalFK { get; set; }
        public Animais Animal { get; set; }


        [ForeignKey(nameof(Veterinario))]
        public int VeterinarioFK { get; set; }
        public Vets Veterinario { get; set; }
    }
}