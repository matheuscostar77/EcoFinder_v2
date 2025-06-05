using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Usuario : Pessoa
    {
        Pessoa p;
        Endereco endereco;

        public Usuario(Pessoa p)
        {
            this.endereco = new Endereco(p);
            this.p = p;
        }


        public void cadastrarEndereco()
        {
            
        }

        public void fazerChamado()
        {

        }

        public void mudarEndereco()
        {

        }
    }
}
