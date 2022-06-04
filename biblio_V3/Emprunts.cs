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
    public partial class Emprunts : Form
    {
        public String parametres = "SERVER=127.0.0.1; DATABASE=bibliotheque; UID=root; PASSWORD=";
        public string nomFilt;
        int currRowIndex;
        int selectedIdEmprunt;
        public int selectedId;
        int currRowIndexEmprunt;
        DataGridViewRow rowEmprunt;
        int currRowIndexClient;
        public int selectedIdClient;
        string CurrentidLivre;
        string CurrentidCd;
        string CurrentidPeriodique;
        private MySqlConnection maconnexion;
        DataTable dataTable = new DataTable();
        DataTable dataTable2 = new DataTable();
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = new DataTable();
        string etatView;
        
        String table = "emprunteurs";
        int ouvID;
        public Emprunts()
        {
            InitializeComponent();

            comboBox1.Items.Add("emprunté");
            comboBox1.Items.Add("non emprunté");
            loadClientsCombo();



        }


        public void loadClients()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from client";
            String request2 = "SELECT idClient FROM emprunts where dateRetou < CAST(now() AS DATE) GROUP BY idClient HAVING COUNT(*) >= 2;";
         //   MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlCommand cmd2 = new MySqlCommand(request2, connection);
            MySqlCommand cmdSpeciale = new MySqlCommand(request2, connection);
          //  MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
           
           // adapter.Fill(data);

            dataGridView5.DataSource = data;
            MySqlDataReader reader = cmd2.ExecuteReader();
            List<int> exclus = new List<int>();
            String speciale = "select * from Client WHERE 1=1";
            while (reader.Read())
            {
                
               
                    int idClient = reader.GetInt32("idClient");
                    Console.WriteLine("****haaaaaaaaaaaaaa les ids***");
                    Console.WriteLine(idClient);
                    exclus.Add(idClient);
              
              
            }
            reader.Close();
            foreach (int idClient in exclus)
            {
                speciale +=" AND id!="+ idClient;
            }
            MySqlCommand cmd3 = new MySqlCommand(speciale, connection);
          //  cmdSpeciale.ExecuteNonQuery();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd3);

            adapter2.Fill(data);

            dataGridView5.DataSource = data;
            
            connection.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CDs DataGridView
            table = "cds";
            label11.Visible = true;
            label11.Text = "-  CD";
            DataGridViewRow row2 = this.dataGridView2.Rows[e.RowIndex];

            ouvID = Convert.ToInt32(row2.Cells[0].Value);
         //   textBox5.Text = row2.Cells[4].Value.ToString();

            button1.Enabled = true;
            textBox4.Text= row2.Cells[0].Value.ToString();
            textBox3.Text = row2.Cells[4].Value.ToString();
            textBox5.Text = "CD";
        }


       

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = true;
            dataGridView3.Visible = false;
            etatView = "periodique";
            dataTable4.Clear();
            dataGridView4.Rows.Clear();
            etatView = "periodique";
            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select * from periodique";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable4);

            int i;
            String[] myArray = new String[6];
            foreach (DataRow dataRow in dataTable4.Rows)
            {
                i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray[i] = item.ToString();
                    i++;
                }
                dataGridView4.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4]);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            dataGridView3.Visible = true;
            dataTable3.Clear();
            dataGridView3.Rows.Clear();
            etatView = "livre";
            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select id,dateEmp, numeroOuvrage,auteur, titre, editeur from livre";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable3);

            int i;
            String[] myArray = new String[6];
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray[i] = item.ToString();
                    i++;
                }
                dataGridView3.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4], myArray[5]);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView4.Visible = false;
            dataGridView3.Visible = false;
            etatView = "CD";
            dataTable2.Clear();
            dataGridView2.Rows.Clear();

            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select id,dateEmp, numeroOuvrage,auteur,titre from cd";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable2);

            int i;
            String[] myArray = new String[5];
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray[i] = item.ToString();
                    i++;
                }
                dataGridView2.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4]);
            }
            maconnexion.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Period DataGridView
            table = "periodiques";
            label11.Visible = true;
            label11.Text = "-  Periodiques";
            DataGridViewRow row4 = this.dataGridView4.Rows[e.RowIndex];

            ouvID = Convert.ToInt32(row4.Cells[0].Value);
          //  textBox5.Text = row4.Cells[3].Value.ToString();

            button1.Enabled = true;
            textBox4.Text = row4.Cells[0].Value.ToString();
            textBox3.Text = row4.Cells["quantite"].Value.ToString();
            textBox5.Text = "Periodique";

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Livre DataGridView
            table = "livres";
            label11.Visible = true;
            label11.Text = "-  Livre";
            DataGridViewRow row3 = this.dataGridView3.Rows[e.RowIndex];

            ouvID = Convert.ToInt32(row3.Cells[0].Value);
          //  textBox5.Text = row3.Cells[4].Value.ToString();

          //  dateTimePicker1.Text = row3.Cells[1].Value.ToString();


            button1.Enabled = true;
            textBox4.Text = row3.Cells[0].Value.ToString();
            textBox3.Text = row3.Cells["quantite"].Value.ToString();
            textBox5.Text = "Livre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox2.Text == "" || textBox2.Text == "")
            {
                DialogResult dialogClose = MessageBox.Show("Veuillez renseigner tous les champs", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
               // dateTimePicker1.Format = DateTimePickerFormat.Custom;
              //  dateTimePicker1.CustomFormat = "dd-MM-yyyy";


               // emprunt Emp = new emprunt(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), ouvID.ToString(), textBox1.Text, textBox2.Text, dateTimePicker1.Text, table);

                //dataGridView1.Rows.Add("", "", ouvID, table, textBox1.Text,textBox2.Text, dateTimePicker1.Text);
               // dataGridView1.Rows.Add("", "", ouvID, table, Emp.client, Emp.cin, Emp.delai);
                

             //   textBox1.Clear(); textBox2.Clear(); textBox5.Clear(); textBox3.Clear();

                maconnexion = new MySqlConnection(parametres);
                maconnexion.Open();
                MySqlCommand cmd = maconnexion.CreateCommand();
                MySqlCommand cmdUpdate = maconnexion.CreateCommand();
                // string nom = textBox1.Text;
                // string cin = textBox2.Text;
                DateTime dateEmp = dateTimePicker3.Value;
                DateTime dateRetour = dateTimePicker1.Value;
                // string titreOuvrage = textBox5.Text;
                int Qtt = int.Parse(textBox3.Text);
                int nvQtt = Qtt - 1;
                String quantite = nvQtt.ToString();

                if (etatView == "CD")
                {
                    if (textBox3.Text=="0")
                    {
                        DialogResult dialogClose = MessageBox.Show("L'ouvrage n'existe pas", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cmdUpdate.CommandText = "UPDATE cd set quantite=@quantite WHERE id=@id";
                    
                    cmdUpdate.Parameters.AddWithValue("@quantite", quantite);
                    cmdUpdate.Parameters.AddWithValue("@id", ouvID);
                    Console.WriteLine(quantite);
                    Console.WriteLine(selectedId);
                    cmdUpdate.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO emprunts(id,dateEmp,dateRetou,etat,idLivre,idCd,idPeriodique,idClient) values(null,@dateEmp,@dateRetou,@etat,null,@idCd,null,@idClient)";
                

                cmd.Parameters.AddWithValue("@dateEmp", dateEmp);
                cmd.Parameters.AddWithValue("@dateRetou", dateRetour);
                cmd.Parameters.AddWithValue("@idCd", textBox4.Text);
                cmd.Parameters.AddWithValue("@etat", "emprunté");
                    cmd.Parameters.AddWithValue("@idClient", selectedIdClient);
                    cmd.ExecuteNonQuery();
                maconnexion.Close();

                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                dataGridView4.Visible = false;
                dataGridView3.Visible = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("CD bien affecté");
                }
                if (etatView == "livre")
                {
                    if (textBox3.Text == "0")
                    {
                        DialogResult dialogClose = MessageBox.Show("L'ouvrage n'existe pas", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cmdUpdate.CommandText = "UPDATE livre set quantite=@quantite WHERE id=@id";

                    cmdUpdate.Parameters.AddWithValue("@quantite", quantite);
                    cmdUpdate.Parameters.AddWithValue("@id", ouvID);
                    cmdUpdate.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO emprunts(id,dateEmp,dateRetou,etat,idLivre,idCd,idPeriodique,idClient) values(null,@dateEmp,@dateRetou,@etat,@idLivre,null,null,@idClient)";


                    cmd.Parameters.AddWithValue("@dateEmp", dateEmp);
                    cmd.Parameters.AddWithValue("@dateRetou", dateRetour);
                    cmd.Parameters.AddWithValue("@idLivre", textBox4.Text);
                    cmd.Parameters.AddWithValue("@etat", "emprunté");
                    cmd.Parameters.AddWithValue("@idClient", selectedIdClient);
                    cmd.ExecuteNonQuery();
                    maconnexion.Close();
                //    Console.WriteLine("hi bro");
                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView4.Visible = false;
                    dataGridView3.Visible = true;
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("livre bien affecté");
                }
                if (etatView == "periodique")
                {
                    if (textBox3.Text == "0")
                    {
                        DialogResult dialogClose = MessageBox.Show("L'ouvrage n'existe pas", "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cmdUpdate.CommandText = "UPDATE periodique set quantite=@quantite WHERE id=@id";

                    cmdUpdate.Parameters.AddWithValue("@quantite", quantite);
                    cmdUpdate.Parameters.AddWithValue("@id", ouvID);
                    cmdUpdate.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO emprunts(id,dateEmp,dateRetou,etat,idLivre,idCd,idPeriodique,idClient) values(null,@dateEmp,@dateRetou,@etat,null,null,@idPeriodique,@idClient)";


                    cmd.Parameters.AddWithValue("@dateEmp", dateEmp);
                    cmd.Parameters.AddWithValue("@dateRetou", dateRetour);
                    cmd.Parameters.AddWithValue("@idPeriodique", textBox4.Text);
                    cmd.Parameters.AddWithValue("@etat", "emprunté");
                    Console.WriteLine("******haa l id*****");
                    Console.WriteLine(selectedIdClient);
                    cmd.Parameters.AddWithValue("@idClient", selectedIdClient);

                    cmd.ExecuteNonQuery();
                    maconnexion.Close();

                    dataGridView1.Visible = false;
                    dataGridView2.Visible = false;
                    dataGridView4.Visible = true;
                    dataGridView3.Visible = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    MessageBox.Show("Periodique bien affecté");
                }
                textBox4.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox2.Clear();
                textBox6.Clear();
                textBox1.Clear();
                textBox7.Clear();
            }
            loadClients();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label19.Visible = true;
            label8.Visible = false;
            label20.Visible = false;

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = false;
            dataGridView3.Visible = true;
            dataTable3.Clear();
            dataTable3.Rows.Clear();
        //    dataGridView3.Rows.Clear();
            etatView = "livre";
            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select * from livre";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable3);
            dataGridView3.DataSource = dataTable3;
            /*
            int i;
            String[] myArray = new String[6];
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray[i] = item.ToString();
                    i++;
                }
                dataGridView3.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4], myArray[5]);
            }*/
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = true;
            label19.Visible = false;
            label20.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView4.Visible = true;
            dataGridView3.Visible = false;
            etatView = "periodique";
            dataTable4.Clear();
          //  dataGridView4.Rows.Clear();
            etatView = "periodique";
            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select * from periodique";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable4);
            dataGridView4.DataSource = dataTable4;
            /*
                        int i;
                        String[] myArray = new String[6];
                        foreach (DataRow dataRow in dataTable4.Rows)
                        {
                            i = 0;
                            foreach (var item in dataRow.ItemArray)
                            {
                                myArray[i] = item.ToString();
                                i++;
                            }
                            dataGridView4.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4], myArray[5]);
                        }*/
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label19.Visible = false;
            label8.Visible = false;
            label20.Visible = true;


            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView4.Visible = false;
            dataGridView3.Visible = false;
            etatView = "CD";
            dataTable2.Clear();
          //  dataGridView2.Rows.Clear();

            maconnexion = new MySqlConnection(parametres);
            maconnexion.Open();
            string request = "select * from cd";
            MySqlCommand cmd = new MySqlCommand(request, maconnexion);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
            /*
            int i;
            String[] myArray = new String[5];
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    myArray[i] = item.ToString();
                    i++;
                }
                dataGridView2.Rows.Add(myArray[0], myArray[1], myArray[2], myArray[3], myArray[4]);
            }*/
            maconnexion.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView5.Rows[e.RowIndex];
            currRowIndexClient = Convert.ToInt32(row.Cells[0].Value);
            selectedIdClient = int.Parse(row.Cells[0].Value.ToString());
            textBox2.Text = row.Cells["id"].Value.ToString();
            textBox6.Text = row.Cells["nom"].Value.ToString();
            textBox1.Text = row.Cells["cin"].Value.ToString();
            textBox7.Text = row.Cells["email"].Value.ToString();
        }

        private void Emprunts_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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

        private void button11_Click_1(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView5.Visible = true;
            dataGridView6.Visible = false;
            loadClients();
            label1.Visible = true;
            label18.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView5.Visible = false;
            dataGridView6.Visible = true;
            loadEmprunts();
            label18.Visible = true;
            label1.Visible = false;
        }
        public void loadEmprunts()
        {
            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from Emprunts";
            MySqlCommand cmd = new MySqlCommand(request, connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            adapter.Fill(data);

            dataGridView6.DataSource = data;
            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             rowEmprunt = this.dataGridView6.Rows[e.RowIndex];
            Console.WriteLine("****first***");
            Console.WriteLine(rowEmprunt);
           // rowEmprunt = row;
            currRowIndexEmprunt = Convert.ToInt32(rowEmprunt.Cells[0].Value);
            selectedIdEmprunt = int.Parse(rowEmprunt.Cells[0].Value.ToString());
            comboBox1.SelectedItem = rowEmprunt.Cells["etat"].Value.ToString();
            dateTimePicker3.Value = (DateTime)rowEmprunt.Cells["dateEmp"].Value;
            dateTimePicker1.Value = (DateTime)rowEmprunt.Cells["dateRetou"].Value;
            CurrentidLivre = rowEmprunt.Cells["idLivre"].Value.ToString();
            CurrentidCd = rowEmprunt.Cells["idCd"].Value.ToString();
            CurrentidPeriodique = rowEmprunt.Cells["idPeriodique"].Value.ToString();

        }
     

        private void button2_Click_1(object sender, EventArgs e)
        {
            DateTime dateEmp = dateTimePicker3.Value;
            DateTime dateRetou = dateTimePicker1.Value;
            String etat = comboBox1.SelectedItem.ToString();
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update emprunts set dateEmp=@dateEmp,dateRetou=@dateRetou,etat=@etat WHERE id=@id";
            cmd.Parameters.AddWithValue("@dateEmp", dateEmp);
            cmd.Parameters.AddWithValue("@dateRetou", dateRetou);
            cmd.Parameters.AddWithValue("@etat", etat);

            Console.WriteLine(selectedIdEmprunt);
            cmd.Parameters.AddWithValue("@id", selectedIdEmprunt);
            cmd.ExecuteNonQuery();

            connection.Close();
           

            MessageBox.Show("Emprunt bien modifié");
            loadEmprunts();
            quantiteModify();

        }
        public void quantiteModify()
        {
            Console.WriteLine("*********");
            Console.WriteLine(rowEmprunt);
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            Console.WriteLine("**$*Livre*$**");
            Console.WriteLine(CurrentidLivre);
            Console.WriteLine("**$*CD*$**");
            Console.WriteLine(CurrentidCd);
            Console.WriteLine("**$*Periodique*$**");
            Console.WriteLine(CurrentidPeriodique);
            //string idLivre = rowEmprunt.Cells["idLivre"].Value.ToString();
            //  string idCd = rowEmprunt.Cells["idCd"].Value.ToString();
            //   string idPeriodique = rowEmprunt.Cells["idPeriodique"].Value.ToString();
            if (!String.IsNullOrEmpty(CurrentidLivre))
            {
                Console.WriteLine("***Livre***");
                Console.WriteLine(CurrentidLivre);
                cmd.CommandText = "update livre set quantite=quantite+1 WHERE id=@idLivre";
                cmd.Parameters.AddWithValue("@idLivre", CurrentidLivre);
                cmd.ExecuteNonQuery();

            }
            else if (!String.IsNullOrEmpty(CurrentidCd))
            {
                Console.WriteLine("***CD***");
                Console.WriteLine(CurrentidCd);
                cmd.CommandText = "update cd set quantite=quantite+1 WHERE id=@idCd";
                cmd.Parameters.AddWithValue("@idCd", CurrentidCd);
                cmd.ExecuteNonQuery();
            }
            else if (!String.IsNullOrEmpty(CurrentidPeriodique))
            {

                Console.WriteLine("***periodique***");
                Console.WriteLine(CurrentidPeriodique);
                cmd.CommandText = "update periodique set quantite=quantite+1 WHERE id=@idPeriodique";
                cmd.Parameters.AddWithValue("@idPeriodique", CurrentidPeriodique);
                cmd.ExecuteNonQuery();
            }
           
            connection.Close();
        }
        private void loadClientsCombo()
        {
            MySqlConnection connection = new MySqlConnection(parametres);

            connection.Open();
            string req = "select nom from client";
            MySqlCommand cmd = new MySqlCommand(req, connection);
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                string name = myReader.GetString("nom");
               // string prenom = myReader5.GetString("prenom");
              //  comboBox1.Items.Remove(name);
              //  comboBox2.Items.Add(name);
            }
            myReader.Close();
            connection.Close();



            // **************************

         //   MySqlConnection connection = new MySqlConnection(parametres);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            MySqlConnection connection = new MySqlConnection(parametres);

            connection.Open();
            String request5 = "SELECT id FROM emprunts where dateRetou<CAST(now() AS DATE) GROUP BY id HAVING COUNT(*) >=2;";

            MySqlCommand cmd = new MySqlCommand(request5, connection);
            MySqlDataReader myReader5;
            

                myReader5 = cmd.ExecuteReader();
                while (myReader5.Read())
                {
                    string name = myReader5.GetString("nom");
                    string prenom = myReader5.GetString("prenom");
                    comboBox1.Items.Remove(name);
                   // comboBox2.Items.Remove(prenom);
                }
           
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
