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
    public partial class Form3 : Form
    {
        AccesoriiTableAdapter adapterAccesorii = new AccesoriiTableAdapter();
        int _Telefonid;
        public Form3(int Telefonid)
        {
            InitializeComponent();
            _Telefonid = Telefonid;
        }

        //save
        private void button1_Click(object sender, EventArgs e)
        {
            adapterAccesorii.Insert(_Telefonid, comboBox1.SelectedItem.ToString(),textBox1.Text , double.Parse(textBox3.Text), int.Parse(textBox4.Text));
            this.Close();
        }

        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
