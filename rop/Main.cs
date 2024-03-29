﻿using System;
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

    public partial class Main : Form
    {

        public static int index = 0;
        List<string> listUkolu = new List<string>(); //Vložení textu ze souboru do listu pro lehčí zpracování

        public static ListBox mainListBox { get; set; } //Vytvoření public listBoxu aby se dal mazat z druhého formu
        public Main()
        {
            InitializeComponent();
            this.Width = 750;
            this.Height = 500;
            mainListBox = listBox1;
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
            catch (FileNotFoundException)
            {
                MessageBox.Show("Save file nebyl nalezen, po stisknutí tlačítka se vytvoří nový");
                StreamWriter sw = File.CreateText(@"..\..\..\saveFile.txt");
                sw.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PridavaniUkolu form2 = new PridavaniUkolu();
            form2.ShowDialog();
            listBox1.Items.Clear();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
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
            Main.index = listBox1.SelectedIndex;

            if (Main.index != -1)
            {
                ZobrazeniUkolu form3 = new ZobrazeniUkolu();
                form3.ShowDialog();
            }
            else MessageBox.Show("Nebyl vybrán úkol");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main.index = listBox1.SelectedIndex;
            if (Main.index != -1)
            {
                StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    listUkolu.Add(line);
                }
                sr.Close();

                StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt");
                listUkolu.RemoveAt(Main.index);

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
            Main.index = listBox1.SelectedIndex;
            if (Main.index != -1)
            {
                UpravaUkolu form4 = new UpravaUkolu();
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

        private void Main_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e) //Podle %
        {
            List<string> pomocnyList = new List<string>();
            pomocnyList.Clear();
            listUkolu.Clear();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();

            int[] pomocnePole = new int[listUkolu.Count];

            for (int i = 0; i < listUkolu.Count; ++i)
            {
                string[] ukol = listUkolu[i].Split(';');
                try
                {
                    int procentoSpleni = int.Parse(ukol[4]);
                    pomocnePole[i] = procentoSpleni;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Úkol " + "\"" + ukol[0] + "\"" + " nemá správně přiřazené % splnění");
                }
            }

            Array.Sort(pomocnePole);
            Array.Reverse(pomocnePole);

            /*foreach (int x in pomocnePole)
            {
                MessageBox.Show(x.ToString());
            }*/


            StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt");
            sw.Write("");
            for (int i = 0; i < pomocnePole.Length; ++i)
            {

                for (int j = 0; j < listUkolu.Count; ++j)
                {
                    string s = listUkolu[j];
                    if (s.Contains(pomocnePole[i].ToString()))
                    {
                        string[] ukol = listUkolu[j].Split(';');
                        pomocnyList.Add(ukol[0]);
                        sw.WriteLine(s);
                        listUkolu.RemoveAt(j);
                    }
                }
            }
            sw.Close();

            listBox1.Items.Clear();
            
            for (int i = 0; i < pomocnyList.Count; ++i)
            {
                listBox1.Items.Add(pomocnyList[i]);
                
            }

        }

        private void button9_Click(object sender, EventArgs e) //Podle kategorie
        {
            List<string> pomocnyList = new List<string>();
            pomocnyList.Clear();
            listUkolu.Clear();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();


            for (int i = 0; i < listUkolu.Count; ++i)
            {
                string s = listUkolu[i];
                string[] ukol = s.Split(';');
                string kategorie = comboBox1.SelectedItem.ToString();
                if (s.Contains(kategorie))
                {
                    pomocnyList.Add(ukol[0]);
                }
            }

            listBox1.Items.Clear();
            foreach (string s in pomocnyList)
            {
                listBox1.Items.Add(s);
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
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

        private void button10_Click(object sender, EventArgs e) //Podle času
        {
            List<string> pomocnyList = new List<string>();
            listUkolu.Clear();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();



            DateTime[] poleDat = new DateTime[listUkolu.Count];
            for(int i = 0; i < listUkolu.Count; ++i)
            {
                string s = listUkolu[i];
                string[] ukolSplit = s.Split(';');
                poleDat[i] = DateTime.Parse(ukolSplit[3]);
            }

            Array.Sort(poleDat);
            //Array.Reverse(poleDat);

            /*foreach(DateTime x in poleDat)
            {
                MessageBox.Show(x.ToString());
            }*/


            StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt");
            sw.Write("");
            for (int i = 0; i < poleDat.Length; ++i)
            {
                for (int j = 0; j < listUkolu.Count; ++j)
                {
                    string s = listUkolu[j];
                    if (s.Contains(poleDat[i].ToString("dd/MM/yyyy")))
                    {
                        string[] ukol = s.Split(';');
                        pomocnyList.Add(ukol[0]);
                        listUkolu.RemoveAt(j);
                        sw.WriteLine(s);
                    }
                }
            }
            sw.Close();

            listBox1.Items.Clear();
            foreach (string s in pomocnyList)
            {
                listBox1.Items.Add(s);
            }


        }

        private void button7_Click(object sender, EventArgs e) //Den
        {
            listUkolu.Clear();
            listBox1.Items.Clear();
            List<string> pomocnyList = new List<string>();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();


            
            for (int i = 0; i < listUkolu.Count; ++i)
            {
                string s = listUkolu[i];
                string[] ukolSplit = s.Split(';');
                DateTime datum = DateTime.Parse(ukolSplit[3]);

                if(datum == DateTime.Today)
                {
                    pomocnyList.Add(s);
                    listBox1.Items.Add(ukolSplit[0]);
                }
            }


        }

        private void button5_Click(object sender, EventArgs e) //Týden
        {
            listUkolu.Clear();
            listBox1.Items.Clear();
            List<string> pomocnyList = new List<string>();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();

            for (int i = 0; i < listUkolu.Count; ++i)
            {
                string s = listUkolu[i];
                string[] ukolSplit = s.Split(';');
                DateTime datum = DateTime.Parse(ukolSplit[3]);

                DayOfWeek aktualniDen = DateTime.Now.DayOfWeek;
                DateTime zacatekTydne = DateTime.Now.AddDays(-(int)aktualniDen);
                DateTime konecTydne = zacatekTydne.AddDays(6);
                

                if (datum >= zacatekTydne && datum <= konecTydne)
                {
                    pomocnyList.Add(s);
                    listBox1.Items.Add(ukolSplit[0]);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) //Měsíc
        {
            listUkolu.Clear();
            listBox1.Items.Clear();
            List<string> pomocnyList = new List<string>();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();

            for (int i = 0; i < listUkolu.Count; ++i)
            {
                string s = listUkolu[i];
                string[] ukolSplit = s.Split(';');
                DateTime datum = DateTime.Parse(ukolSplit[3]);


                if (datum.Month == DateTime.Now.Month)
                {
                    pomocnyList.Add(s);
                    listBox1.Items.Add(ukolSplit[0]);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DateTime datumOd = dateTimePicker1.Value.Date;
            DateTime datumDo = dateTimePicker2.Value.Date;

            listUkolu.Clear();
            listBox1.Items.Clear();
            List<string> pomocnyList = new List<string>();
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();

            for (int i = 0; i < listUkolu.Count; ++i)
            {
                string s = listUkolu[i];
                string[] ukolSplit = s.Split(';');
                DateTime datum = DateTime.Parse(ukolSplit[3]);


                if (datum >= datumOd && datum <= datumDo)
                {
                    pomocnyList.Add(s);
                    listBox1.Items.Add(ukolSplit[0]);
                }
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
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
    }
}
