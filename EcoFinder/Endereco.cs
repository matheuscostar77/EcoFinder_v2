using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
{
    internal class Endereco
    {
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFinder
    {
        internal class Endereco
        {
            private string nomeBairro = "";
            private string cidade = "";
            private string nomeRua = "";
            private int numeroCasa = 0;

            public Endereco(string nomeBairro, string cidade, string nomeRua, int numeroCasa)
            {
                this.nomeBairro = nomeBairro;
                this.cidade = cidade;
                this.nomeRua = nomeRua;
                this.numeroCasa = numeroCasa;
            }
            public string getNomeBairro()
            {
                return nomeBairro;
            }
            public void setNomeBairro(string nomeBairro)
            {
                this.nomeBairro = nomeBairro;
            }

            public string getCidade()
            {
                return cidade;
            }
            public void setCidade(string cidade)
            {
                this.cidade = cidade;
            }

            public string getNomeRua()
            {
                return nomeRua;
            }
            public void setNomeRua(string nomeRua)
            {
                this.nomeRua = nomeRua;
            }

            public int getNumeroCasa()
            {
                return numeroCasa;
            }
            public void setNumeroCasa(int numeroCasa)
            {
                this.numeroCasa = numeroCasa;
            }
            
            public void ExibirEndereco()
            {
                {

                }
            }

}
}
