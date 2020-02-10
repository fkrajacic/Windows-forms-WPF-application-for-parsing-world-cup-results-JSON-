using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    
    public partial class Form3 : Form
    {
        List<StartingEleven> listaSE { get; set; }
        List<Match> posjetitelji { get; set; }

        Repo repo = new Repo();
        public string fifaCode { get; set; }
        public Form3(string fifaCode)
        {
            this.fifaCode = fifaCode;
            InitializeComponent();
            //loadStartingElevenStatistics();
            loadStartingElevenStatisticsAsync();
            loadStartingElevenStatisticsKartoniAsync();
            LoadBrojPosjetiteljaAsync();
        }

        private async void LoadBrojPosjetiteljaAsync()
        {
            Task<List<Match>> task = new Task<List<Match>>(posjetiteljiUcitaj);
            task.Start();
            posjetitelji = await task;
            LoadBrojPosjetitelja();
        }

        private List<Match> posjetiteljiUcitaj()
        {
            return repo.GetMatches();
        }

        private async void loadStartingElevenStatisticsKartoniAsync()
        {
            Task<List<StartingEleven>> task = new Task<List<StartingEleven>>(ucitajNista);
            task.Start();
            listaSE = await task;
            loadStartingElevenStatisticsKartoni();
        }

        private async void loadStartingElevenStatisticsAsync()
        {
            Task<List<StartingEleven>> task = new Task<List<StartingEleven>>(ucitajNista);
            task.Start();
            listaSE = await task;
            loadStartingElevenStatistics();
        }

        private List<StartingEleven> ucitajNista()
        {
            return repo.getRankListPlayers(fifaCode);
        }

        private void LoadBrojPosjetitelja()
        {
            List<Match> posjetitelji = repo.GetMatches();
            List<Match> posjetiteljiSortirani = posjetitelji.OrderByDescending(o => o.Attendance).ToList();
            foreach(Match m in posjetiteljiSortirani)
            {
                listBox1.Items.Add(m.HomeTeam.Country + "   vs   " + m.AwayTeam.Country + "          " + m.Attendance+" posjetitelja na utakmici");
            }

        }

        private void loadStartingElevenStatistics()
        {
           
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openFormd);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFormd()
        {
            Application.Run(new Izlaz());
        }
    }
}
