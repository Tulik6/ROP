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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"..\..\..\saveFile.txt", true);
            string ukol = textBox1.Text;
            string priorita = comboBox1.SelectedItem.ToString();
            string kategorie = comboBox2.SelectedItem.ToString();
            string datum = dateTimePicker1.Value.ToString();
            sw.WriteLine(ukol + ";" + priorita + ";" + kategorie + ";" + datum);
            sw.Close();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}