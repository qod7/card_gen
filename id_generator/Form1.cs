using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

// External Libraries
using CsvHelper;
using Newtonsoft.Json.Linq;


namespace id_generator
{
    public partial class id_generator : Form
    {
        // Class members
        private Graphics canvas_graphics;
        private Bitmap canvas_bitmap;
        private String csv_file;
        private String json_file;

        public id_generator()
        {
            InitializeComponent();
        }

        private void button_json_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\Diwas\\Documents\\Visual Studio 2013\\Projects\\id_generator\\test";
            openFileDialog1.Filter = "JSON File(*.json)|*.json";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                json_file = openFileDialog1.FileName;
            }
        }

        private void button_csv_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();

            openFileDialog2.InitialDirectory = "C:\\Users\\Diwas\\Documents\\Visual Studio 2013\\Projects\\id_generator\\test";
            openFileDialog2.Filter = "CSV File(*.csv)|*.csv";
            openFileDialog2.FilterIndex = 1;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                csv_file = openFileDialog2.FileName;
            }
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            String json_content = File.ReadAllText(json_file);
            JObject json_obj = JObject.Parse(json_content);

            int canvas_width = (int)json_obj["width"], canvas_height = (int)json_obj["height"];

            // Create a empty bitmap
            canvas_bitmap = new Bitmap(canvas_width, canvas_height);
            canvas_graphics = Graphics.FromImage(canvas_bitmap);

            Color background_color = Color.FromArgb(Convert.ToInt32((string)json_obj["background"], 16));
            canvas_graphics.Clear(background_color);

            canvas_bitmap.Save("sample.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }
    }
}
