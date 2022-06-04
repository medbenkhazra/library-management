using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_V3
{
    class Ouvrage
    {
        private DateTime dateEmp;
        private string etat;
        private int numeroOuvage;


        // private string id;

        public Ouvrage(DateTime dateEmp, string etat,int numeroOuvage)
        {
            this.DateEmp = dateEmp;
            this.Etat = etat;
            this.numeroOuvage = numeroOuvage;
            // this.id = id;
        }



        
        public DateTime DateEmp { get => dateEmp; set => dateEmp = value; }
        public int NumeroOuvage { get => numeroOuvage; set => numeroOuvage = value; }
        public string Etat { get => etat; set => etat = value; }

        public virtual void toString()
        {
            Console.WriteLine("date d'emprunte:" + DateEmp + ", ETAT:" + etat);
            Console.WriteLine();
        }
    }
}
