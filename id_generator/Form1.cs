using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// External Libraries
using CsvHelper;
using Newtonsoft.Json.Linq;


namespace id_generator
{
    public partial class id_generator : Form
    {
        // Class members
        private Graphics canvas;
        private String csv_file;
        private String json_file;

        public id_generator()
        {
            InitializeComponent();
        }

        private void button_json_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Diwas\\Documents\\Visual Studio 2013\\Projects\\id_generator\\id_generator\\test";
            openFileDialog1.Filter = "JSON File(*.json)|*.json";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                json_file = openFileDialog1.FileName;
                Console.WriteLine(json_file);
            }
        }

        private void button_csv_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = "C:\\Users\\Diwas\\Documents\\Visual Studio 2013\\Projects\\id_generator\\id_generator\\test";
            openFileDialog2.Filter = "CSV File(*.csv)|*.csv";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                csv_file = openFileDialog2.FileName;
                Console.WriteLine(csv_file);
            }
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            String json_content = File.ReadAllText(json_file);
            JObject obj1 = JObject.Parse(json_content);

            string sample = (string)obj1["glossary"]["title"];
            Console.WriteLine(sample);
        }
    }
}
