using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        public string txtpath = @"C:\Users\Fran\source\repos\WinFormsTest\lang.txt";
        public string txtpathRepka = @"C:\Users\Fran\source\repos\WinFormsTest\omiljenaRep.txt";
        public List<Country> listaCountries  { get; set; }
        public string fifaCode { get; set; }
        public Form1()
        {
            InitializeComponent();
            ProvjeriImaLiDatoteka();
            omiljenaReprezentacijaPoKodu();
            Form_Lang form_l = new Form_Lang();
            label1.Text = form_l.txtJezik;
            getContriesAsync();
        }

        private void omiljenaReprezentacijaPoKodu()
        {
            if (File.Exists(txtpathRepka))
            {
                using (StreamReader sr = new StreamReader(txtpathRepka))
                {
                    omRep.Text = sr.ReadLine();
                }

            }
            else
            {
                omRep.Text = "None";
            }
        }

        private void ProvjeriImaLiDatoteka()
        {
            if (!File.Exists(txtpath))
            {
                
                //Make sure I am kept hidden
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                Visible = false;

                InitializeComponent();

                //Open a managed form - the one the user sees..
                var form2 = new Form_Lang();
                form2.Show();
            }

            
        }

        private void openForm2()
        {
            Application.Run(new Form_Lang());
        }

        private async void getContriesAsync()
        {
            Task<List<Country>> task = new Task<List<Country>>(getDrzave);
            task.Start();
            listaCountries = await task;
            LoadCountries();

        }

        private List<Country> getDrzave()
        {
            Repo repo = new Repo();
            return repo.GetCountries();
        }

        private void LoadCountries()
        {
            foreach(Country c in listaCountries)
            {
                comboBox1.Items.Add(c.CountryCountry+","+c.FifaCode);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string cbValue = comboBox1.SelectedItem.ToString();
            string[] stringSplit = cbValue.Split(',');
            fifaCode = stringSplit[1];
            if (File.Exists(txtpathRepka) || !File.Exists(txtpathRepka))
            {
                using (StreamWriter sr = new StreamWriter(txtpathRepka))
                {
                    sr.WriteLine(fifaCode);
                }

            }
            this.Close();
            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            fifaCode = omRep.Text.ToString();
            this.Close();
            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            
        }
        private void openForm()
        {
            Application.Run(new Form2(fifaCode));

        }

    }
}
