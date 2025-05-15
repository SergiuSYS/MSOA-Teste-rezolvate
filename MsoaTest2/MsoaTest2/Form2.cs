using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MsoaTest2.FacultateDataSetTableAdapters;

namespace MsoaTest2
{
    public partial class Form2 : Form
    {
        private readonly StudentiTableAdapter adapterStudenti = new StudentiTableAdapter();

        public Form2()
        {
            InitializeComponent();
        }

        //save
        private void button1_Click(object sender, EventArgs e)
        {
            adapterStudenti.Insert(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //cnacel
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
