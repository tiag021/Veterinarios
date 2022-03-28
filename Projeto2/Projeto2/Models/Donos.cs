namespace Projeto2.Models
{
    public class Donos
    {
        public Donos()
        {
            //Inicializacao obrigatoria devido a utilizacao de "ICollection"
            Animais = new HashSet<Animais>();
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        //Como nao utiliza aritmerica algebrica o valor e guardado como um conjunto de inteiros
        public string NIF { get; set; }

        //Contem apenas 'M'asculino ou 'F'eminino
        //Deve apenas conter 1 caracter
        public string Sex { get; set; }

        //Devolve os animais de um dado um dono
        //Nao e necessario para o funcionamento da base de dados
        public ICollection<Animais> Animais { get; set; }
    }
}