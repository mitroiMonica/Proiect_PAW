using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT_MITROI_DANIELA_MONICA
{
    class Companie : IComparable, ICloneable
    {
        private string denumire;
        private bool multinationala;
        private int numar_angajati;
        public Companie(string denumire, bool multinationala, int numar_angajati)
        {
            this.denumire = denumire;
            this.multinationala = multinationala;
            this.numar_angajati = numar_angajati;
        }

        public Companie()
        {
            this.denumire = " - ";
            this.multinationala = false;
            this.numar_angajati = 0;
        }


        public Companie(string linie)
        {
            this.denumire = linie.Split(',')[0];
            this.multinationala = Convert.ToBoolean(linie.Split(',')[1]);
            this.numar_angajati = Convert.ToInt32(linie.Split(',')[2]);
        }

        public string Denumire { get => denumire; set => denumire = value; }
        public bool Multinationala { get => multinationala; set => multinationala = value; }
        public int Numar_angajati { get => numar_angajati; set => numar_angajati = value; }

        public override string ToString()
        {
            return this.denumire;
        }

        public int CompareTo(object obj)
        {
            if (this.denumire == ((Companie)obj).denumire)
                return 0;
            else
                return -1;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
