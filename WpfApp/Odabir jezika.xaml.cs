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
    /// Interaction logic for Odabir_jezika.xaml
    /// </summary>
    public partial class Odabir_jezika : Window
    {
        public string txtpath = @"C:\Users\Fran\source\repos\WinFormsTest\lang.txt";

        public Odabir_jezika()
        {
            InitializeComponent();
        }

        private void BtnEngleski_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(txtpath))
            {
                using (StreamWriter sr = new StreamWriter(txtpath))
                {
                    sr.WriteLine("en-GB");
                    sr.Close();
                    var newWindow = new MainWindow();
                    this.Close();
                    newWindow.Show();
                }
            }
            if(File.Exists(txtpath))
            {
                File.WriteAllText(txtpath, String.Empty);
                using (StreamWriter sr = new StreamWriter(txtpath))
                {
                    sr.WriteLine("en-GB");
                    sr.Close();
                    var newWindow = new MainWindow();
                    this.Close();
                    newWindow.Show();
                }
            }

        }

        private void BtnHrvatski_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(txtpath))
            {
                using (StreamWriter sr = new StreamWriter(txtpath))
                {
                    sr.WriteLine("hr");
                    sr.Close();
                    var newWindow = new MainWindow();
                    newWindow.Show();
                    this.Close();
                }
            }
            if (File.Exists(txtpath))
            {
                File.WriteAllText(txtpath, String.Empty);
                using (StreamWriter sr = new StreamWriter(txtpath))
                {
                    sr.WriteLine("hr");
                    sr.Close();
                    var newWindow = new MainWindow();
                    this.Close();
                    newWindow.Show();

                }
            }
           
        }
    }
}
