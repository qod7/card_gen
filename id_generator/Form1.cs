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
        private Bitmap canvas_image;
        private String csv_file;
        private String json_file;

        private String default_font;
        private String base_path;

        public id_generator()
        {
            InitializeComponent();
            base_path = "idcards";

            Directory.CreateDirectory(base_path);

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
            // Return if empty or null
            if(String.IsNullOrEmpty(csv_file) || String.IsNullOrEmpty(json_file))
            {
                //return;

                // Debugging code
                csv_file = "C:\\Users\\Diwas\\Documents\\Visual Studio 2013\\Projects\\id_generator\\test\\sample.csv";
                json_file = "C:\\Users\\Diwas\\Documents\\Visual Studio 2013\\Projects\\id_generator\\test\\sample.json";
            }

            // Create json object containing data
            JObject json_obj = JObject.Parse(File.ReadAllText(json_file));

            // Obtain canvas width and height
            int canvas_width = (int)json_obj["width"], canvas_height = (int)json_obj["height"];

            // Create a empty canvas
            canvas_image = new Bitmap(canvas_width, canvas_height);
            canvas_graphics = Graphics.FromImage(canvas_image);

            // Apply the background color
            Color background_color = Color.FromArgb(Convert.ToInt32((string)json_obj["background"], 16));
            canvas_graphics.Clear(background_color);

            // Font to use
            default_font = (string)json_obj["font_name"];

            // Draw static items
            draw_static_items(json_obj);

            // Draw variables
            draw_dynamics_items(json_obj);
        }

        private void draw_string(Graphics graphics, JObject properties, string content)
        {
            Font font = new Font(default_font, (int)properties["font_size"]);
            SolidBrush brush = new SolidBrush(Color.FromArgb(Convert.ToInt32((string)properties["font_color"], 16)));
            PointF point = new PointF((float)properties["position_x"], (float)properties["position_y"]);

            graphics.DrawString(content, font, brush, point);

        }

        private void draw_static_items(JObject json_obj)
        {
            JArray fields = (JArray)json_obj["fields"];

            // Iterate through the array to draw static elements
            foreach (JObject field in fields)
            {
                string type = (string)field["type"];
                if (!type.Equals("static"))
                    continue;
                
                string content_type = (string)field["content_type"];
                if(content_type.Equals("text"))
                {
                    draw_string(canvas_graphics, (JObject)field["properties"], (string)field["content"]);
                }
                else
                {
                    // Maybe someday
                }
            } // End foreach
            
            // Save the base image
            string base_file = "base.jpg";
            string filepath = Path.Combine(base_path, base_file);
            canvas_image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);

        } //End method

        private void draw_dynamics_items(JObject json_obj)
        {
            JArray fields = (JArray)json_obj["fields"];
            CsvReader csv_obj = new CsvReader(new StreamReader(csv_file));

            while( csv_obj.Read() )
            {
                // Duplicate base image
                Image id_card_image = new Bitmap(canvas_image);
                Graphics id_card_graphics = Graphics.FromImage(id_card_image);

                // Iterate through the array to draw dynamic elements
                foreach (JObject field in fields)
                {
                    string type = (string)field["type"];
                    if (!type.Equals("dynamic"))
                        continue;

                    string content_type = (string)field["content_type"];
                    if (content_type.Equals("text"))
                    {
                        // Obtain content for csv file
                        string content = csv_obj.GetField<string>((string)field["csv_column"]);

                        // Draw obtained content
                        draw_string(id_card_graphics, (JObject)field["properties"], content);

                        // Save the constructed image
                        string filename = csv_obj.GetField<string>("uniqueid") + ".jpg";
                        string filepath = Path.Combine(base_path, filename);
                        id_card_image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    } 
                }


            } //End while
        } // End method


    } // End class
} // End namespace
