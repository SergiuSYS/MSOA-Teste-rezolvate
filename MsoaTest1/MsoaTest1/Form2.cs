using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MsoaTest1
{
    public partial class Form2 : Form
    {
        public DateCopil dateCopil {  get; set; }

        public List<DateCopil> _dateCopii { get; set; }
        public Form2(List<DateCopil> dateCopii)
        {
            InitializeComponent();
            _dateCopii = dateCopii;

        }

        //save
        private void button1_Click(object sender, EventArgs e)
        {
            var tempCopil = _dateCopii.FirstOrDefault(u => u._CNP == textBox3.Text);

            if (tempCopil == null)
            {
                dateCopil = new DateCopil(textBox1.Text, textBox2.Text, textBox3.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Acesta persoana este deja in sistem");
            }
        }

        //abort
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
