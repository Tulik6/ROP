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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.Width = 650;
            this.Height = 500;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                //Zobrazení databáze v listboxu
                string line = sr.ReadLine();
                string[] ukol = line.Split(';');
                listBox1.Items.Add(ukol[0]);
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.ShowDialog();
            //this.Close();
            listBox1.Items.Clear();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while(!sr.EndOfStream)
            {
                //zobrazení úkolu z databáze do listboxu
                string line = sr.ReadLine();
                string[] ukol = line.Split(';');
                listBox1.Items.Add(ukol[0]);
            }
            sr.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            int index = listBox1.SelectedIndex;
        }
    }
}
