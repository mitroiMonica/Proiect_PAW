
namespace PROIECT_MITROI_DANIELA_MONICA
{
    partial class Admin
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.afișareSondajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afisareRaportFirma = new System.Windows.Forms.ToolStripMenuItem();
            this.afișareGraficeFirmăToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ștergereGraficeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvareGraficeBmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSondajeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.raportFirmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvSondaje = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.graficProcent = new System.Windows.Forms.Panel();
            this.graficLinie = new System.Windows.Forms.Panel();
            this.salvareAlDoileaGraficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PROIECT_MITROI_DANIELA_MONICA.Properties.Resources.admin;
            this.pictureBox1.Location = new System.Drawing.Point(16, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Admin Mode";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afișareSondajeToolStripMenuItem,
            this.afisareRaportFirma,
            this.afișareGraficeFirmăToolStripMenuItem,
            this.ștergereGraficeToolStripMenuItem,
            this.salvareGraficeBmpToolStripMenuItem,
            this.salvareAlDoileaGraficToolStripMenuItem,
            this.refreshSondajeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(891, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(209, 618);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // afișareSondajeToolStripMenuItem
            // 
            this.afișareSondajeToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afișareSondajeToolStripMenuItem.Name = "afișareSondajeToolStripMenuItem";
            this.afișareSondajeToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.afișareSondajeToolStripMenuItem.Text = "Afișare sondaje ";
            this.afișareSondajeToolStripMenuItem.Click += new System.EventHandler(this.afișareSondajeToolStripMenuItem_Click);
            // 
            // afisareRaportFirma
            // 
            this.afisareRaportFirma.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.afisareRaportFirma.Name = "afisareRaportFirma";
            this.afisareRaportFirma.Size = new System.Drawing.Size(186, 25);
            this.afisareRaportFirma.Text = "Afișare raport firmă";
            this.afisareRaportFirma.Click += new System.EventHandler(this.afisareRaportFirma_Click);
            // 
            // afișareGraficeFirmăToolStripMenuItem
            // 
            this.afișareGraficeFirmăToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afișareGraficeFirmăToolStripMenuItem.Name = "afișareGraficeFirmăToolStripMenuItem";
            this.afișareGraficeFirmăToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.afișareGraficeFirmăToolStripMenuItem.Text = "Afișare grafice firmă";
            this.afișareGraficeFirmăToolStripMenuItem.Click += new System.EventHandler(this.afișareGraficeFirmăToolStripMenuItem_Click);
            // 
            // ștergereGraficeToolStripMenuItem
            // 
            this.ștergereGraficeToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ștergereGraficeToolStripMenuItem.Name = "ștergereGraficeToolStripMenuItem";
            this.ștergereGraficeToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.ștergereGraficeToolStripMenuItem.Text = "Ștergere grafice";
            this.ștergereGraficeToolStripMenuItem.Click += new System.EventHandler(this.ștergereGraficeToolStripMenuItem_Click);
            // 
            // salvareGraficeBmpToolStripMenuItem
            // 
            this.salvareGraficeBmpToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiLight", 10.2F);
            this.salvareGraficeBmpToolStripMenuItem.Name = "salvareGraficeBmpToolStripMenuItem";
            this.salvareGraficeBmpToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.salvareGraficeBmpToolStripMenuItem.Text = "Salvare prim grafic";
            this.salvareGraficeBmpToolStripMenuItem.Click += new System.EventHandler(this.salvareGraficeBmpToolStripMenuItem_Click);
            // 
            // refreshSondajeToolStripMenuItem
            // 
            this.refreshSondajeToolStripMenuItem.Name = "refreshSondajeToolStripMenuItem";
            this.refreshSondajeToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.refreshSondajeToolStripMenuItem.Text = "Refresh sondaje";
            this.refreshSondajeToolStripMenuItem.Click += new System.EventHandler(this.refreshSondajeToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raportFirmaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 28);
            // 
            // raportFirmaToolStripMenuItem
            // 
            this.raportFirmaToolStripMenuItem.Name = "raportFirmaToolStripMenuItem";
            this.raportFirmaToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.raportFirmaToolStripMenuItem.Text = "Raport firma";
            this.raportFirmaToolStripMenuItem.Click += new System.EventHandler(this.raportFirmaToolStripMenuItem_Click);
            // 
            // tvSondaje
            // 
            this.tvSondaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvSondaje.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.tvSondaje.ContextMenuStrip = this.contextMenuStrip1;
            this.tvSondaje.Font = new System.Drawing.Font("Bahnschrift SemiLight", 9F);
            this.tvSondaje.LineColor = System.Drawing.Color.DarkKhaki;
            this.tvSondaje.Location = new System.Drawing.Point(9, 18);
            this.tvSondaje.Name = "tvSondaje";
            this.tvSondaje.Size = new System.Drawing.Size(430, 513);
            this.tvSondaje.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.splitContainer1.Location = new System.Drawing.Point(7, 75);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.splitContainer1.Panel1.Controls.Add(this.tvSondaje);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.DarkKhaki;
            this.splitContainer1.Panel2.Controls.Add(this.graficProcent);
            this.splitContainer1.Panel2.Controls.Add(this.graficLinie);
            this.splitContainer1.Size = new System.Drawing.Size(898, 543);
            this.splitContainer1.SplitterDistance = 460;
            this.splitContainer1.TabIndex = 2;
            // 
            // graficProcent
            // 
            this.graficProcent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graficProcent.BackColor = System.Drawing.Color.Cornsilk;
            this.graficProcent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graficProcent.Location = new System.Drawing.Point(22, 286);
            this.graficProcent.Name = "graficProcent";
            this.graficProcent.Size = new System.Drawing.Size(411, 245);
            this.graficProcent.TabIndex = 2;
            this.graficProcent.Paint += new System.Windows.Forms.PaintEventHandler(this.graficProcent_Paint);
            // 
            // graficLinie
            // 
            this.graficLinie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graficLinie.AutoScroll = true;
            this.graficLinie.BackColor = System.Drawing.Color.Cornsilk;
            this.graficLinie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graficLinie.Location = new System.Drawing.Point(22, 18);
            this.graficLinie.Name = "graficLinie";
            this.graficLinie.Size = new System.Drawing.Size(409, 251);
            this.graficLinie.TabIndex = 1;
            this.graficLinie.Paint += new System.Windows.Forms.PaintEventHandler(this.graficLinie_Paint);
            // 
            // salvareAlDoileaGraficToolStripMenuItem
            // 
            this.salvareAlDoileaGraficToolStripMenuItem.Name = "salvareAlDoileaGraficToolStripMenuItem";
            this.salvareAlDoileaGraficToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.salvareAlDoileaGraficToolStripMenuItem.Text = "Salvare al doilea grafic";
            this.salvareAlDoileaGraficToolStripMenuItem.Click += new System.EventHandler(this.salvareAlDoileaGraficToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(1100, 618);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Yu Gothic Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem afișareSondajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afisareRaportFirma;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem raportFirmaToolStripMenuItem;
        private System.Windows.Forms.TreeView tvSondaje;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem afișareGraficeFirmăToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ștergereGraficeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareGraficeBmpToolStripMenuItem;
        private System.Windows.Forms.Panel graficProcent;
        private System.Windows.Forms.Panel graficLinie;
        private System.Windows.Forms.ToolStripMenuItem refreshSondajeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvareAlDoileaGraficToolStripMenuItem;
    }
}