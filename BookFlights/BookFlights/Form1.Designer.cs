namespace ProiectBD
{
    partial class PaginaPrincipala
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zboruriListView = new System.Windows.Forms.ListView();
            this.orasPlecareLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orasSosireLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oraPlecareLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oraSosireLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pretLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rezervaLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cautareOrasPlecareTextBox = new System.Windows.Forms.TextBox();
            this.cautaOrasSosireTextBox = new System.Windows.Forms.TextBox();
            this.butonCautareZboruri = new System.Windows.Forms.Button();
            this.orasPlecareLabel = new System.Windows.Forms.Label();
            this.orasSosireLabel = new System.Windows.Forms.Label();
            this.afiseazaToateZborurile = new System.Windows.Forms.Button();
            this.modAdminButton = new System.Windows.Forms.Button();
            this.parolaTextBox = new System.Windows.Forms.TextBox();
            this.parolaGresitaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // zboruriListView
            // 
            this.zboruriListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.zboruriListView.BackColor = System.Drawing.SystemColors.Control;
            this.zboruriListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.zboruriListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orasPlecareLV,
            this.orasSosireLV,
            this.dataLV,
            this.oraPlecareLV,
            this.oraSosireLV,
            this.pretLV,
            this.rezervaLV});
            this.zboruriListView.GridLines = true;
            this.zboruriListView.Location = new System.Drawing.Point(12, 88);
            this.zboruriListView.Name = "zboruriListView";
            this.zboruriListView.Size = new System.Drawing.Size(754, 471);
            this.zboruriListView.TabIndex = 0;
            this.zboruriListView.UseCompatibleStateImageBehavior = false;
            this.zboruriListView.View = System.Windows.Forms.View.Details;
            // 
            // orasPlecareLV
            // 
            this.orasPlecareLV.Text = "Oras plecare";
            this.orasPlecareLV.Width = 110;
            // 
            // orasSosireLV
            // 
            this.orasSosireLV.Text = "Oras sosire";
            this.orasSosireLV.Width = 110;
            // 
            // dataLV
            // 
            this.dataLV.Text = "Data plecare";
            this.dataLV.Width = 110;
            // 
            // oraPlecareLV
            // 
            this.oraPlecareLV.Text = "Ora plecare";
            this.oraPlecareLV.Width = 110;
            // 
            // oraSosireLV
            // 
            this.oraSosireLV.Text = "Ora sosire";
            this.oraSosireLV.Width = 110;
            // 
            // pretLV
            // 
            this.pretLV.Text = "Pret";
            this.pretLV.Width = 80;
            // 
            // rezervaLV
            // 
            this.rezervaLV.Text = "";
            this.rezervaLV.Width = 124;
            // 
            // cautareOrasPlecareTextBox
            // 
            this.cautareOrasPlecareTextBox.Location = new System.Drawing.Point(128, 8);
            this.cautareOrasPlecareTextBox.Name = "cautareOrasPlecareTextBox";
            this.cautareOrasPlecareTextBox.Size = new System.Drawing.Size(110, 20);
            this.cautareOrasPlecareTextBox.TabIndex = 1;
            // 
            // cautaOrasSosireTextBox
            // 
            this.cautaOrasSosireTextBox.Location = new System.Drawing.Point(128, 34);
            this.cautaOrasSosireTextBox.Name = "cautaOrasSosireTextBox";
            this.cautaOrasSosireTextBox.Size = new System.Drawing.Size(110, 20);
            this.cautaOrasSosireTextBox.TabIndex = 2;
            // 
            // butonCautareZboruri
            // 
            this.butonCautareZboruri.Location = new System.Drawing.Point(128, 59);
            this.butonCautareZboruri.Name = "butonCautareZboruri";
            this.butonCautareZboruri.Size = new System.Drawing.Size(110, 23);
            this.butonCautareZboruri.TabIndex = 5;
            this.butonCautareZboruri.Text = "Cauta";
            this.butonCautareZboruri.UseVisualStyleBackColor = true;
            this.butonCautareZboruri.Click += new System.EventHandler(this.butonCautareZboruri_Click);
            // 
            // orasPlecareLabel
            // 
            this.orasPlecareLabel.AutoSize = true;
            this.orasPlecareLabel.Location = new System.Drawing.Point(55, 11);
            this.orasPlecareLabel.Name = "orasPlecareLabel";
            this.orasPlecareLabel.Size = new System.Drawing.Size(67, 13);
            this.orasPlecareLabel.TabIndex = 6;
            this.orasPlecareLabel.Text = "Oras plecare";
            // 
            // orasSosireLabel
            // 
            this.orasSosireLabel.AutoSize = true;
            this.orasSosireLabel.Location = new System.Drawing.Point(63, 37);
            this.orasSosireLabel.Name = "orasSosireLabel";
            this.orasSosireLabel.Size = new System.Drawing.Size(59, 13);
            this.orasSosireLabel.TabIndex = 7;
            this.orasSosireLabel.Text = "Oras sosire";
            // 
            // afiseazaToateZborurile
            // 
            this.afiseazaToateZborurile.Location = new System.Drawing.Point(642, 88);
            this.afiseazaToateZborurile.Name = "afiseazaToateZborurile";
            this.afiseazaToateZborurile.Size = new System.Drawing.Size(124, 23);
            this.afiseazaToateZborurile.TabIndex = 9;
            this.afiseazaToateZborurile.Text = "Afiseaza zboruri";
            this.afiseazaToateZborurile.UseVisualStyleBackColor = true;
            this.afiseazaToateZborurile.Click += new System.EventHandler(this.afiseazaToateZborurile_Click);
            // 
            // modAdminButton
            // 
            this.modAdminButton.Location = new System.Drawing.Point(642, 32);
            this.modAdminButton.Name = "modAdminButton";
            this.modAdminButton.Size = new System.Drawing.Size(124, 23);
            this.modAdminButton.TabIndex = 10;
            this.modAdminButton.Text = "Mod Admin";
            this.modAdminButton.UseVisualStyleBackColor = true;
            this.modAdminButton.Click += new System.EventHandler(this.modAdminButton_Click);
            // 
            // parolaTextBox
            // 
            this.parolaTextBox.Location = new System.Drawing.Point(536, 34);
            this.parolaTextBox.Name = "parolaTextBox";
            this.parolaTextBox.Size = new System.Drawing.Size(100, 20);
            this.parolaTextBox.TabIndex = 11;
            this.parolaTextBox.UseSystemPasswordChar = true;
            // 
            // parolaGresitaLabel
            // 
            this.parolaGresitaLabel.AutoSize = true;
            this.parolaGresitaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parolaGresitaLabel.ForeColor = System.Drawing.Color.Red;
            this.parolaGresitaLabel.Location = new System.Drawing.Point(533, 58);
            this.parolaGresitaLabel.Name = "parolaGresitaLabel";
            this.parolaGresitaLabel.Size = new System.Drawing.Size(126, 16);
            this.parolaGresitaLabel.TabIndex = 12;
            this.parolaGresitaLabel.Text = "*Parola este gresita";
            this.parolaGresitaLabel.Visible = false;
            // 
            // PaginaPrincipala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 571);
            this.Controls.Add(this.parolaGresitaLabel);
            this.Controls.Add(this.parolaTextBox);
            this.Controls.Add(this.modAdminButton);
            this.Controls.Add(this.afiseazaToateZborurile);
            this.Controls.Add(this.orasSosireLabel);
            this.Controls.Add(this.orasPlecareLabel);
            this.Controls.Add(this.butonCautareZboruri);
            this.Controls.Add(this.cautaOrasSosireTextBox);
            this.Controls.Add(this.cautareOrasPlecareTextBox);
            this.Controls.Add(this.zboruriListView);
            this.Name = "PaginaPrincipala";
            this.Text = "Pagina Principala";
            this.Load += new System.EventHandler(this.PaginaPrincipala_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView zboruriListView;
        private System.Windows.Forms.ColumnHeader orasPlecareLV;
        private System.Windows.Forms.ColumnHeader orasSosireLV;
        private System.Windows.Forms.ColumnHeader dataLV;
        private System.Windows.Forms.ColumnHeader oraPlecareLV;
        private System.Windows.Forms.ColumnHeader oraSosireLV;
        private System.Windows.Forms.ColumnHeader pretLV;
        private System.Windows.Forms.ColumnHeader rezervaLV;
        private System.Windows.Forms.TextBox cautareOrasPlecareTextBox;
        private System.Windows.Forms.TextBox cautaOrasSosireTextBox;
        private System.Windows.Forms.Button butonCautareZboruri;
        private System.Windows.Forms.Label orasPlecareLabel;
        private System.Windows.Forms.Label orasSosireLabel;
        private System.Windows.Forms.Button afiseazaToateZborurile;
        private System.Windows.Forms.Button modAdminButton;
        private System.Windows.Forms.TextBox parolaTextBox;
        private System.Windows.Forms.Label parolaGresitaLabel;
    }
}

