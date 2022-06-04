using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblio_V3
{
    public partial class Menu : Form
    {
        public string type;
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeriodiqueForm periodiqueForm = new PeriodiqueForm();
            periodiqueForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LivreForm livreForm = new LivreForm();
            livreForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CDForm cDForm = new CDForm();
            cDForm.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Emprunts emprunts = new Emprunts();
            emprunts.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();


            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from utilisateur WHERE nom=@nom AND password=@password";
            cmd.Parameters.AddWithValue("@nom", Form1.currentUser);
            cmd.Parameters.AddWithValue("@password", Form1.currentPassword);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
           while (reader.Read())
            {
                 type = reader.GetString("type");
            }
            if (type=="admin")
            {
                UsersForm usersForm = new UsersForm();
                usersForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("cette interface n'est accessible seulement par les admins");
            }
               
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
            Form1.currentPassword = "";
            Form1.currentUser = "";
        }
    }
}
