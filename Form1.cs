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

namespace PROIECT_MITROI_DANIELA_MONICA
{
    public partial class Form1 : Form
    {
        List<DateConectare> listaUtilizatori;
        public Form1()
        {
            InitializeComponent();
            listaUtilizatori = new List<DateConectare>(citireDateUtilizatori());
        }
        private List<DateConectare> citireDateUtilizatori()
        {
            List<DateConectare> dc = new List<DateConectare>();
            FileStream fs = new FileStream("dateConectare.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string linie;
            while ((linie = sr.ReadLine()) != null)
            {
                dc.Add(new DateConectare(linie));
            }
            sr.Close();
            fs.Close();
            return dc;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "Admin" && tbParola.Text == "admin")
            {
                tbParola.Clear();
                tbUsername.Clear();
                tbUsername.Focus();
                Admin admin = new Admin() { Owner = this };
                admin.Show();
                this.Hide();
            }
            else
            {
                bool verifica = false;
                foreach (DateConectare dc in listaUtilizatori)
                {
                    if (dc.Username == tbUsername.Text && dc.Parola == tbParola.Text)
                    { 
                        Sondaj sondaj = new Sondaj() { Owner = this }; //am facut owner-ul formei sondaj sa fie this
                        tbParola.Clear();
                        tbUsername.Clear();
                        tbUsername.Focus();
                        sondaj.Show();
                        this.Hide();
                        verifica = true;
                        break;
                    }
                }
                if (verifica == false)
                {
                    MessageBox.Show("Parola sau numele de utilizator este incorectă!",
                        "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                tbParola.Focus();
        }

        private void tbParola_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                button1_Click(sender, EventArgs.Empty);
        }

    }
}
