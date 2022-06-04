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
    public partial class Form1 : Form
    {
        public static String currentUser;
        public static String currentPassword;
        String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner le nom d'utilisateur et le mot de passe", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string nom = textBox1.Text;
                string password = textBox2.Text;
                currentUser = nom;
                currentPassword = password;
                MySqlConnection connection = new MySqlConnection(parametres);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                MySqlDataReader reader;
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * FROM utilisateur WHERE nom=@nom AND password=@password";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@password", password);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("bienvenue Utilisateur  " + nom);
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("nom d'utilisateur ou mot de passe est incorrect");
                    reader.Close();
                }
                //cmd.ExecuteNonQuery();
                // adapter.Fill(table);



                //   Console.WriteLine(cmd.ExecuteNonQuery());
                // cmd.ExecuteNonQuery();



                //  DialogResult dialogClose = MessageBox.Show("Utilisateur ou mot de passe est incorrect", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                connection.Close();

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
            this.Hide();


        }
    }
}
