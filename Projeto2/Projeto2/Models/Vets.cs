using System.ComponentModel.DataAnnotations;

namespace Projeto2.Models
{
    /// <summary>
    /// data from Vets
    /// </summary>
    public class Vets
    {
        public Vets()
        {
            Consulta = new HashSet<Consultas>();
        }
        /// <summary>
        /// pk for vets
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the vet
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// professional license of vet
        /// </summary>
        [Display(Name = "N.º Licença profissional")]
        public string NLicencaProfissional { get; set; }

        /// <summary>
        ///name of file that has vet photo
        /// </summary>
        public String Photo { get; set; }


        public ICollection<Consultas> Consulta { get; set; }


    }
}
