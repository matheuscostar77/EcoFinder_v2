using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoFinder
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 
        
        [STAThread]
        static void Main()
        {
            Pessoa pessoa = new Pessoa();
            Endereco endereco = new Endereco(pessoa);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin(pessoa, endereco));
         }
    }
}
