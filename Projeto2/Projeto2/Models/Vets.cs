namespace Projeto2.Models
{
    public class Vets
    {

        public Vets()
        {
            Consulta = new HashSet<Consultas>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string NLicencaProfissional { get; set; }

        public String Photo { get; set; }


        public ICollection<Consultas> Consulta { get; set; }


    }
}
