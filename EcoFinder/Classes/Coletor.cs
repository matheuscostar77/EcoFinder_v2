using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder
{
    internal class Coletor : Pessoa
    {
        private int quantidadeColetas;

        public Coletor()
        {
            quantidadeColetas = 0;
        }

        public void setQuantidadeColetas(int quantidadeColetas) 
        {
            this.quantidadeColetas= quantidadeColetas;
        }

        public int getQuantidadeColetas()
        {
            return quantidadeColetas;
        }

        public void verChamados()
        {

        }

        public void reservarChamados()
        {

        }
    }
}
