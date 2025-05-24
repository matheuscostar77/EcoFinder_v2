using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Pessoa
    {
        protected string name;
        protected string email;
        protected string sex;
        protected string senha;

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }
        public string getEmail()
        {
            return email;
        }

        public void setEmail()
        {
            this.email = email;
        }

        public string getSex()
        {
            return sex;
        }

        public void conferirSenhaIgual(string confirmarSenha)
        {

        }
    }
}
