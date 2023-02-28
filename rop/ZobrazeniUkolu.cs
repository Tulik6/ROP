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
    public partial class ZobrazeniUkolu : Form
    {
        public ZobrazeniUkolu()
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
           
            string vybranyUkol = listUkolu[Main.index];
            string[] ukol = vybranyUkol.Split(';');
            ukolLabel.Text = ukol[0];
            prioritaLabel.Text = ukol[1];
            kategorieLabel.Text = ukol[2];
            datumLabel.Text = ukol[3]; 
            if(ukol[4] == "x%") trackBar1.Value = 0;
            else trackBar1.Value = int.Parse(ukol[4]);
            splnenoLabel.Text = trackBar1.Value.ToString() + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           
           splnenoLabel.Text = trackBar1.Value.ToString() + " %";
        }

        public static bool zmenaSavu = false;
        private void button2_Click(object sender, EventArgs e)
        {
            
            //Nastavování % splnění do save filu, pokud je splnění 100%, úkol se smaže
            int splnenoProcent = trackBar1.Value;
            string vybranyUkol = listUkolu[Main.index];
            string[] ukol = vybranyUkol.Split(';');
            string line = vybranyUkol.Replace(ukol[4], splnenoProcent.ToString());
            listUkolu[Main.index] = line;


            StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt");
            foreach (string radek in listUkolu)
            {
                sw.WriteLine(radek);
            }
            listUkolu.Clear();
            sw.Close();
            this.Close();

            listUkolu.Clear();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string radek = sr.ReadLine();
                listUkolu.Add(radek);
            }
            sr.Close();

            if (trackBar1.Value == 100)
            {
                StreamWriter sw2 = new StreamWriter(@"..\..\..\splneneUkoly.txt", true);
                sw2.WriteLine(listUkolu[Main.index]);
                sw2.Close();

                sw = new StreamWriter(@"..\..\..\saveFile.txt");
                listUkolu.RemoveAt(Main.index);

                Main.mainListBox.Items.Clear();
                foreach (string task in listUkolu)
                {
                    sw.WriteLine(task);
                    string[] poleUkol = task.Split(';');
                    Main.mainListBox.Items.Add(poleUkol[0]);
                }
                listUkolu.Clear(); //Clear listboxu aby se nevytvářely kopie úkolů
                sw.Close();

            }
        }
    }
}
