using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for OmiljenaRep.xaml
    /// </summary>
    public partial class OmiljenaReprezentacija : Window
    {
        List<Country> listaDrzava { get; set; }
        public string OmRep { get; set; }
        public string awTeam { get; set; }
        public string htTeam { get; set; }
        public Repo repo = new Repo();
        public string txtpathRepka = @"C:\Users\Fran\source\repos\WinFormsTest\omiljenaRep.txt";


        public OmiljenaReprezentacija()
        {
            InitializeComponent();
            LoadOmRep();
            LoadComboboxAsync();
        }

        private async void LoadComboboxAsync()
        {
            Task<List<Country>> task = new Task<List<Country>>(posjetiteljiUcitaj);
            task.Start();
            listaDrzava = await task;
            LoadCombobox();
        }

        private List<Country> posjetiteljiUcitaj()
        {
            return repo.GetCountries();
        }

        private void LoadCombobox()
        {
           
            foreach (Country c in listaDrzava)
            {
                ComboboxOm.Items.Add(c.CountryCountry + "," + c.FifaCode);
                ComboboxAwTeam.Items.Add(c.CountryCountry + "," + c.FifaCode);
            }
        }

        private void LoadOmRep()
        {
            if (File.Exists(txtpathRepka))
            {
                using (StreamReader sr = new StreamReader(txtpathRepka))
                {
                    OmRep = sr.ReadLine();
                    lblOmRep.Content = OmRep;
                }
            }
        }

        private void OmiljenaRep_Click(object sender, RoutedEventArgs e)
        {
          lblOmRep.Content=ComboboxOm.SelectedItem.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblProtivnik.Content = ComboboxAwTeam.SelectedItem.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //rep odlazak u prikaz
            string a = lblOmRep.Content.ToString();
            string b = ComboboxAwTeam.SelectedItem.ToString();
            string[] c = b.Split(',');
            awTeam = c[1];
             b = ComboboxOm.SelectedItem.ToString();
             c = b.Split(',');
            htTeam = c[1];
            PrikazRepki prk = new PrikazRepki(htTeam,awTeam);
            prk.Show();
            this.Close();
            


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Izlaz iz = new Izlaz();
            iz.Show();
            this.Close();
        }
    }
}
