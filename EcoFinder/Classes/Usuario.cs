using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Usuario : Pessoa
    {
        Pessoa p = new Pessoa();
        Endereco endereco;

        public Usuario()
        {
            this.endereco = new Endereco(p);
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
