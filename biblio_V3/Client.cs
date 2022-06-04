using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblio_V3
{
    class Client
    {
        private int id;
        private String nom;
        public static int cmp = 0;

        public Client(int id, string nom)
        {
            this.id = ++cmp;
            this.nom = nom;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getNom()
        {
            return this.nom;
        }

        public void setNom(String nom)
        {
            this.nom = nom;
        }
    }
}
