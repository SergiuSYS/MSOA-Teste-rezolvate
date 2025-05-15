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
    public partial class Form1 : Form
    {
        private readonly StudentiTableAdapter adapterStudenti = new StudentiTableAdapter();
        private readonly MateriiTableAdapter adapterMaterii = new MateriiTableAdapter();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var row = treeView1.SelectedNode.Tag as FacultateDataSet.StudentiRow;
            if (row == null) return;

            var data = adapterMaterii.GetData();
            var materiiStudent = data.Where(m => m.Marca == row.Marca).ToList();

            listBox1.Items.Clear();

            if (!materiiStudent.Any())
            {
                listBox1.Items.Add("Medie Multianuala: 0");
                return;
            }

            int totalNote = 0;

            foreach (var materie in materiiStudent)
            {
                listBox1.Items.Add($"Materie: {materie.Nume_materie}, An: {materie.An_materie}, NF: {materie.Nota_finala}");
                totalNote += materie.Nota_finala;
            }

            int medie = totalNote / materiiStudent.Count;
            listBox1.Items.Add($"Medie Multianuala: {medie}");

        }
        private void LoadData()
        {
            treeView1.Nodes.Clear();
            var data = adapterStudenti.GetData();
            foreach (var row in data)
            {
                TreeNode treeNode = new TreeNode(row.Nume_prenume);
                treeNode.Tag = row;
                treeView1.Nodes.Add(treeNode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            var data = treeView1.SelectedNode.Tag as FacultateDataSet.StudentiRow;
            var marca = data.Marca;
            new Form3(marca).ShowDialog();
        }
    }
}
