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
        public List<Country> listaCountries  { get; set; }
        public string fifaCode { get; set; }
        public Form1()
        {
            InitializeComponent();
            Form_Lang form_l = new Form_Lang();
            label1.Text = form_l.txtJezik;
            getContriesAsync();
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
            label2.Text = stringSplit[1];
            fifaCode = stringSplit[1];
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
