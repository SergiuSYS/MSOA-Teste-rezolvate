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
    public partial class Form3 : Form
    {
        private readonly MateriiTableAdapter adapterMaterii = new MateriiTableAdapter();
        private readonly int _marca;
        public Form3(int marca)
        {
            _marca = marca;
            InitializeComponent();
        }

        //save
        private void button1_Click(object sender, EventArgs e)
        {
            if (_marca > 0)
            {
                adapterMaterii.Insert(_marca, int.Parse(textBox1.Text), textBox2.Text, int.Parse(textBox3.Text));
                this.Close();
            }
            else 
            {
                MessageBox.Show("Eroare la intrarea marcii");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
