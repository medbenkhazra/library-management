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
    
    public partial class PeriodiqueForm : Form
    {
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        public int currRowIndex;
        public int selectedId;
        public PeriodiqueForm()
        {
            InitializeComponent();
            load();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            selectedId = int.Parse(row.Cells[0].Value.ToString());
            textBox3.Text = row.Cells["nom"].Value.ToString();
            textBox1.Text = row.Cells["numero"].Value.ToString();
            textBox2.Text = row.Cells["periodicite"].Value.ToString();
            textBox5.Text = row.Cells["numeroOuvrage"].Value.ToString();
            textBox4.Text = row.Cells["quantite"].Value.ToString();
        }


        public void load()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from Periodique";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView2.DataSource = data;
            connection.Close();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from Periodique";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView2.DataSource = data;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce periodique", "Supprimer un Livre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView2.Rows.RemoveAt(rowIndex);

                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM Periodique WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Periodique supprimé");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string nom = textBox3.Text;
                string numero = textBox1.Text;
                string periodicite = textBox2.Text;
                string quantite = textBox4.Text;
                int numeroOuvrage = int.Parse(textBox5.Text);


                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update Periodique set nom=@nom,numero=@numero,periodicite=@periodicite,numeroOuvrage=@numeroOuvrage,quantite=@quantite WHERE id=@id";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@periodicite", periodicite);

                cmd.Parameters.AddWithValue("@numeroOuvrage", numeroOuvrage);
                cmd.Parameters.AddWithValue("@quantite", quantite);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();

                MessageBox.Show("Periodique bien modifié");
                load();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string nom = textBox3.Text;
                string numero = textBox1.Text;
                string periodicite = textBox2.Text;
                string quantite = textBox2.Text;
                int numeroOuvrage = int.Parse(textBox5.Text);
                
               // Livre L = new Livre(auteur, titre, editeur, dateDelai, "non emprunté", numeroOuvrage);

                // dataGridView2.Rows.Add("", dateTimePicker1.Text, textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text);
                // textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear();
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into Periodique(id, nom, numero, periodicite,numeroOuvrage,quantite) values(null, @nom, @numero, @periodicite,@numeroOuvrage,@quantite)";
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@periodicite", periodicite);
                
               
                cmd.Parameters.AddWithValue("@numeroOuvrage", numeroOuvrage);
                cmd.Parameters.AddWithValue("@quantite", quantite);
                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                MessageBox.Show("Periodique bien enregistré");
                load();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

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
