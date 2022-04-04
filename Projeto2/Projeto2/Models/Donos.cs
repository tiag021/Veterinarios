using System.ComponentModel.DataAnnotations;

namespace Projeto2.Models

{
    /// <summary>
    /// Descreve os dados do dono
    /// </summary>
    /// 
    public class Donos
    {
        public Donos()
        {
            //Inicializacao obrigatoria devido a utilizacao de "ICollection"
            Animais = new HashSet<Animais>();
        }

        /// <summary>
        /// Chave primário para a tabela Donos
        /// </summary>
        public int Id { get; set; }

        //Campo obrigaório
        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(30, ErrorMessage ="Máximo 30 carateres")]
        //[RegularExpression("[A-Z][a-záéíóúàèìòùãõõâêîôûäëïöüç]+( [A-Z][a-záéíóúàèìòùãõõâêîôûäëïöüç]+)*", ErrorMessage = "{0} inválido")]
        [RegularExpression("[A-ZÂÊÎÔÛÁÉÍÓÚÀÈÌÒÙÃÕÄËÏÖÜa-záéíóúàèìòùãõâêîôûäëïöüç -']+", ErrorMessage = "{0} inválido")]
        [Display(Name ="Nome")]
        /// <summary>
        /// Nomne do Dono do cão
        /// </summary>
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [StringLength(9, ErrorMessage = "O {0} tem de ter 9 carateres", MinimumLength = 9)]
        [RegularExpression("[123578][0-9]{8}", ErrorMessage = "{0} inválido")]
        /// <summary>
        /// Numero NIF
        /// </summary>
        //Como nao utiliza aritmerica algebrica o valor e guardado como um conjunto de inteiros
        public string NIF { get; set; }

        [StringLength(1, ErrorMessage = "O {0} não pode ter mais de 1 caráter")]
        [Display(Name = "Sexo")]
        [RegularExpression("[MmFf]", ErrorMessage = "O {0} só pode conter M ou F")]
        //Tem de ser string pois o entity framework não reconhece caracteres
        /// <summary>
        /// 'M'asculino ou 'F'eminino
        /// </summary>
        public string Sexo { get; set; }

        //Devolve os animais de um dado um dono
        //Nao e necessario para o funcionamento da base de dados
        public ICollection<Animais> Animais { get; set; }

    }
}