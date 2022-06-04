using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace biblio_V3
{
    public partial class CreateUser : Form
    {
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";

        public CreateUser()
        {
            InitializeComponent();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                String nom = textBox1.Text;
                String cin = textBox2.Text;
                String password = textBox3.Text;
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into utilisateur(id, nom, cin, password) values(null, @nom, @cin, @password)";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@cin", cin);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Utilisateur bien enregistré");
            }
        }
    }
}
