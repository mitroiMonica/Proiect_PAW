using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT_MITROI_DANIELA_MONICA
{
    public class DateConectare : IComparable
    {
        private string username;
        private string parola;
        private bool dejaCompletat;

        public DateConectare(string username, string parola)
        {
            this.username = username;
            this.parola = parola;
            this.dejaCompletat = false;
        }
        public DateConectare(string linie)
        {
            this.username = linie.Split(',')[0];
            this.parola = linie.Split(',')[1];
            this.dejaCompletat = false;
        }

        public string Username { get => username; set => username = value; }
        public string Parola { get => parola; set => parola = value; }
        public bool DejaCompletat { get => dejaCompletat; set => dejaCompletat = value; }

        public int CompareTo(object obj)
        {
            DateConectare dt = (DateConectare)obj;
            if (dt.Username == this.Username && dt.Parola == this.Parola)
                return 0;
            else
                return 1;
        }
    }
}
