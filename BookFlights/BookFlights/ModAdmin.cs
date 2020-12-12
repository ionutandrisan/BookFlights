using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class ModAdmin : Form
    {
        private PaginaPrincipala paginaPrincipala;

        List<Button> butoaneRezervare = new List<Button>();

        public ModAdmin()
        {
            InitializeComponent();
            clientiListView.Font = new Font("Times New Roman", 12);
            
        }

        private void golireButoaneRezervare()
        {
            for (int i = 0; i < butoaneRezervare.Count; i++)
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

        public void setPaginaPrincipala(PaginaPrincipala paginaPrincipala)
        {
            this.paginaPrincipala = paginaPrincipala;
        }

        private void paginaPrincipalaButon_Click(object sender, EventArgs e)
        {
            Hide();
            paginaPrincipala.afiseazaToateZborurile_Click(sender, e);
            paginaPrincipala.Show();
        }

        private void cautaClientButon_Click(object sender, EventArgs e)
        {
            clientiListView.Items.Clear();
            golireButoaneRezervare();

            paginaPrincipala.ConectareBazaDeDate();

            OracleCommand cmd = new OracleCommand("SYSTEM.TICKETS_PACKAGE.USP_SEARCHTICKETS", paginaPrincipala.GetConnection());
            OracleDataAdapter dataAdapter = new OracleDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("cust_id_code", OracleDbType.Varchar2).Value = cautaIdClientTextBox.Text;
            cmd.Parameters.Add("ticket_info_cursor", OracleDbType.RefCursor, ParameterDirection.Output);

            dataAdapter.SelectCommand = cmd;
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            PopulareClientiListView(dataTable);

            paginaPrincipala.DeconectareBazaDeDate();
        }

        void PopulareClientiListView(DataTable dataTable)
        {
            int count = -1;
            int modPoz = 23;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                count++;
                ListViewItem listViewItem = new ListViewItem(dataRow.ItemArray[0].ToString());

                listViewItem.SubItems.Add(dataRow.ItemArray[1].ToString());
                listViewItem.SubItems.Add(dataRow.ItemArray[2].ToString());
                listViewItem.SubItems.Add(dataRow.ItemArray[3].ToString());
                listViewItem.SubItems.Add(dataRow.ItemArray[4].ToString());
                listViewItem.SubItems.Add(dataRow.ItemArray[5].ToString());

                Button button = setareProprietatiButon(dataRow.ItemArray[0].ToString(), modPoz, count);

                clientiListView.Items.Add(listViewItem);
                clientiListView.Controls.Add(button);
            }
        }

        private Button setareProprietatiButon(string idTicket, int modPoz, int count)
        {
            Button button = new Button();
            button.Click += (s, ev) =>
            {
                paginaPrincipala.ConectareBazaDeDate();
                OracleCommand cmd = new OracleCommand("SYSTEM.TICKETS_PACKAGE.USP_DELETETICKET", paginaPrincipala.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                int x = 0;
                if(!Int32.TryParse(idTicket, out x))
                {
                    Console.WriteLine("Eroare parsare idTicket");
                    return;
                }
                cmd.Parameters.Add("id_ticket_del", OracleDbType.Int32, ParameterDirection.Input).Value = x;
                try
                {
                    cmd.ExecuteNonQuery();
                } catch
                {
                    Console.WriteLine("Eroare procedure ticket_package.usp_deleteticket");
                }
                paginaPrincipala.DeconectareBazaDeDate();
                cautaClientButon_Click(s, ev);
            };
            button.Text = "Sterge";
            button.Font = new Font("Microsoft Sans Serif", 8);
            button.Width = 124;
            button.Height = modPoz;
            button.Location = new Point(630, 24 + (count * modPoz));

            butoaneRezervare.Add(button);
            return button;
        }
    }
}
