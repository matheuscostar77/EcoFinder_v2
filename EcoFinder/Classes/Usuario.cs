using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Usuario : Pessoa
    {
        Pessoa pessoa;
        Endereco endereco;

        public Usuario(Pessoa pessoa, Endereco endereco)
        {
            this.endereco = endereco;
            this.pessoa = pessoa;
        }


        

    }
}
