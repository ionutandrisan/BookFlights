using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectBD
{
    public partial class RezervareBilet : Form
    {
        private PaginaPrincipala paginaPrincipala;
        private string idZbor;
        private string pretZbor;
        private int bileteDisponibile;

        public RezervareBilet()
        {
            InitializeComponent();
            statusRezervareBilet.Hide();
        }
        
        public void setPaginaPrincipala(PaginaPrincipala paginaPrincipala)
        {
            this.paginaPrincipala = paginaPrincipala;
        }

        public void setBileteDisopnibile(string bilet)
        {
            bileteDisponibile = Int32.Parse(bilet);
            rezervaZborButon.Enabled = true;
        }

        public void setIdZbor(string id)
        {
            idZbor = id;
            informatiiZborLabel.Text = "Zbor cu id-ul: " + idZbor;
        }
        
        public void setPretZbor(string pret)
        {
            pretZbor = pret;
        }

        private void inapoiLaZboruri_Click(object sender, EventArgs e)
        {
            Hide();
            paginaPrincipala.afiseazaToateZborurile_Click(sender, e);
            paginaPrincipala.Show();
        }
        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static bool IsValidEmailAddress(string emailaddress)
        {
            try
            {
                Regex rx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                return rx.IsMatch(emailaddress);
            }
            catch (FormatException)
            {
                return false;
            }
        }

        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        private void rezervaZborButon_Click(object sender, EventArgs e)
        {
            if (this.numeClientTextBox.Text.Length < 1 || this.numeClientTextBox.Text.Length > 49)
            {
                eroareNumeLabel.Text = "Trebuie sa contina intre 2 si 50 caractere";
                eroareNumeLabel.Visible = true;
                return;
            } else
            {
                eroareNumeLabel.Visible = false;
            }
            if (prenumeClientTextBox.Text.Length < 1 || prenumeClientTextBox.Text.Length > 49)
            {
                eroarePrenumeLabel.Text = "Trebuie sa contina intre 2 si 50 caractere";
                eroarePrenumeLabel.Visible = true;
                return;
            } else
            {
                eroarePrenumeLabel.Visible = false;
            }
            if (nationalitateClientTextBox.Text.Length < 1 || nationalitateClientTextBox.Text.Length > 19)
            {
                eroareNationalitateLabel.Text = "Trebuie sa contina intre 2 si 20 caractere";
                eroareNationalitateLabel.Visible = true;
                return;
            } else
            {
                eroareNationalitateLabel.Visible = false;
            }

            if (cnpClientTextBox.Text.Length < 9 || cnpClientTextBox.Text.Length > 15 || !IsDigitsOnly(cnpClientTextBox.Text))
            {
                eroareCnpLablel.Text = "Trebuie sa contina intre 10 si 15 caractere";
                eroareCnpLablel.Visible = true;
                return;
            } else
            {
                eroareCnpLablel.Visible = false;
            }
            if (telefonClientTextBox.Text.Length != 13 || !IsDigitsOnly(telefonClientTextBox.Text))
            {
                eroareTelefonLabel.Text = "Trebuie sa contina 13 caractere";
                eroareTelefonLabel.Visible = true;
                return;
            } else
            {
                eroareTelefonLabel.Visible = false;
            }
            if (adresaClientTextBox.Text.Length > 49)
            {
                eroareAdresaLabel.Text = "Trebuie sa contina mai putin de 50 caractere";
                eroareAdresaLabel.Visible = true;
                return;
            } else
            {
                eroareAdresaLabel.Visible = false;
            }
            if (!IsValidEmailAddress(emailClientTextBox.Text))
            {
                eroareEmailLabel.Text = "ex: example@mail.com";
                eroareEmailLabel.Visible = true;
                return;
            } else
            {
                eroareEmailLabel.Visible = false;
            }

            Console.WriteLine(idZbor + " " + pretZbor);
            
            paginaPrincipala.ConectareBazaDeDate();
            OracleCommand cmd = new OracleCommand("SYSTEM.CUSTOMERS_PACKAGE.USP_INSERTCUSTOMER", paginaPrincipala.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add("first_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = numeClientTextBox.Text;
                cmd.Parameters.Add("last_name", OracleDbType.Varchar2, ParameterDirection.Input).Value = prenumeClientTextBox.Text;
                cmd.Parameters.Add("nationality", OracleDbType.Varchar2, ParameterDirection.Input).Value = nationalitateClientTextBox.Text;
                cmd.Parameters.Add("cnp", OracleDbType.Varchar2, ParameterDirection.Input).Value = cnpClientTextBox.Text;
                cmd.Parameters.Add("nr_telefon", OracleDbType.Varchar2, ParameterDirection.Input).Value = telefonClientTextBox.Text;
                cmd.Parameters.Add("adresa", OracleDbType.Varchar2, ParameterDirection.Input).Value = adresaClientTextBox.Text;
                cmd.Parameters.Add("email", OracleDbType.Varchar2, ParameterDirection.Input).Value = emailClientTextBox.Text;
                try
                {
                    cmd.Parameters.Add("ticket_flight_id", OracleDbType.Int32, ParameterDirection.Input).Value = Int32.Parse(idZbor);
                } catch (Exception ex)
                {
                    Console.WriteLine("Eroare parsare double");
                    Console.WriteLine(ex.StackTrace);
                }
                cmd.Parameters.Add("ticket_total_price", OracleDbType.Double, ParameterDirection.Input).Value = Double.Parse(pretZbor);
            } catch (OracleException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Eroare insert");
            }

            try
            {
                cmd.ExecuteNonQuery();
                ClearAllText(this);
                statusRezervareBilet.Text = "*Biletul a fost rezervat cu succes";
                bileteDisponibile--;
                if (bileteDisponibile <= 0)
                    rezervaZborButon.Enabled = false;
                statusRezervareBilet.Visible = true;
            } catch (OracleException ex)
            {
                statusRezervareBilet.Text = "*Eroare rezervare bilet";
                Console.WriteLine(ex.StackTrace);
            }

            paginaPrincipala.DeconectareBazaDeDate();
            
        }
    }
}
