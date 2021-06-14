using APIDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDapper.Repository
{
    public interface IPessoaRepository
    {
        public IEnumerable<PessoaModel> GetPessoa();
        public IEnumerable<PessoaModel> GetPessoasById(int id);        
        public bool SetPessoa(PessoaModel valores);
        public int GetPessoaId();
    }
}
