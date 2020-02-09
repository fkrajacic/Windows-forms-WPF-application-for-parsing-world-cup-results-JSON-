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
    public partial class Form2 : Form
    {
        public string fifaCode { get; set; }
        Repo repo = new Repo();

        public Form2(string code)
        {
            InitializeComponent();
            fifaCode = code;
            //LoadMatches();
            LoadStartingEleven();
            this.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1.Padding = new Padding(1, 1, 1, 1);
            flowLayoutPanel1.Margin = new Padding(10, 10, 10, 10);
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            
        }

        private void LoadStartingEleven()
        {
            List<StartingEleven> listaSE = repo.getStartingElevens(fifaCode);
            StartingEleven sortByShirtNumber = new StartingEleven();
            List<StartingEleven> listaSESorted = listaSE.OrderBy(o => o.ShirtNumber).ToList();
            foreach (StartingEleven se in listaSESorted)
            {
                UserControl1 uc = new UserControl1(se.Name, se.ShirtNumber.ToString(), se.Position.ToString());
                flowLayoutPanel1.Controls.Add(uc);
                uc.setData();
            }
        }

        //private void LoadMatches()
        //{
        //    List<StartingEleven> listaSE = repo.getStartingElevens(fifaCode);
        //    foreach (StartingEleven startingEleven in listaSE)
        //    {
        //        listBox1.Items.Add(startingEleven.Name);
        //    }
           
        //}

        private void rankLista_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openForm()
        {
            Application.Run(new Form3(fifaCode));

        }
    }
}
