using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MsoaTest4.GsmBdDataSetTableAdapters;

namespace MsoaTest4
{
    public partial class Form2 : Form
    {
        TelefoaneTableAdapter adapterTelefoane = new TelefoaneTableAdapter();

        public Form2()
        {
            InitializeComponent();
        }

        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //save
        private void button1_Click(object sender, EventArgs e)
        {
            adapterTelefoane.Insert(textBox1.Text, textBox2.Text, double.Parse(textBox3.Text), int.Parse(textBox4.Text));
            this.Close();
        }
    }
}
