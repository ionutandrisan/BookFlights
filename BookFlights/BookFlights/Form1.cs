using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ProiectBD
{
    public partial class PaginaPrincipala : Form
    {
        
        public PaginaPrincipala()
        {
            InitializeComponent();
            rezervareBilet = new RezervareBilet();
            modAdmin = new ModAdmin();
            zboruriListView.Font = new Font("Times New Roman", 12);
        }

        private OracleConnection con;
        private string connectionString = "User Id=system;Password=root;Data Source=localhost:1521/xe";

        RezervareBilet rezervareBilet;
        ModAdmin modAdmin;

        List<Button> butoaneRezervare = new List<Button>();

        public void ConectareBazaDeDate()
        {
            con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            Console.WriteLine("Connected to database");
        }        

        public void DeconectareBazaDeDate()
        {
            con.Close();
            Console.WriteLine("Diconnected from database");
        }

        public OracleConnection GetConnection()
        {
            return con; 
        }

        private Button setareProprietatiButon(DataRow dataRow, int modPoz, int count)
        {
            Button button = new Button();
            button.Click += (s, ev) =>
            {
                rezervareBilet.setPaginaPrincipala(this);
                rezervareBilet.setIdZbor(dataRow.ItemArray[5].ToString());
                rezervareBilet.setPretZbor(dataRow.ItemArray[4].ToString());
                rezervareBilet.setBileteDisopnibile(dataRow[6].ToString());
                this.Hide();
                rezervareBilet.Show();
            };
            button.Text = "Rezerva";
            button.Font = new Font("Microsoft Sans Serif", 8);
            button.Width = 124;
            button.Height = modPoz;
            button.Location = new Point(630, 24 + (count * modPoz));

            if (Int32.Parse(dataRow.ItemArray[6].ToString()) <= 0)
                button.Enabled = false;

            butoaneRezervare.Add(button);

            return button;
        }

        private void PopulareZboruriListView(DataTable dataTable)
        {
            int count = -1;
            int modPoz = 23;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                count++;    
                ListViewItem listViewItem = new ListViewItem(dataRow.ItemArray[0].ToString());

                string[] dataPlecare = dataRow.ItemArray[2].ToString().Split(' ');
                string[] dataSosire = dataRow.ItemArray[3].ToString().Split(' ');

                listViewItem.SubItems.Add(dataRow.ItemArray[1].ToString());
                listViewItem.SubItems.Add(dataPlecare[0]);
                listViewItem.SubItems.Add(dataPlecare[1] + " " + dataPlecare[2]);
                listViewItem.SubItems.Add(dataSosire[1] + " " + dataSosire[2]);
                listViewItem.SubItems.Add(dataRow.ItemArray[4].ToString());

                Button button = setareProprietatiButon(dataRow, modPoz, count);

                zboruriListView.Items.Add(listViewItem);
                zboruriListView.Controls.Add(button);
            }
        }


        public void PaginaPrincipala_Load(object sender, EventArgs e)
        {
            
            ConectareBazaDeDate();

            OracleCommand cmd = new OracleCommand("SYSTEM.FLIGHTS_PACKAGE.USP_FLIGHTINFOPRINT", con);
            OracleDataAdapter dataAdapter = new OracleDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("flight_info_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            dataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            PopulareZboruriListView(dataTable);

            DeconectareBazaDeDate();

        }

        private void butonCautareZboruri_Click(object sender, EventArgs e)
        {
            zboruriListView.Items.Clear();
            golireButoaneRezervare();
            ConectareBazaDeDate();

            OracleCommand cmd = new OracleCommand("SYSTEM.FLIGHTS_PACKAGE.USP_FLIGHTSEARCH", con);
            OracleDataAdapter dataAdapter = new OracleDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            
           

            cmd.Parameters.Add("search_departure_city", OracleDbType.Varchar2).Value = cautareOrasPlecareTextBox.Text;
            cmd.Parameters.Add("search_arrival_city", OracleDbType.Varchar2).Value = cautaOrasSosireTextBox.Text;
            cmd.Parameters.Add("flight_info_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            dataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            PopulareZboruriListView(dataTable);

            DeconectareBazaDeDate();
        }

        public void afiseazaToateZborurile_Click(object sender, EventArgs e)
        {
            zboruriListView.Items.Clear();

            golireButoaneRezervare();

            PaginaPrincipala_Load(sender, e);
        }

        private void golireButoaneRezervare()
        {
            for(int i = 0; i < butoaneRezervare.Count; i++)
            {
                Button buttonToRemove = butoaneRezervare[i];
                Controls.Remove(buttonToRemove);
                buttonToRemove.Dispose();
            }
            for (int i = butoaneRezervare.Count - 1; i >= 0; i--)
            {
                Button buttonToRemove = butoaneRezervare[i];
                butoaneRezervare.Remove(buttonToRemove);
            }
            
        }

        private void modAdminButton_Click(object sender, EventArgs e)
        {
            if(parolaTextBox.Text == "admin")
            {
                modAdmin.Show();
                Hide();
                modAdmin.setPaginaPrincipala(this);
                parolaGresitaLabel.Visible = false;
                parolaTextBox.Text = "";
            } else
            {
                parolaGresitaLabel.Visible = true;
            }
        }

        
    }
}
