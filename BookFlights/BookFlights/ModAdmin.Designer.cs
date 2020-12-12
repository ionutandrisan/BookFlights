namespace ProiectBD
{
    partial class ModAdmin
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
            this.clientiListView = new System.Windows.Forms.ListView();
            this.idBiletLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numeClientLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prenumeClientLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orasPlecareLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orasSosireLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataPlecareLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rezervaLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cautaIdClientTextBox = new System.Windows.Forms.TextBox();
            this.idCientLabel = new System.Windows.Forms.Label();
            this.cautaClientButon = new System.Windows.Forms.Button();
            this.paginaPrincipalaButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientiListView
            // 
            this.clientiListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.clientiListView.BackColor = System.Drawing.SystemColors.Control;
            this.clientiListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientiListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idBiletLV,
            this.numeClientLV,
            this.prenumeClientLV,
            this.orasPlecareLV,
            this.orasSosireLV,
            this.dataPlecareLV,
            this.rezervaLV});
            this.clientiListView.GridLines = true;
            this.clientiListView.Location = new System.Drawing.Point(12, 88);
            this.clientiListView.Name = "clientiListView";
            this.clientiListView.Size = new System.Drawing.Size(756, 373);
            this.clientiListView.TabIndex = 1;
            this.clientiListView.UseCompatibleStateImageBehavior = false;
            this.clientiListView.View = System.Windows.Forms.View.Details;
            // 
            // idBiletLV
            // 
            this.idBiletLV.Text = "ID Bilet";
            this.idBiletLV.Width = 100;
            // 
            // numeClientLV
            // 
            this.numeClientLV.Text = "Nume";
            this.numeClientLV.Width = 100;
            // 
            // prenumeClientLV
            // 
            this.prenumeClientLV.Text = "Prenume";
            this.prenumeClientLV.Width = 100;
            // 
            // orasPlecareLV
            // 
            this.orasPlecareLV.Text = "Oras Plecare";
            this.orasPlecareLV.Width = 100;
            // 
            // orasSosireLV
            // 
            this.orasSosireLV.Text = "Oras sosire";
            this.orasSosireLV.Width = 100;
            // 
            // dataPlecareLV
            // 
            this.dataPlecareLV.Text = "Data Plecare";
            this.dataPlecareLV.Width = 130;
            // 
            // rezervaLV
            // 
            this.rezervaLV.Text = "";
            this.rezervaLV.Width = 120;
            // 
            // cautaIdClientTextBox
            // 
            this.cautaIdClientTextBox.Location = new System.Drawing.Point(76, 47);
            this.cautaIdClientTextBox.Name = "cautaIdClientTextBox";
            this.cautaIdClientTextBox.Size = new System.Drawing.Size(100, 20);
            this.cautaIdClientTextBox.TabIndex = 2;
            // 
            // idCientLabel
            // 
            this.idCientLabel.AutoSize = true;
            this.idCientLabel.Location = new System.Drawing.Point(12, 50);
            this.idCientLabel.Name = "idCientLabel";
            this.idCientLabel.Size = new System.Drawing.Size(58, 13);
            this.idCientLabel.TabIndex = 3;
            this.idCientLabel.Text = "CNP Client";
            // 
            // cautaClientButon
            // 
            this.cautaClientButon.Location = new System.Drawing.Point(182, 44);
            this.cautaClientButon.Name = "cautaClientButon";
            this.cautaClientButon.Size = new System.Drawing.Size(91, 23);
            this.cautaClientButon.TabIndex = 4;
            this.cautaClientButon.Text = "Cauta client";
            this.cautaClientButon.UseVisualStyleBackColor = true;
            this.cautaClientButon.Click += new System.EventHandler(this.cautaClientButon_Click);
            // 
            // paginaPrincipalaButon
            // 
            this.paginaPrincipalaButon.Location = new System.Drawing.Point(620, 45);
            this.paginaPrincipalaButon.Name = "paginaPrincipalaButon";
            this.paginaPrincipalaButon.Size = new System.Drawing.Size(148, 23);
            this.paginaPrincipalaButon.TabIndex = 5;
            this.paginaPrincipalaButon.Text = "Pagina Principala";
            this.paginaPrincipalaButon.UseVisualStyleBackColor = true;
            this.paginaPrincipalaButon.Click += new System.EventHandler(this.paginaPrincipalaButon_Click);
            // 
            // ModAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 473);
            this.Controls.Add(this.paginaPrincipalaButon);
            this.Controls.Add(this.cautaClientButon);
            this.Controls.Add(this.idCientLabel);
            this.Controls.Add(this.cautaIdClientTextBox);
            this.Controls.Add(this.clientiListView);
            this.Name = "ModAdmin";
            this.Text = "ModAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView clientiListView;
        private System.Windows.Forms.ColumnHeader idBiletLV;
        private System.Windows.Forms.ColumnHeader numeClientLV;
        private System.Windows.Forms.ColumnHeader prenumeClientLV;
        private System.Windows.Forms.ColumnHeader orasPlecareLV;
        private System.Windows.Forms.ColumnHeader orasSosireLV;
        private System.Windows.Forms.ColumnHeader dataPlecareLV;
        private System.Windows.Forms.ColumnHeader rezervaLV;
        private System.Windows.Forms.TextBox cautaIdClientTextBox;
        private System.Windows.Forms.Label idCientLabel;
        private System.Windows.Forms.Button cautaClientButon;
        private System.Windows.Forms.Button paginaPrincipalaButon;
    }
}