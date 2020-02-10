using ClassLibrary1;
using System;
using System.Collections;
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
        List<StartingEleven> listaSE { get; set; }
        public string fifaCode { get; set; }
        Repo repo = new Repo();
        int brKontrola = 0;

        public Form2(string code)
        {
            InitializeComponent();
            fifaCode = code;
            Repo repo = new Repo();
            //LoadMatches();
            //LoadStartingEleven();
            GetStartingElevenAsync();
            slaganjeFLP();
   

        }

        private async void GetStartingElevenAsync()
        {
            Task<List<StartingEleven>> task = new Task<List<StartingEleven>>(ucitajNista);
            task.Start();
            listaSE = await task;
            LoadStartingEleven();
        }

        private List<StartingEleven> ucitajNista()
        {
            return repo.getStartingElevens(fifaCode);
        }

        private void slaganjeFLP()
        {
            this.Controls.Add(flowLayoutPanel1);
            flowLayoutPanel1.Padding = new Padding(1, 1, 1, 1);
            flowLayoutPanel1.Margin = new Padding(10, 10, 10, 10);
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.BorderStyle = BorderStyle.Fixed3D;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            //
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel2.AllowDrop = true;
            //
            flowLayoutPanel1.DragEnter += panel_DragEnter;
            flowLayoutPanel2.DragEnter += panel_DragEnter;
            //
            flowLayoutPanel1.DragDrop += panel_DragDrop;
            flowLayoutPanel2.DragDrop += panel_DragDrop;
            
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            UserControl1 uc = new UserControl1();
            flowLayoutPanel2.Controls.Add(uc);
            uc.setData();
    }

        
        private void LoadStartingEleven()
        {
            StartingEleven sortByShirtNumber = new StartingEleven();
            List<StartingEleven> listaSESorted = listaSE.OrderBy(o => o.ShirtNumber).ToList();
            
            for (int index = 0; index < listaSESorted.Count; index++)
            {
                UserControl1 uc = new UserControl1(listaSESorted[index].Name, listaSESorted[index].ShirtNumber.ToString(), listaSESorted[index].Position.ToString());
                brKontrola = index;
                flowLayoutPanel1.Controls.Add(uc);
                uc.setData();
                uc.MouseDown += uc_MouseDown;
                
            }
            
        }

        private void uc_MouseDown(object sender, MouseEventArgs e)
        {
            UserControl1 uc = new UserControl1();
            uc.DoDragDrop(sender as UserControl1, DragDropEffects.Move);
        }




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

        private void flowLayoutPanel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
    }
}
