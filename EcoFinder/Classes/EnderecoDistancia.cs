using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder.Classes
{
    public class EnderecoDistancia
    {
        private int idEndereco;
        private double distancia;

        public void setIdEndereco(int idEndereco)
        {
            this.idEndereco = idEndereco;
        }

        public int getIdEndereco()
        {
            return this.idEndereco;
        }

        public void setDistancia(double distancia)
        {
            
            this.distancia = distancia;
            
        }

        public double getDistancia()
        {
            return distancia;
        }
    }
}
