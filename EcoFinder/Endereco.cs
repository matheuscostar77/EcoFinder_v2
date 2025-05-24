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

        public Endereco() { }

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
        
        public string exibirEndereco()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat($" Rua: {nomeRua} \n N° Casa: {numeroCasa} \n Nome Bairro: {nomeBairro} \n Cidade: {cidade} ");

            return sb.ToString();
        }

    }
}
