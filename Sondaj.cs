using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PROIECT_MITROI_DANIELA_MONICA
{

    public partial class Sondaj : Form
    {
        string conexiuneBD = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Sondaje.accdb";
        bool butonApasat = false;
        List<Companie> listaCompaniiPartenere;
        List<SondajClass> listaSondaje;
        public Sondaj()
        {
            InitializeComponent();
            listaCompaniiPartenere = citireCompaniiPartenere();
            listaSondaje = new List<SondajClass>();
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

        private void Sondaj_Load(object sender, EventArgs e)
        {
            string mesaj = "Mulțumim pentru participare!" +
                Environment.NewLine + "Este foarte important să răspundeți sincer.\n" +
                "Datele personale nu vor fi stocate, așadar nu se va cunoaște identitatea persoanei care a completat formularul.";
            tbTextPrincipal.Text = mesaj;
            cbCompanii.DataSource = listaCompaniiPartenere;
        }

        private void Sondaj_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (butonApasat == false)
            {
                if (MessageBox.Show("Dacă închideți acum, răspunsurile date până în acest moment se vor șterge!", "Atenție",
                      MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                    this.Owner.Show();
                }
            }

        }
        private void cbCompanii_TextUpdate(object sender, EventArgs e)
        {
            if (cbCompanii.FindString(cbCompanii.Text) == -1)
                errorProvider1.SetError(cbCompanii, "Compania este invalidă!");
            else
                errorProvider1.Clear();
        }

        private void btnTrimite_Click(object sender, EventArgs e)
        {
            //verific ca pe fiecare groupBox un radioButton este bifat
            if (!(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked))
                errorProvider1.SetError(groupBox2, "Bifați mai întâi ceva!");
            else if (!(radioButton6.Checked || radioButton7.Checked || radioButton8.Checked || radioButton9.Checked || radioButton10.Checked))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(groupBox3, "Bifați mai întâi ceva!");
            }
            else if (!(radioButton11.Checked || radioButton12.Checked || radioButton13.Checked || radioButton14.Checked || radioButton15.Checked))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(groupBox4, "Bifați mai întâi ceva!");
            }
            else if (!(radioButton16.Checked || radioButton17.Checked))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(groupBox5, "Bifați una din cele două opțiuni!");
            }
            else if (!(radioButton18.Checked || radioButton19.Checked))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(groupBox6, "Bifați una din cele două opțiuni!");
            }
            else if (!(radioButton20.Checked || radioButton21.Checked))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(groupBox8, "Bifați una din cele două opțiuni!");
            }
            else
            {
                errorProvider1.Clear();
                Companie comp = new Companie();
                foreach (var c in listaCompaniiPartenere)
                {
                    if (c.Denumire == cbCompanii.Text)
                        comp = (Companie)c.Clone();
                }
                string DaNu1 = groupBox5.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text; //asa se poate lua o data legata de un element din group box
                string DaNu2 = groupBox6.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
                string DaNu3 = groupBox8.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
                bool b1, b2, b3;
                if (DaNu1 == "Da")
                    b1 = true;
                else
                    b1 = false;
                if (DaNu2 == "Da")
                    b2 = true;
                else
                    b2 = false;
                if (DaNu3 == "Da")
                    b3 = true;
                else
                    b3 = false;

                SondajClass sondaj = new SondajClass(
                    comp,
                    Convert.ToInt16(groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text),
                    Convert.ToInt16(groupBox3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text),
                    Convert.ToInt16(groupBox4.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text),
                    b1, b2, b3
                    );
                listaSondaje.Add(sondaj);
                OleDbConnection conexiune = new OleDbConnection(conexiuneBD);
                OleDbCommand interogare = new OleDbCommand();
                try
                {
                    conexiune.Open();
                    interogare.CommandText = "SELECT MAX(ID) FROM Sondaje";
                    interogare.Connection = conexiune;
                    int id;
                    if (interogare.ExecuteScalar().ToString() == string.Empty) id = 0;
                    else
                        id = Convert.ToInt32(interogare.ExecuteScalar());
                    interogare.CommandText = "INSERT INTO Sondaje(ID,Companie, Fericire, Prietenie,Remunerare,Suprasolicitat, ConteazaOpinia,SchimbareProfesie) VALUES(?,?,?,?,?,?,?,?)";
                    interogare.Parameters.Add("ID", OleDbType.Integer).Value = id + 1;
                    interogare.Parameters.Add("Companie", OleDbType.Char).Value = sondaj.Companie.Denumire;
                    interogare.Parameters.Add("Fericire", OleDbType.Integer).Value = sondaj.Fericire;
                    interogare.Parameters.Add("Prietenie", OleDbType.Integer).Value = sondaj.Prietenie;
                    interogare.Parameters.Add("Remunerare", OleDbType.Integer).Value = sondaj.Remunerare;
                    interogare.Parameters.Add("Suprasolicitat", OleDbType.Boolean).Value = sondaj.Suprasolicitat;
                    interogare.Parameters.Add("ConteazaOpinia", OleDbType.Boolean).Value = sondaj.ConteazaOpinia;
                    interogare.Parameters.Add("SchimbareProfesie", OleDbType.Boolean).Value = sondaj.SchimbareProfesie;
                    interogare.ExecuteNonQuery();
                    MessageBox.Show("Formularul a fost trimis cu succes.\nMulțumim!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    butonApasat = true;
                    this.Owner.Show();
                    this.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Sondajul nu a putut fi salvat!\nEroare: " + err.Message);
                }
                finally
                {
                    conexiune.Close();
                }
            }
        }

    }
}
