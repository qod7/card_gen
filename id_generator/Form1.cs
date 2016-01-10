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
        private String photos_folder;
        private String idcards_folder;

        public id_generator()
        {
            InitializeComponent();

            idcards_folder = "idcards";
            // Create directory for idcards
            Directory.CreateDirectory(idcards_folder);

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

            // Path for photos
            photos_folder = Path.Combine(Path.GetDirectoryName(csv_file), "photos");
            
            // Throw exception if photos folder not found
            if(!Directory.Exists(photos_folder))
            {
                throw new Exception("photos folder not found");
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

            JArray fields = (JArray)json_obj["fields"];

            // Draw static items
            draw_static_items(fields);

            // Draw dynamic items
            draw_dynamics_items(fields);
        }

        // Draw given string onto cavas
        private void draw_string(Graphics graphics, JObject properties, string content)
        {
            // Draw element if visible is true
            string visible = (string)properties["visible"];
            if (!visible.Equals("true"))
            {
                return;
            }

            Font font = new Font(default_font, (int)properties["font_size"]);
            SolidBrush brush = new SolidBrush(Color.FromArgb(Convert.ToInt32((string)properties["font_color"], 16)));
            PointF point = new PointF((float)properties["position_x"], (float)properties["position_y"]);

            graphics.DrawString(content, font, brush, point);

        }

        // Draw given image onto canvas
        private void draw_image(Graphics graphics, JObject properties, string image_filepath)
        {
            // Draw element if visible is true
            string visible = (string)properties["visible"];
            if(!visible.Equals("true"))
            {
                return;
            }

            Image photo = Image.FromFile(image_filepath);
            PointF point = new PointF((float)properties["position_x"], (float)properties["position_y"]);

            // If needed insert code for resizing

            graphics.DrawImage(photo, point);
        }

        private void draw_static_items(JArray fields)
        {
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
                else if (content_type.Equals("image"))
                {
                    // Nothing here
                }
                else
                {
                    // Nothing
                }
            } // End foreach
            
            // Save the base image
            string filepath = Path.Combine(idcards_folder, "base.jpg");
            canvas_image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);

        } //End method

        private void draw_dynamics_items(JArray fields)
        {
            CsvReader csv_obj = new CsvReader(new StreamReader(csv_file));

            while(csv_obj.Read())
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
                    } 
                    else if (content_type.Equals("image"))
                    {
                        string photo_filepath = Path.Combine(photos_folder, csv_obj.GetField<string>((string)field["csv_column"]));

                        // Draw image on canvas
                        draw_image(id_card_graphics, (JObject)field["properties"], photo_filepath);
                    }
                    else
                    {
                        // I wonder what
                    }

                    // Save the constructed image
                    string filename = csv_obj.GetField<string>("uniqueid") + ".jpg";
                    string filepath = Path.Combine(idcards_folder, filename);
                    id_card_image.Save(filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

            } //End while
        } // End method


    } // End class
} // End namespace
