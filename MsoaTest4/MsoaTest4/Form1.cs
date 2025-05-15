using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MsoaTest4.GsmBdDataSetTableAdapters;

namespace MsoaTest4
{
    public partial class Form1 : Form
    {
        TelefoaneTableAdapter adapterTelefoane = new TelefoaneTableAdapter();
        AccesoriiTableAdapter adapterAccesorii = new AccesoriiTableAdapter();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        //adaugare telefon
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
            LoadData();
        }

        //adaugare accesoriu
        private void button2_Click(object sender, EventArgs e)
        {
            var dataTelefon = treeView1.SelectedNode.Tag as GsmBdDataSet.TelefoaneRow;
            new Form3(dataTelefon.TelefonId).ShowDialog();
        }

        //stergere telefon
        private void button3_Click(object sender, EventArgs e)
        {
            var data = adapterTelefoane.GetData().ToList();
            var row = data.FirstOrDefault(u => u.Model == textBox1.Text);
            if (row is null)
                MessageBox.Show("Telefonul cautat nu exista");
            else
                adapterTelefoane.Delete(row.TelefonId, row.Producator, row.Model, row.Pret, row.Numar_bucati);
            LoadData();
        }
        
        private void LoadData()
        {
            treeView1.Nodes.Clear();
            var data = adapterTelefoane.GetData().ToList();
            foreach (var item in data)
            {
                TreeNode itemNode = new TreeNode($"{item.Producator} {item.Model}");
                itemNode.Tag = item;
                treeView1.Nodes.Add(itemNode);
            }
        }

        //export data
        private void button4_Click(object sender, EventArgs e)
        {
            
            double sumaDeBaniTelefoane = 0;
            double sumaDeBaniAccesorii = 0;

            StreamWriter streamWriter = new StreamWriter("C:\\Users\\Sergiu\\Desktop\\test4\\stoc.txt");
            
            var dataTelefoane = adapterTelefoane.GetData().ToList();
            var dataAccesorii = adapterAccesorii.GetData().ToList();
            foreach( var item in dataTelefoane)
            {
                sumaDeBaniTelefoane += item.Pret * item.Numar_bucati;
            }
            foreach (var item in dataAccesorii)
            {
                sumaDeBaniAccesorii += item.Pret * item.Numar_bucati;
            }
            string data = $"numar de telefoane: {dataTelefoane.Count()} suma de bani: {sumaDeBaniTelefoane} \n" +
                $"numar de Accesorii: {dataAccesorii.Count()} suma de bani: {sumaDeBaniAccesorii}";
            streamWriter.Write(data);
            streamWriter.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var dataTelefon = treeView1.SelectedNode.Tag as GsmBdDataSet.TelefoaneRow;
            var dataAccesori = adapterAccesorii.GetData().ToList();

            var dataAccesoriTelefonId = dataAccesori.Where(u => u.TelefonId == dataTelefon.TelefonId);
            

            listBox1.Items.Clear();
            listBox1.Items.Add("Date Telefon:");
            listBox1.Items.Add($"   Producator: {dataTelefon.Producator}");
            listBox1.Items.Add($"   Model: {dataTelefon.Model}");
            listBox1.Items.Add($"   Pret: {dataTelefon.Pret} lei");
            listBox1.Items.Add($"   Numar Bucati: {dataTelefon.Numar_bucati} buc");
            listBox1.Items.Add("Acesorii: ");


            foreach (var accesoriu in dataAccesoriTelefonId)
            {
                listBox1.Items.Add($"{accesoriu.Tip_accesoriu}, {accesoriu.Producator}, {accesoriu.Pret} lei, {accesoriu.Numar_bucati} buc");
            }
        }
    }
}
