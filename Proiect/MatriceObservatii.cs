using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROIECT_MITROI_DANIELA_MONICA
{
    //voi avea doua grafice pentru fiecare firma - unul cu mediile pt raspuns de tip 1 - 5
    //si unul cu numarul de persoane care raspund cu da - respectiv nu la cele de tip bool

    class MatriceObservatii // clasa care va ajuta la memorarea mediilor datelor sondajelor pentru fecare firma
    {
        private string denumireCompanie;

        private float medieFericire;
        private float mediePrietenie;
        private float medieRemunerare;

        private int nrPersSuprasolicitate;
        private int nrPersConteazaOpinia;
        private int nrPersSchimbaProfesia;

        public MatriceObservatii() { }

        public MatriceObservatii(string denumireCmp)
        {
            this.denumireCompanie = denumireCmp;

            this.medieFericire = 0;
            this.mediePrietenie = 0;
            this.medieRemunerare = 0;

            this.nrPersSuprasolicitate = 0;
            this.nrPersConteazaOpinia = 0;
            this.nrPersSchimbaProfesia = 0;
        }

        public MatriceObservatii(string dnmCmp, float medieFericire, float mediePrietenie, float medieRemunerare, int nrPersSuprasolicitate, int nrPersConteazaOpinia, int nrPersSchimbaProfesia)
        {
            this.denumireCompanie = dnmCmp;
            this.medieFericire = medieFericire;
            this.mediePrietenie = mediePrietenie;
            this.medieRemunerare = medieRemunerare;
            this.nrPersSuprasolicitate = nrPersSuprasolicitate;
            this.nrPersConteazaOpinia = nrPersConteazaOpinia;
            this.nrPersSchimbaProfesia = nrPersSchimbaProfesia;
        }

        public float MedieFericire { get => medieFericire; set => medieFericire = value; }
        public float MediePrietenie { get => mediePrietenie; set => mediePrietenie = value; }
        public float MedieRemunerare { get => medieRemunerare; set => medieRemunerare = value; }
        public int NrPersSuprasolicitate { get => nrPersSuprasolicitate; set => nrPersSuprasolicitate = value; }
        public int NrPersConteazaOpinia { get => nrPersConteazaOpinia; set => nrPersConteazaOpinia = value; }
        public int NrPersSchimbaProfesia { get => nrPersSchimbaProfesia; set => nrPersSchimbaProfesia = value; }
        public string DenumireCompanie { get => denumireCompanie; set => denumireCompanie = value; }

        public override string ToString()
        {
            return "Compania " + denumireCompanie + " are:\n" + "\nMedie nivel al fericirii: "
                + medieFericire + "\nMedie nivel al prieteniei cu colegii de munca: " + mediePrietenie
                + "\nMedie nivel al satisfacerii remunerarii: " + medieRemunerare + "\nNumar persoane suprasolicitate: "
                + nrPersSuprasolicitate + "\nNumar persoane care simt ca opinia lor conteaza: " + NrPersConteazaOpinia
                + "\nNumar persoane care s-au gandit cel putin o data sa se reprofileze: " + NrPersSchimbaProfesia;
        }
    }
}
