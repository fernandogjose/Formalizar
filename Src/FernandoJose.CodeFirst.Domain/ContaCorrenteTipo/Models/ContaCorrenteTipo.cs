using System.Collections.ObjectModel;

namespace FernandoJose.CodeFirst.Domain.ContaCorrenteTipo.Models
{
    public class ContaCorrenteTipo
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Sigla { get; set; }

        public Collection<ContaCorrente.Models.ContaCorrente> ContaCorrentes { get; set; }
    }
}
