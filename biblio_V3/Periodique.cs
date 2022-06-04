using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_V3
{
    class Periodique : Ouvrage
    {
        private string nom;
        private int numero;
        private string periodicite;

        public Periodique(string nom, int numero, string periodicite, DateTime dateEmp, string etat, int numeroOuvrage) : base(dateEmp, etat, numeroOuvrage)
        {
            this.nom = nom;
            this.numero = numero;
            this.periodicite = periodicite;
        }

        public int Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Periodicite { get => periodicite; set => periodicite = value; }

        public override void toString()
        {
            string etat;
           
            Console.WriteLine("le nom :" + Nom + " ,le numero :" + Numero + " ,Periodicite:" + Periodicite + " ,date emprunt : " + DateEmp);
            Console.WriteLine();
        }
    }
}
