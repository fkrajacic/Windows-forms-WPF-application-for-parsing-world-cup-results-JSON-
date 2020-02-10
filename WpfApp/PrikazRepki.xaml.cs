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
    /// Interaction logic for PrikazRepki.xaml
    /// </summary>
    public partial class PrikazRepki : Window
    {
        Repo repo = new Repo();
        public PrikazRepki(string htt, string aww)
        {
            InitializeComponent();
            OmiljenaReprezentacija ompr = new OmiljenaReprezentacija();
            string ht = htt;
            string aw = aww;
            putPlayersOnField(ht, aw);

        }


        private void putPlayersOnField(string ht, string aw)
        {
            //Goalie, Defender, Midfield, Forward
            List<StartingEleven> listaSEHT = repo.getStartingElevens(ht);
            List<StartingEleven> listaSEAW = repo.getStartingElevens(aw);

            {
                {
                    foreach (StartingEleven se in listaSEHT)
                    {


                        Igrac uc = new Igrac(se.Name.ToString(), se.ShirtNumber.ToString());
                        if (se.Position.ToString() == "Goalie")
                        {

                            Canvas.SetTop(uc, 150);
                            Canvas.SetLeft(uc, 5);
                            uc.setData();
                            glavniPitch.Children.Add(uc);


                        }
                        if (se.Position.ToString() == "Defender")
                        {
                            int x = 50;

                            Canvas.SetTop(uc, 50);
                            Canvas.SetLeft(uc, x);
                            uc.setData();
                            glavniPitch.Children.Add(uc);
                            x = x + 30;

                        }
                        if (se.Position.ToString() == "Midfield")
                        {
                            int x = 20;
                            int y = 30;

                            Canvas.SetTop(uc, y);
                            Canvas.SetLeft(uc, 75);
                            uc.setData();
                            glavniPitch.Children.Add(uc);
                            x = x + 30;
                            y = y + 30;
                        }
                        if (se.Position.ToString() == "Forward")
                        {
                            int x = 200;
                            int y = 300;
                            Canvas.SetTop(uc, x);
                            Canvas.SetLeft(uc, y);
                            uc.setData();
                            glavniPitch.Children.Add(uc);
                            x = x + 30;
                            y = y + 30;


                        }
                    }
                }

            }
        }
    }
}
        

