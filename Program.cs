using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Aplicatie pentru gestiunea unor sondaje realizate cu scopul 
 * de a vedea satifactia angajatilor din firmele IT la locul de munca 
 * 
 * Aplicatia va avea 3 clase principale:
 * 1) Unitate - datele criptate ale persoanelor care raspund la sondaj 
 * 1'') Unitate - reprezinta firma pusa in discutie, participanta la sondaj - tine de admin
 * 2) MatriceObservatii - media obervatiilor oferite de angajatii pe fiecare firma - tine de admin - ajuta la reprezentari grafice
 * 3) Sondaj - clasa cu elementele la care raspund angajatii
 */
namespace PROIECT_MITROI_DANIELA_MONICA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
