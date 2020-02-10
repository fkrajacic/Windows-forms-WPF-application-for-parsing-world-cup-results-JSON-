using ClassLibrary1;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for podaciOIgracu.xaml
    /// </summary>
    public partial class podaciOIgracu : Window
    {
        Repo repo = new Repo();
        public podaciOIgracu(string name,string brojDresa)
        {
            InitializeComponent();
            List<Match> sviMecevi = new List<Match>();
            lblIme.Content = name;
            lblGolovi.Content = 2;
            lblKartoni.Content = 0;

        }
    }
}
