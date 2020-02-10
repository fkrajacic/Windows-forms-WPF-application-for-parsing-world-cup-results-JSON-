using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string txtpath = @"C:\Users\Fran\source\repos\WinFormsTest\lang.txt";
        string txtJezik { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            LoadLangTxt();

        }

        private void LoadLangTxt()
        {
         if(File.Exists(txtpath))
            {
                using (StreamReader sr = new StreamReader(txtpath))
                {
                    if (sr.ReadLine() == "hr") 
                    {
                        txtJezik = "hr";
                        lblJezik.Content = "Hrvatski";
                    }
                    else
                    {
                        txtJezik = "en-GB";
                        lblJezik.Content = "Engleski";
                       
                    }
                    sr.Close();
                }
            }
            else
            {
                txtJezik = "---";
                lblJezik.Content = "Odaberi jezik";
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Odabir_jezika win2 = new Odabir_jezika();
            this.Close();
            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            win2.Show();
        }

        private void openForm()
        {
           
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            WindowStyle = WindowStyle.None;
            WindowState = WindowState.Maximized;
            // neki bug u .netu
            //this.MaxHeight = 300;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.None;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Gumb za nastaviti na omiljene repke
            
            OmiljenaReprezentacija orep = new OmiljenaReprezentacija();
            orep.Show();
            this.Close();
        }
    }
}

