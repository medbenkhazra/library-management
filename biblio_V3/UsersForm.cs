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
    public partial class UsersForm : Form
    {
        int currRowIndex;
        int selectedId;
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        public UsersForm()
        {
            InitializeComponent();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nom = textBox1.Text;
            string cin = textBox2.Text;
            string password = textBox3.Text;
            string type = textBox4.Text;


            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();


            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into Utilisateur(id, nom,cin,password,type) values(null, @nom, @cin,@password,@type)";
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@cin", cin);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@type", type);

            cmd.ExecuteNonQuery();

            connection.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Client bien enregistré");
            load();
        }
        public void load()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from Utilisateur WHERE type!='admin'";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView1.DataSource = data;
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            selectedId = int.Parse(row.Cells[0].Value.ToString());
            textBox1.Text = row.Cells["nom"].Value.ToString();
            textBox2.Text = row.Cells["cin"].Value.ToString();
            textBox3.Text = row.Cells["password"].Value.ToString();
            textBox4.Text = row.Cells["type"].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string nom = textBox1.Text;
                string cin = textBox2.Text;
                string password = textBox3.Text;
                string type = textBox4.Text;

                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update Utilisateur set nom=@nom,cin=@cin,password=@password WHERE id=@id";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@cin", cin);


                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show("Utilisateur bien modifié");
                load();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer Utilisateur", "Supprimer un Utilisateur", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);

                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Utilisateur WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Utilisateur supprimé");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                load();

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            PeriodiqueForm periodiqueForm = new PeriodiqueForm();
            periodiqueForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Emprunts emprunts = new Emprunts();
            emprunts.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
            this.Hide();
        }
    }
}
