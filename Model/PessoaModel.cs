using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Model
{
    public class PessoaModel
    {
        public int pessoaId { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public int cargoid { get; set; }
        public CargoModel cargo { get; set; }
    }
}
