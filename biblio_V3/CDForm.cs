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
    public partial class CDForm : Form
    {
        int currRowIndex;
        int selectedId;
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        public CDForm()
        {
            InitializeComponent();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string auteur = textBox1.Text;
                string titre = textBox2.Text;
                string quantite = textBox3.Text;
                int numeroOuvrage = int.Parse(textBox5.Text);
                
                //Livre L = new Livre(auteur, titre, editeur, dateDelai, "non emprunté", numeroOuvrage);

                // dataGridView2.Rows.Add("", dateTimePicker1.Text, textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text);
                // textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear();
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into CD(id, titre,auteur,numeroOuvrage,quantite) values(null, @titre, @auteur,@numeroOuvrage,@quantite)";
                cmd.Parameters.AddWithValue("@titre", titre);
                cmd.Parameters.AddWithValue("@auteur", auteur);
                cmd.Parameters.AddWithValue("@quantite", quantite);



                cmd.Parameters.AddWithValue("@numeroOuvrage", numeroOuvrage);

                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox5.Clear();
                MessageBox.Show("CD bien enregistré");
                load();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            currRowIndex = Convert.ToInt32(row.Cells[0].Value);
            selectedId = int.Parse(row.Cells[0].Value.ToString());
            textBox1.Text = row.Cells[2].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox5.Text = row.Cells[3].Value.ToString();
            textBox3.Text = row.Cells[4].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string auteur = textBox1.Text;
                string titre = textBox2.Text;
                string quantite = textBox3.Text;
                int numeroOuvrage = int.Parse(textBox5.Text);


                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();


                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update CD set auteur=@auteur,titre=@titre,numeroOuvrage=@numeroOuvrage,quantite=@quantite WHERE id=@id";
                cmd.Parameters.AddWithValue("@auteur", auteur);
                cmd.Parameters.AddWithValue("@titre", titre);

                cmd.Parameters.AddWithValue("@numeroOuvrage", numeroOuvrage);
                cmd.Parameters.AddWithValue("@quantite", quantite);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();

                connection.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();

                MessageBox.Show("CD bien modifié");
                load();

            }
            
        }


        public void load()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from CD";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView1.DataSource = data;
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from CD";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView1.DataSource = data;
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            DialogResult dialogDelete = MessageBox.Show("voulez-vous vraiment supprimer ce CD", "Supprimer un CD", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogDelete == DialogResult.OK)
            {
                dataGridView1.Rows.RemoveAt(rowIndex);

                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM CD WHERE id=" + currRowIndex;
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("CD supprimé");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                load();

            }
        }

        private void CDForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
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
