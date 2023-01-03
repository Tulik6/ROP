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
        public static int index = 0;
        List<string> listUkolu = new List<string>(); //Vložení textu ze souboru do listu pro lehčí zpracování
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
            //Vytvoření souboru pokud neexistuje
            try
            {
                StreamReader sr = null;
                using (sr = new StreamReader(@"..\..\..\saveFile.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        //Zobrazení databáze v listboxu
                        string line = sr.ReadLine();
                        string[] ukol = line.Split(';');
                        listBox1.Items.Add(ukol[0]);
                    }
                    //sr.Close();
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Save file nebyl nalezen, po stisknutí tlačítka se vytvoří nový");
                StreamWriter sw = File.CreateText(@"..\..\..\saveFile.txt");
                sw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.ShowDialog();
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
            Form1.index = listBox1.SelectedIndex;
            if (Form1.index != -1)
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else MessageBox.Show("Nebyl vybrán úkol");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.index = listBox1.SelectedIndex;
            if (Form1.index != -1)
            {
                StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    listUkolu.Add(line);
                }
                sr.Close();

                StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt");
                listUkolu.RemoveAt(Form1.index);

                foreach (string ukol in listUkolu)
                {
                    sw.WriteLine(ukol);
                }
                listUkolu.Clear(); //Clear listboxu aby se nevytvářely kopie úkolů
                sw.Close();

                sr = new StreamReader(@"..\..\..\saveFile.txt");
                //Refresh listboxu po smazání úkolu
                listBox1.Items.Clear();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] ukol = line.Split(';');
                    listBox1.Items.Add(ukol[0]);
                }
                sr.Close();
            }
            else MessageBox.Show("Nebyl vybrán žádný úkol");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.index = listBox1.SelectedIndex;
            if (Form1.index != -1)
            {
                Form4 form4 = new Form4();
                form4.ShowDialog();
                StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
                //Refresh listboxu po upravení úkolu
                listBox1.Items.Clear();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] ukol = line.Split(';');
                    listBox1.Items.Add(ukol[0]);
                }
                sr.Close();
            }
            else MessageBox.Show("Nebyl vybrán úkol");
        }
    }
}
