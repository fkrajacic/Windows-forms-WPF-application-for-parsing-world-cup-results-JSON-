using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class UserControl1 : UserControl
    {
        public string Ime { get; set; }
        public string brojDresa { get; set; }
        public string Pozicija { get; set; }
        public string imgPath { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }
        public UserControl1(string ime,string brojdresa,string pozicija)
        {
            this.Ime = ime;
            this.brojDresa = brojdresa;
            this.Pozicija = pozicija;
            InitializeComponent();
        }
        public void setData()
        {
            lblIme.Text = Ime;
            lblPosition.Text = Pozicija;
            lblShirtNumber.Text = brojDresa;
            imgPath = @"C:\Users\Fran\source\repos\WinFormsTest\igrač.png";
            setImgPath(imgPath);
        }
        public void setImgPath(string path)
        {
            pictureBox1.ImageLocation = path;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Size = new Size(40, 30);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageFromFile = new OpenFileDialog();
            imageFromFile.Filter = "Slike|*.bmp;*.jpg*.jpeg*.png;|Sve datoteke|*.*";
            imageFromFile.InitialDirectory = Application.StartupPath;

            if(imageFromFile.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                setImgPath(imageFromFile.FileName);
            }
        }

    }
}
