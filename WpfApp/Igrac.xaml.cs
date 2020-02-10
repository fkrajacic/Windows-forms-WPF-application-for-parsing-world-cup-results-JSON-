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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Igrac.xaml
    /// </summary>
    public partial class Igrac : UserControl
    {
        public string name { get; set; }
        public string brojDresa { get; set; }
        public Igrac(string name,string brojDresa)
        {
            InitializeComponent();
            this.name = name;
            this.brojDresa = brojDresa;
            setData();
        }

     

        public void setData()
        {
            uclblIgrac.Content = name;
            ucllbBrojDresaIgraca.Content = brojDresa;
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            podaciOIgracu poi = new podaciOIgracu(Name,brojDresa);
            poi.Topmost = true;
            poi.Show();
            
            
        }
    }
}
