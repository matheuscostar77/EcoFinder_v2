
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Chamado
    {
        private string id_chamado = "";
        private string nomeSolicitate="";
        private string tipoMaterial = "";
        private int quantUnitaria = 0;
        private double quantKilograma = 0;
        private Endereco endereco;

        public Chamado()
        {
            Pessoa pessoa = new Pessoa();
            endereco = new Endereco(pessoa);
            tipoMaterial = "";
            quantUnitaria = 0;
            quantKilograma = 0;

        }
        public string getTipoMaterial()
        {
            return tipoMaterial;
        }
        public void setTipoMaterial(string tipoMaterial)
        {
            this.tipoMaterial = tipoMaterial;
        }

        public int getQuantUnitaria()
        {
            return quantUnitaria;
        }
        public void setQuantUnitaria(int quantUnitaria)
        {
            this.quantUnitaria = quantUnitaria;
        }

        public double getQuantKilograma()
        {
            return quantKilograma;
        }
        public void setQuantKilograma(double quantKilograma)
        {
            this.quantKilograma = quantKilograma;
        }

        
    }
}
