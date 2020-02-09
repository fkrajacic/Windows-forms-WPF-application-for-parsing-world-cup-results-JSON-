using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTest
{
    public partial class Form_Lang : Form
    {
        public string txtpath = @"C:\Users\Fran\source\repos\WinFormsTest\lang.txt";
        public string txtJezik { get; set; }
        public Form_Lang()
        {
            InitializeComponent();
            LoadLangTxt();
            
        }

  

        private void LoadLangTxt()
        {
            if (File.Exists(txtpath))
            {
                using (StreamReader sr = new StreamReader(txtpath))
                {
                    if (sr.ReadLine() == "en-GB")
                    {
                        txtJezik = "en-GB";
                        
                    }
                    else
                    {
                        txtJezik = "hr";
                    }
                    
                }
                
            }
        }

        
        

        private void btnEngleski_Click(object sender, EventArgs e)
        {
            writeEngleski();
            this.Close();
            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void writeEngleski()
        {
            if (!File.Exists(txtpath))
            {
                using (StreamWriter sw = new StreamWriter(txtpath))
                {
                    sw.WriteLine("en-GB");
                }

            }
        }

        private void btnHrvatski_Click(object sender, EventArgs e)
        {
            writeHrvatski();
            this.Close();
            Thread th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void writeHrvatski()
        {

            if (!File.Exists(txtpath))
            {
                using (StreamWriter sw = new StreamWriter(txtpath))
                {
                    sw.WriteLine("hr");
                }

            }
        }

            private void openForm()
        {
            Application.Run(new Form1());
        }
    }
}
