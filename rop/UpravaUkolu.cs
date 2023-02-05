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
    public partial class UpravaUkolu : Form
    {
        public UpravaUkolu()
        {
            InitializeComponent();
        }

        List<string> listUkolu = new List<string>();
        private void Form4_Load(object sender, EventArgs e)
        {   
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listUkolu.Add(line);
            }
            sr.Close();

            string vybranyUkol = listUkolu[Main.index];
            string[] ukol = vybranyUkol.Split(';');
            ukolTextBox.Text = ukol[0];
            prioritaComboBox.Text = ukol[1];
            kategorieComboBox.Text = ukol[2];
            dateTimePicker1.Value = DateTime.Parse(ukol[3]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ukol = ukolTextBox.Text;
            StreamReader sr = new StreamReader(@"..\..\..\saveFile.txt");
            string splneni = "";
            string ukolUnchanged = listUkolu[Main.index];
            ukolUnchanged = ukolUnchanged.Substring(0, ukolUnchanged.IndexOf(';'));
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (s.Contains(ukolUnchanged)) splneni = s.Substring(s.LastIndexOf(';') + 1);
            }
            sr.Close();
            string priorita = prioritaComboBox.SelectedItem.ToString();
            string kategorie = kategorieComboBox.SelectedItem.ToString();
            string datum = dateTimePicker1.Value.Date.ToString();
            int indexCasu = datum.IndexOf("0:00:00");
            datum = datum.Remove(indexCasu, 7);
            datum = datum.Trim();



            string line = ukol + ";" + priorita + ";" + kategorie + ";" + datum + ";" + splneni;
            listUkolu[Main.index] = line;


            
            StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt");
            foreach (string radek in listUkolu)
            {
                sw.WriteLine(radek);
            }
            listUkolu.Clear();
            sw.Close();



            this.Close();
        }
    }
}
