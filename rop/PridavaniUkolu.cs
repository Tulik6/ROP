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
    public partial class PridavaniUkolu : Form
    {
        public PridavaniUkolu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt", true);
            string ukol = textBox1.Text;
            string priorita = comboBox1.SelectedItem.ToString();
            string kategorie = comboBox2.SelectedItem.ToString();
            string datum = dateTimePicker1.Value.Date.ToString();
            int indexCasu = datum.IndexOf("0:00:00");
            datum = datum.Remove(indexCasu, 7);
            datum = datum.Trim();
            string line = ukol + ";" + priorita + ";" + kategorie + ";" + datum + ";" + "x%";
            sw.WriteLine(line);
            sw.Close();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
