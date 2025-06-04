using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Material
    {
        private int id_material = 0;
        private string tipoMateria="";

        public Material(){}

        public int getId_material()
        {
            return id_material;
        }
        public void setId_material(int id_material)
        {
            this.id_material = id_material;
        }
        public string getTipoMaterial()
        {
            return tipoMateria;
        }
        public void setTipoMateria(string tipoMateria)
        {
            this.tipoMateria = tipoMateria;
        }
    }
}
