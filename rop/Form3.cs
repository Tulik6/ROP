using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        List<string> listUkolu = new List<string>();
        private void Form3_Load(object sender, EventArgs e)
        {

            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();
           

            string vybranyUkol = listUkolu[Form1.index];
            string[] ukol = vybranyUkol.Split(';');
            ukolLabel.Text = ukol[0];
            prioritaLabel.Text = ukol[1];
            kategorieLabel.Text = ukol[2];
            datumLabel.Text = ukol[3];       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
