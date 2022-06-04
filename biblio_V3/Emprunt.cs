using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_V3
{
    class Emprunt
    {
        private int clientId;
        private int qte;
        private int ouvrageId;
        private DateTime dateRetour;
        public Emprunt(Client client, int qte, Ouvrage ouvrage, DateTime dateRetour)
        {
            this.clientId = client.getId();
            this.qte = qte;
         //   this.ouvrageId = ouvrage.getCote();
            this.dateRetour = dateRetour;
        }
    }
}
