using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    
    public partial class Form3 : Form
    {
        Repo repo = new Repo();
        public string fifaCode { get; set; }
        public Form3(string fifaCode)
        {
            this.fifaCode = fifaCode;
            InitializeComponent();
            loadStartingElevenStatistics();
            loadStartingElevenStatisticsKartoni();
        }

        private void loadStartingElevenStatistics()
        {
            List<StartingEleven> listaSE = repo.getRankListPlayers(fifaCode);
            List<StartingEleven> listaSESortirana = listaSE.OrderByDescending(o => o.Goals).ToList();
            foreach (StartingEleven se in listaSESortirana)
            {
                listBox2.Items.Add(se.Name+"     "+se.Goals);
            }
        }
        private void loadStartingElevenStatisticsKartoni()
        {
            List<StartingEleven> listaSE = repo.getRankListPlayers(fifaCode);
            List<StartingEleven> listaSESortirana = listaSE.OrderByDescending(o => o.YellowCards).ToList();
            foreach (StartingEleven se in listaSESortirana)
            {
                listBoxKartoni.Items.Add(se.Name + "     " + se.YellowCards);
            }
        }
    }
}
