using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROIECT_MITROI_DANIELA_MONICA
{
    public partial class Admin : Form
    {
        Button btnOK = new Button();
        string conexiuneBD = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Sondaje.accdb";
        List<SondajClass> listaSondaje;
        List<Companie> listaCompaniiPartenere;

        Form alegereFirma;
        RadioButton[] radiosButtons;
        string CompanieAleasa = string.Empty;

        bool verificaApasareGrafic;
        SolidBrush pensula_grafic_procente;
        Pen creion_grafic_procente;

        public Admin()
        {
            InitializeComponent();
            listaSondaje = new List<SondajClass>();
            listaCompaniiPartenere = new List<Companie>();
            btnOK.Click += apasat;
            verificaApasareGrafic = false;
        }
        private List<Companie> citireCompaniiPartenere()
        {
            List<Companie> companii = new List<Companie>();
            OleDbConnection conexiune = new OleDbConnection(conexiuneBD);
            OleDbCommand interogare = new OleDbCommand("SELECT * FROM Companii", conexiune);

            try
            {
                conexiune.Open();
                OleDbDataReader reader = interogare.ExecuteReader();
                while (reader.Read())
                {
                    string denumire = reader["Denumire"].ToString();
                    bool multinationala = bool.Parse(reader["Multinationala"].ToString());
                    int numar_angajati = int.Parse(reader["Numar_angajati"].ToString());
                    companii.Add(new Companie(denumire, multinationala, numar_angajati));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexiune.Close();
            }

            return companii;
        }
        private List<SondajClass> citireSondaje()
        {
            List<SondajClass> listaCuSondaje = new List<SondajClass>();
            OleDbConnection conexiune = new OleDbConnection(conexiuneBD);
            OleDbCommand interogare = new OleDbCommand("SELECT Companie,Multinationala,c.Numar_angajati,Fericire,Prietenie,Remunerare," +
                "Suprasolicitat,ConteazaOpinia,SchimbareProfesie FROM Sondaje s, Companii c WHERE s.Companie=c.Denumire", conexiune);


            try
            {
                SondajClass s;
                conexiune.Open();
                OleDbDataReader reader = interogare.ExecuteReader();
                while (reader.Read())
                {
                    string denumireCompanie = reader["Companie"].ToString();
                    bool multinationala = false;
                    if (reader["Multinationala"].ToString() == "true")
                        multinationala = true;
                    int nr_ang = Convert.ToInt32(reader["Numar_angajati"].ToString());
                    short fericire = short.Parse(reader["Fericire"].ToString());
                    short prietenie = short.Parse(reader["Prietenie"].ToString());

                    short remunerare = short.Parse(reader["Remunerare"].ToString());

                    bool suprasolicitare = false;
                    bool conteazaOpinie = false;
                    bool schimbaProfesie = false;
                    if (reader["Suprasolicitat"].ToString().ToLower() == "true")
                        suprasolicitare = true;
                    if (reader["ConteazaOpinia"].ToString().ToLower() == "true")
                        conteazaOpinie = true;
                    if (reader["SchimbareProfesie"].ToString().ToLower() == "true")
                        schimbaProfesie = true;
                    s = new SondajClass(new Companie(denumireCompanie, multinationala, nr_ang), fericire, prietenie, remunerare, suprasolicitare, conteazaOpinie, schimbaProfesie);
                    listaCuSondaje.Add(s);

                }
                reader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("A apărut o eroare la baza de date!\n" + "Eroare: " + err.Message, "Atenție!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexiune.Close();
            }

            return listaCuSondaje;
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            listaCompaniiPartenere = citireCompaniiPartenere();
            listaSondaje = citireSondaje();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }

        private void afișareSondajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tvSondaje.Nodes.Clear();

            TreeNode parinte = new TreeNode("Sondaje");
            foreach (Companie c in listaCompaniiPartenere)
            {
                parinte.Nodes.Add(c.Denumire);
            }
            var noduriCopii = parinte.Nodes;
            foreach (TreeNode t in noduriCopii)
            {
                foreach (SondajClass s in listaSondaje)
                    if (s.Companie.Denumire == t.Text)
                        t.Nodes.Add(s.ToString());
            }
            tvSondaje.Nodes.Add(parinte);
        }

        private void raportFirmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvSondaje.SelectedNode != null && tvSondaje.SelectedNode.Text != "Sondaje" && tvSondaje.SelectedNode.Parent.Text == "Sondaje")
            {
                TreeNode nodSelectat = tvSondaje.SelectedNode;
                TreeNodeCollection sondaje = nodSelectat.Nodes;
                if (sondaje.Count == 0)
                {
                    MessageBox.Show("Compania aleasa nu are inca sondaje inregitrate",
                                "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MatriceObservatii mo = new MatriceObservatii(nodSelectat.Text);
                    int nr_sondaje = 0;
                    foreach (TreeNode n in sondaje)
                    {
                        mo.MedieFericire = mo.MedieFericire + Convert.ToInt32(n.Text.Split(',')[1].Substring(3));
                        mo.MediePrietenie = mo.MediePrietenie + Convert.ToInt32(n.Text.Split(',')[2].Substring(3));
                        mo.MedieRemunerare = mo.MedieRemunerare + Convert.ToInt32(n.Text.Split(',')[3].Substring(3));
                        if (bool.Parse(n.Text.Split(',')[4].Substring(3).ToLower()))
                        {
                            mo.NrPersSuprasolicitate++;
                        }
                        if (bool.Parse(n.Text.Split(',')[5].Substring(3).ToLower()))
                        {
                            mo.NrPersConteazaOpinia++;
                        }
                        if (bool.Parse(n.Text.Split(',')[6].Substring(4).ToLower()))
                        {
                            mo.NrPersSchimbaProfesia++;
                        }
                        nr_sondaje++;
                    }
                    mo.MedieFericire = mo.MedieFericire / nr_sondaje;
                    mo.MediePrietenie = mo.MediePrietenie / nr_sondaje;
                    mo.MedieRemunerare = mo.MedieRemunerare / nr_sondaje;

                    MessageBox.Show("NUMAR TOTAL DE SONDAJE INREGISTRATE: " + nr_sondaje + "\n\n" + mo.ToString(),
                            mo.DenumireCompanie, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Nu ati ales o companie!", "Atentie!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MatriceObservatii creareMatriceObservatii(string denumireFirma, out int nr_sondaje)
        {
            MatriceObservatii mo = new MatriceObservatii(CompanieAleasa);
            nr_sondaje = 0;
            foreach (SondajClass s in listaSondaje)
            {
                if (s.Companie.Denumire == denumireFirma)
                {
                    mo.MedieFericire = mo.MedieFericire + s.Fericire;
                    mo.MediePrietenie = mo.MediePrietenie + s.Prietenie;
                    mo.MedieRemunerare = mo.MedieRemunerare + s.Remunerare;
                    if (s.Suprasolicitat)
                    {
                        mo.NrPersSuprasolicitate++;
                    }
                    if (s.ConteazaOpinia)
                    {
                        mo.NrPersConteazaOpinia++;
                    }
                    if (s.SchimbareProfesie)
                    {
                        mo.NrPersSchimbaProfesia++;
                    }
                    nr_sondaje++;
                }
            }
            mo.MedieFericire = mo.MedieFericire / nr_sondaje;
            mo.MediePrietenie = mo.MediePrietenie / nr_sondaje;
            mo.MedieRemunerare = mo.MedieRemunerare / nr_sondaje;
            if (nr_sondaje != 0)
                return mo;
            else
                return null;
        }

        private void apasat(object sender, EventArgs e)
        {
            bool verificaRadioBtn = false;
            RadioButton celSelectat = new RadioButton();
            foreach (RadioButton r in radiosButtons)
            {
                if (r.Checked)
                {
                    celSelectat = r;
                    verificaRadioBtn = true;
                    break;
                }
            }
            if (!verificaRadioBtn)
            {
                MessageBox.Show("Alegeti mai intai o companie partenera", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CompanieAleasa = celSelectat.Text;
                alegereFirma.Close();
            }
        }
        private void AlegereFirma_FormClosed1(object sender, FormClosedEventArgs e)
        {
            if (CompanieAleasa == string.Empty)
            {
                MessageBox.Show("Nicio companie nu a fost selectata!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int nr_sondaje;
                MatriceObservatii mo = creareMatriceObservatii(CompanieAleasa, out nr_sondaje);
                if (mo != null)
                    MessageBox.Show("NUMAR TOTAL DE SONDAJE INREGISTRATE: " + nr_sondaje + "\n\n" + mo.ToString(),
                        mo.DenumireCompanie, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Nu exista inca sondaje inregistrate pentru firma " + CompanieAleasa, "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void afisareRaportFirma_Click(object sender, EventArgs e)
        {
            alegereFirma = new AlegereFirma();
            alegereFirma.FormClosed += AlegereFirma_FormClosed1;
            CompanieAleasa = string.Empty;

            radiosButtons = new RadioButton[listaCompaniiPartenere.Count];
            for (int i = 0; i < radiosButtons.Length; i++)
            {
                radiosButtons[i] = new RadioButton();
                radiosButtons[i].Location = new Point(alegereFirma.Location.X + 35, alegereFirma.Location.Y + 35 * (i + 1));
                radiosButtons[i].Font = new Font(FontFamily.GenericSansSerif, 9);
                radiosButtons[i].Size = new Size(8 * listaCompaniiPartenere[i].Denumire.Length, radiosButtons[i].Height);
                radiosButtons[i].Text = listaCompaniiPartenere[i].Denumire.ToString();
                alegereFirma.Controls.Add(radiosButtons[i]);
            }
            btnOK.Text = "OK";
            btnOK.Location = new Point(radiosButtons[listaCompaniiPartenere.Count - 1].Location.X + 40,
                   radiosButtons[listaCompaniiPartenere.Count - 1].Location.Y + 40);
            btnOK.Margin = new Padding(30);
            alegereFirma.Controls.Add(btnOK);
            alegereFirma.ShowDialog();
        }
        private void AlegereFirma_FormClosed2(object sender, FormClosedEventArgs e)
        {
            if (CompanieAleasa == string.Empty)
            {
                MessageBox.Show("Nicio companie nu a fost selectata!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                verificaApasareGrafic = false;
                ștergereGraficeToolStripMenuItem_Click(sender, e);
            }
            else
            {
                int nr_sondaje;
                MatriceObservatii mo = creareMatriceObservatii(CompanieAleasa, out nr_sondaje);
                if (mo != null)
                {
                    graficProcent.Invalidate();
                    graficLinie.Invalidate();
                    verificaApasareGrafic = true;
                }
                else
                {
                    ștergereGraficeToolStripMenuItem_Click(sender, e);
                    MessageBox.Show("Nu exista inca sondaje inregistrate pentru firma " + CompanieAleasa, "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void afișareGraficeFirmăToolStripMenuItem_Click(object sender, EventArgs e)
        {
            creion_grafic_procente = null;
            pensula_grafic_procente = null;

            alegereFirma = new AlegereFirma();
            alegereFirma.FormClosed += AlegereFirma_FormClosed2;
            CompanieAleasa = string.Empty;

            radiosButtons = new RadioButton[listaCompaniiPartenere.Count];
            for (int i = 0; i < radiosButtons.Length; i++)
            {
                radiosButtons[i] = new RadioButton();
                radiosButtons[i].Location = new Point(alegereFirma.Location.X + 35, alegereFirma.Location.Y + 35 * (i + 1));
                radiosButtons[i].Font = new Font(FontFamily.GenericSansSerif, 9);
                radiosButtons[i].Size = new Size(8 * listaCompaniiPartenere[i].Denumire.Length, radiosButtons[i].Height);
                radiosButtons[i].Text = listaCompaniiPartenere[i].Denumire.ToString();
                alegereFirma.Controls.Add(radiosButtons[i]);
            }
            btnOK.Text = "OK";
            btnOK.Location = new Point(radiosButtons[listaCompaniiPartenere.Count - 1].Location.X + 40,
                   radiosButtons[listaCompaniiPartenere.Count - 1].Location.Y + 40);
            btnOK.Margin = new Padding(30);
            alegereFirma.Controls.Add(btnOK);
            alegereFirma.ShowDialog();
        }

        private void graficLinie_Paint(object sender, PaintEventArgs e)
        {

            if (verificaApasareGrafic)
            {
                //verificaApasareGrafic = false;
                int nr_sondaje;
                MatriceObservatii mo = creareMatriceObservatii(CompanieAleasa, out nr_sondaje);
                int margine = 20;
                float distantaPuncteInaltime = (graficLinie.Height - 2 * margine) / 5;
                float distantaPuncteLatime = (graficLinie.Width - 2 * margine) / 3;
                Graphics grafic = e.Graphics;
                if (creion_grafic_procente == null)
                {
                    ColorDialog cd = new ColorDialog();

                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        creion_grafic_procente = new Pen(cd.Color, 3.5f);
                    }
                    else
                        creion_grafic_procente = new Pen(Color.Black, 3.5f);
                }
                PointF[] puncte = new PointF[3];


                puncte[0] = new PointF(margine, graficLinie.Height - 1 * margine - distantaPuncteInaltime * mo.MedieFericire);
                puncte[1] = new PointF(puncte[0].X + distantaPuncteLatime, graficLinie.Height - 1 * margine - distantaPuncteInaltime * mo.MediePrietenie);
                puncte[2] = new PointF(puncte[1].X + distantaPuncteLatime, graficLinie.Height - 1 * margine - distantaPuncteInaltime * mo.MedieRemunerare);

                Rectangle legenda = new Rectangle();
                legenda.Location = new Point(graficLinie.Location.X + graficLinie.Width - 6 * margine,
                    graficLinie.Location.Y + graficLinie.Height - 7 * margine / 2);
                legenda.Width = 85;
                legenda.Height = 45;


                grafic.FillRectangle(Brushes.PaleGoldenrod, legenda);
                grafic.DrawString("Legenda: ", new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, legenda.X, legenda.Y - 16);
                grafic.DrawLine(creion_grafic_procente, puncte[0], puncte[1]);
                grafic.DrawLine(creion_grafic_procente, puncte[1], puncte[2]);

                grafic.FillEllipse(Brushes.GreenYellow, puncte[0].X - 5, puncte[0].Y - 5, 10, 10);
                grafic.FillEllipse(Brushes.IndianRed, puncte[1].X - 5, puncte[1].Y - 5, 10, 10);
                grafic.FillEllipse(Brushes.DarkTurquoise, puncte[2].X - 5, puncte[2].Y - 5, 10, 10);
                grafic.DrawString(mo.MedieFericire.ToString(), new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, puncte[0].X - 10, puncte[0].Y - 20);
                grafic.DrawString(mo.MediePrietenie.ToString(), new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, puncte[1].X - 10, puncte[1].Y - 20);
                grafic.DrawString(mo.MedieRemunerare.ToString(), new Font(FontFamily.GenericSansSerif, 9), Brushes.Black, puncte[2].X - 10, puncte[2].Y - 20);


                grafic.FillEllipse(Brushes.GreenYellow, legenda.X + 3, legenda.Y + 3, 10, 10);
                grafic.FillEllipse(Brushes.IndianRed, legenda.X + 3, legenda.Y + 17, 10, 10);
                grafic.FillEllipse(Brushes.DarkTurquoise, legenda.X + 3, legenda.Y + 31, 10, 10);
                grafic.DrawString("Nivel fericire", new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, legenda.X + 16, legenda.Y + 3);
                grafic.DrawString("Nivel prietenie", new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, legenda.X + 16, legenda.Y + 17);
                grafic.DrawString("Nivel opinie", new Font(FontFamily.GenericSansSerif, 7), Brushes.Black, legenda.X + 16, legenda.Y + 31);

                grafic.TranslateTransform(graficProcent.Width - margine, graficProcent.ClientRectangle.Y + margine);
                grafic.RotateTransform(90);
                grafic.DrawString(CompanieAleasa, new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, graficProcent.ClientRectangle.X, graficProcent.ClientRectangle.Y);

            }
        }

        private void graficProcent_Paint(object sender, PaintEventArgs e)
        {
            if (verificaApasareGrafic)
            {
                // verificaApasareGrafic = false;
                int nr_sondaje;
                MatriceObservatii mo = creareMatriceObservatii(CompanieAleasa, out nr_sondaje);
                int margine = 20;
                float distantaInaltime = (graficProcent.ClientSize.Height - 3 * margine);
                float distantaLatime = (graficProcent.ClientSize.Width - 2 * margine) / 6;
                Graphics grafic = e.Graphics;
                if (pensula_grafic_procente == null)
                {
                    ColorDialog cd = new ColorDialog();
                    if (cd.ShowDialog() == DialogResult.OK)
                    {
                        pensula_grafic_procente = new SolidBrush(cd.Color);
                    }
                    else
                        pensula_grafic_procente = new SolidBrush(Color.CadetBlue);
                }

                RectangleF[] bars = new RectangleF[3];
                bars[0] = new RectangleF(graficProcent.ClientRectangle.X + margine, graficProcent.ClientRectangle.Y + 1.5f * margine +
                    (float)(nr_sondaje - mo.NrPersSuprasolicitate) / nr_sondaje * distantaInaltime,
                    distantaLatime, (float)(mo.NrPersSuprasolicitate) / nr_sondaje * distantaInaltime);
                bars[1] = new RectangleF(bars[0].X + 2 * distantaLatime, graficProcent.ClientRectangle.Y + 1.5f * margine +
                   (float)(nr_sondaje - mo.NrPersConteazaOpinia) / nr_sondaje * distantaInaltime,
                   distantaLatime, (float)(mo.NrPersConteazaOpinia) / nr_sondaje * distantaInaltime);
                bars[2] = new RectangleF(bars[1].X + 2 * distantaLatime, graficProcent.ClientRectangle.Y + 1.5f * margine +
                   (float)(nr_sondaje - mo.NrPersSchimbaProfesia) / nr_sondaje * distantaInaltime,
                   distantaLatime, (float)(mo.NrPersSchimbaProfesia) / nr_sondaje * distantaInaltime);


                grafic.FillRectangle(pensula_grafic_procente, bars[0]);
                grafic.FillRectangle(pensula_grafic_procente, bars[1]);
                grafic.FillRectangle(pensula_grafic_procente, bars[2]);

                grafic.DrawString((float)(mo.NrPersSuprasolicitate) / nr_sondaje * 100 + "%", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, bars[0].X + bars[0].Width / 2 - 13, bars[0].Y - margine);
                grafic.DrawString((float)(mo.NrPersConteazaOpinia) / nr_sondaje * 100 + "%", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, bars[1].X + bars[1].Width / 2 - 13, bars[1].Y - margine);
                grafic.DrawString((float)(mo.NrPersSchimbaProfesia) / nr_sondaje * 100 + "%", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, bars[2].X + bars[2].Width / 2 - 13, bars[2].Y - margine);

                grafic.DrawString("Suprasolicitare", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, bars[0].X + bars[1].Width / 13 - "suprasolicitare".Length / (bars[1].Width / 40f), bars[0].Y + bars[0].Height + margine / 4);
                grafic.DrawString("Opinie", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, bars[1].X + bars[1].Width / 5, bars[1].Y + bars[1].Height + margine / 4);
                grafic.DrawString("Profesie", new Font(FontFamily.GenericSansSerif, 8), Brushes.Black, bars[2].X + bars[2].Width / 5, bars[2].Y + bars[2].Height + margine / 4);

                grafic.TranslateTransform(graficProcent.Width - margine, graficProcent.ClientRectangle.Y + margine);
                grafic.RotateTransform(90);
                grafic.DrawString(CompanieAleasa, new Font(FontFamily.GenericSansSerif, 11), Brushes.Black, graficProcent.ClientRectangle.X, graficProcent.ClientRectangle.Y);

            }
        }

        private void ștergereGraficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verificaApasareGrafic = false;
            graficLinie.Invalidate();
            graficProcent.Invalidate();
        }

        private void refreshSondajeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                tvSondaje.Nodes.Clear();
                ștergereGraficeToolStripMenuItem_Click(sender, e);
                listaSondaje = citireSondaje();
                listaCompaniiPartenere = citireCompaniiPartenere();
            }
            catch (Exception err)
            {
                MessageBox.Show("A aparut o eroare!\n" + err.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("S-au reincarcat datele cu sondaje", "Informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salvareGraficeBmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (verificaApasareGrafic)
            {
                Bitmap bmp = new Bitmap(graficLinie.ClientRectangle.Width + 2, graficLinie.ClientRectangle.Height + 2);
                graficLinie.DrawToBitmap(bmp, new Rectangle(graficLinie.ClientRectangle.X, graficLinie.ClientRectangle.Y,
                    graficLinie.ClientRectangle.Width + 2, graficLinie.ClientRectangle.Height + 2));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "(bmp)|*.bmp";
                sfd.FileName = "prim_grafic";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName);
                }
                bmp.Dispose();
            }
            else
            {
                MessageBox.Show("Inca nu aveti grafic desenat.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void salvareAlDoileaGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (verificaApasareGrafic)
            {
                Bitmap bmp = new Bitmap(graficProcent.Width + 2, graficProcent.Height + 2);
                graficProcent.DrawToBitmap(bmp, new Rectangle(graficProcent.ClientRectangle.X, graficProcent.ClientRectangle.Y,
                    graficProcent.ClientRectangle.Width + 2, graficProcent.ClientRectangle.Height + 2));
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "(bmp)|*.bmp";
                sfd.FileName = "al_doilea_grafic";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName);
                }
                bmp.Dispose();
            }
            else
            {
                MessageBox.Show("Inca nu aveti grafic desenat.", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
