using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT_MITROI_DANIELA_MONICA
{
    class SondajClass
    {
        private Companie companie;
        private short fericire;
        private short prietenie;
        private short remunerare;
        private bool suprasolicitat;
        private bool conteazaOpinia;
        private bool schimbareProfesie;

        public SondajClass(Companie companie, short fericire, short prietenie, short remunerare, bool suprasolicitat, bool conteazaOpinia, bool schimbareProfesie)
        {
            this.companie = companie;
            this.fericire = fericire;
            this.prietenie = prietenie;
            this.remunerare = remunerare;
            this.suprasolicitat = suprasolicitat;
            this.conteazaOpinia = conteazaOpinia;
            this.schimbareProfesie = schimbareProfesie;
        }

        public short Fericire { get => fericire; set => fericire = value; }
        public short Prietenie { get => prietenie; set => prietenie = value; }
        public short Remunerare { get => remunerare; set => remunerare = value; }
        public bool Suprasolicitat { get => suprasolicitat; set => suprasolicitat = value; }
        public bool ConteazaOpinia { get => conteazaOpinia; set => conteazaOpinia = value; }
        public bool SchimbareProfesie { get => schimbareProfesie; set => schimbareProfesie = value; }
        internal Companie Companie { get => companie; set => companie = value; }

        public override string ToString()
        {
            return "C: " + companie.Denumire + ",F: " + fericire + ",P: " +
                prietenie + ",R: " + remunerare + ",S: " +
                suprasolicitat + ",O: " + conteazaOpinia + ",SP: " + schimbareProfesie;
        }
    }
}
