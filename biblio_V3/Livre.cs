using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_V3
{
    class Livre : Ouvrage
    {
        private string auteur;
        private string titre;
        private string editeur;

        public Livre(string auteur, string titre, string editeur, DateTime dateEmp, string etat, int numeroOuvrage) : base(dateEmp, etat,numeroOuvrage)
        {
            this.auteur = auteur;
            this.titre = titre;
            this.editeur = editeur;
        }

        public string Auteur { get => auteur; set => auteur = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Editeur { get => editeur; set => editeur = value; }

        public override void toString()
        {
            
           
            Console.WriteLine("l'auteur :" + Auteur + " ,le titre :" + Titre + " ,editeur:" + Editeur + " ,date emprunt : " + DateEmp );
            Console.WriteLine();
        }
    }
}
