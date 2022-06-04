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
    public partial class LivreForm : Form
    {
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        int currRowIndex;
        public int selectedId;
        public LivreForm()
        {
            InitializeComponent();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string auteur = textBox1.Text;
                string titre = textBox2.Text;
                string editeur = textBox3.Text;
                string quantite = textBox3.Text;
                int numeroOuvrage = int.Parse(textBox5.Text);
                
               // Livre L = new Livre(auteur, titre, editeur, dateDelai,"non emprunté",numeroOuvrage);

                // dataGridView2.Rows.Add("", dateTimePicker1.Text, textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text);
                // textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear();
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into livre(id, auteur, titre, editeur,numeroOuvrage,quantite) values(null, @auteur, @titre, @editeur,@numeroOuvrage,@quantite)";
                cmd.Parameters.AddWithValue("@auteur", auteur);
                cmd.Parameters.AddWithValue("@titre", titre);
                cmd.Parameters.AddWithValue("@editeur", editeur);
                
               // cmd.Parameters.AddWithValue("@etat", "nom emprunté");
                cmd.Parameters.AddWithValue("@numeroOuvrage", numeroOuvrage);
                cmd.Parameters.AddWithValue("@quantite", quantite);

                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show("Livre bien enregistré");
                load();
            }
        }

        public  void DisplayAndSearch(string query,DataGridView dgv)
        {
            string sql = query;
           // String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            DataTable data = new DataTable();
            String request = "select * from livre";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
           
            adapter.Fill(data);

            dataGridView2.DataSource = data;

            

            connection.Close();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            selectedId = int.Parse(row.Cells[0].Value.ToString());
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox4.Text = row.Cells[5].Value.ToString();
            // dateTimePicker1.Text = Convert.ToString(row.Cells[1].Value);


            /* if (dataGridView2.SelectedRows.Count > 0)
             {
                 textBox1.Text = dataGridView2.SelectedItems[0].SubItems[0].Text;
                 textBox2.Text = dataGridView2.SelectedItems[0].SubItems[1].Text;
                 textBox3.Text = dataGridView2.SelectedItems[0].SubItems[2].Text;
             }*/
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string auteur = textBox1.Text;
                string titre = textBox2.Text;
                string editeur = textBox3.Text;
                string quantite = textBox4.Text;
                int numeroOuvrage = int.Parse(textBox5.Text);


                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update livre set auteur=@auteur,titre=@titre,editeur=@editeur,numeroOuvrage=@numeroOuvrage,quantite=@quantite WHERE id=@id";
                cmd.Parameters.AddWithValue("@auteur", auteur);
                cmd.Parameters.AddWithValue("@titre", titre);
                cmd.Parameters.AddWithValue("@editeur", editeur);

                cmd.Parameters.AddWithValue("@numeroOuvrage", numeroOuvrage);
                cmd.Parameters.AddWithValue("@quantite", quantite);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox4.Clear();
                loadOuvrage(dataGridView2);
                MessageBox.Show("Livre bien modifié");
                load();
            }
        }
        public void loadOuvrage(DataGridView dvg)
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from livre";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView2.DataSource = data;
            connection.Close();
        }

        public void load()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from livre";
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

            String request = "select * from livre";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView2.DataSource = data;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce Livre", "Supprimer un Livre", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView2.Rows.RemoveAt(rowIndex);
                
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM livre WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Livre supprimé");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                load();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
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
