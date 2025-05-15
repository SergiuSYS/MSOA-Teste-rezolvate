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

namespace MsoaTest1
{
    public partial class Form1 : Form
    {
        private List<DateCopil> ListaCopii = new List<DateCopil>();
        private string FilePath = "C:\\Users\\Sergiu\\Desktop\\FolderCopii";


        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        //add copil
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(ListaCopii);

            if (form2.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.Add(form2.dateCopil);
                ListaCopii.Add(form2.dateCopil);
            }
        }

        //add cadou
        private void button3_Click(object sender, EventArgs e)
        {
            DateCopil temp = (DateCopil)comboBox1.SelectedItem;
            temp.AddCadou(new DateCadou(textBox1.Text,comboBox2.SelectedItem.ToString(), Convert.ToDouble(textBox2.Text)));
        }

        //salvare date
        private void button2_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = comboBox1.SelectedItem;
        }
        public void SaveData()
        {
            foreach(var obj in ListaCopii)
            {
                int i = 1;
                string objFilepath = FilePath + "\\" + obj.ToString();  
                Directory.CreateDirectory(objFilepath);  

                string dataCopil = obj._nume + "\n" + obj._prenume + "\n" + obj._CNP; 
                File.WriteAllText(objFilepath + "\\" + "DateCopil.txt", dataCopil);
                foreach (var cadou in obj._cadouri)
                {
                    string dataCadou = cadou._nume + "\n" + cadou._pret + "\n" + cadou._tip;
                    File.WriteAllText(objFilepath + "\\" + "Cadou" + i +".txt", dataCadou);
                    i++;
                }
            }
        }
        //load date
        public void LoadData()
        {
            string[] folders = Directory.GetDirectories(FilePath);
            foreach (var folder in folders)
            {

                string[] files = Directory.GetFiles(folder);
                string dateCopil = files.FirstOrDefault(u => u == folder + "\\" + "DateCopil.txt");
                string[] data = File.ReadAllLines(dateCopil);
                DateCopil newDateCopil = new DateCopil(data[0], data[1], data[2]);

                int i = 0;
                while (true)
                {
                    string cadouFilePath = Path.Combine(folder, $"Cadou{i}.txt");

                    if (!File.Exists(cadouFilePath)) break;

                    string[] cadouData = File.ReadAllLines(cadouFilePath);

                    DateCadou newDateCadou = new DateCadou(cadouData[0], cadouData[2], Convert.ToDouble(cadouData[1]));
                    newDateCopil.AddCadou(newDateCadou);

                    i++;
                }
                ListaCopii.Add(newDateCopil);
                foreach (var obj in ListaCopii)
                {
                    comboBox1.Items.Add(obj);
                }

            }
        }
    }
}
