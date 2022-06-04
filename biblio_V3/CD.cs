using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_V3
{
    class CDs : Ouvrage
    {
        private string titre;
        private string auteur;

        public CDs(string titre, string auteur, DateTime dateEmp, string etat, int numeroOuvrage) : base(dateEmp, etat, numeroOuvrage)
        {
            this.titre = titre;
            this.auteur = auteur;
        }

        public string Titre { get => titre; set => titre = value; }
        public string Auteur { get => auteur; set => auteur = value; }
        public override void toString()
        {
            string etat;
          
            Console.WriteLine("l'auteur :" + Auteur + " ,le titre :" + Titre + " ,date emprunt : " + DateEmp);
            Console.WriteLine();
        }
    }
}
