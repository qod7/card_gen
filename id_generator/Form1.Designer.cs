namespace id_generator
{
    partial class id_generator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.preview_box = new System.Windows.Forms.PictureBox();
            this.label_design = new System.Windows.Forms.Label();
            this.button_json = new System.Windows.Forms.Button();
            this.label_csv = new System.Windows.Forms.Label();
            this.button_csv = new System.Windows.Forms.Button();
            this.button_generate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.preview_box)).BeginInit();
            this.SuspendLayout();
            // 
            // preview_box
            // 
            this.preview_box.Location = new System.Drawing.Point(25, 29);
            this.preview_box.Name = "preview_box";
            this.preview_box.Size = new System.Drawing.Size(240, 432);
            this.preview_box.TabIndex = 0;
            this.preview_box.TabStop = false;
            // 
            // label_design
            // 
            this.label_design.AutoSize = true;
            this.label_design.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_design.Location = new System.Drawing.Point(315, 39);
            this.label_design.Name = "label_design";
            this.label_design.Size = new System.Drawing.Size(136, 29);
            this.label_design.TabIndex = 1;
            this.label_design.Text = "Design File";
            // 
            // button_json
            // 
            this.button_json.Location = new System.Drawing.Point(330, 82);
            this.button_json.Name = "button_json";
            this.button_json.Size = new System.Drawing.Size(102, 32);
            this.button_json.TabIndex = 2;
            this.button_json.Text = "Select File";
            this.button_json.UseVisualStyleBackColor = true;
            this.button_json.Click += new System.EventHandler(this.button_json_Click);
            // 
            // label_csv
            // 
            this.label_csv.AutoSize = true;
            this.label_csv.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_csv.Location = new System.Drawing.Point(325, 146);
            this.label_csv.Name = "label_csv";
            this.label_csv.Size = new System.Drawing.Size(109, 29);
            this.label_csv.TabIndex = 3;
            this.label_csv.Text = "Data File";
            // 
            // button_csv
            // 
            this.button_csv.Location = new System.Drawing.Point(330, 201);
            this.button_csv.Name = "button_csv";
            this.button_csv.Size = new System.Drawing.Size(102, 32);
            this.button_csv.TabIndex = 4;
            this.button_csv.Text = "Select File";
            this.button_csv.UseVisualStyleBackColor = true;
            this.button_csv.Click += new System.EventHandler(this.button_csv_Click);
            // 
            // button_generate
            // 
            this.button_generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_generate.Location = new System.Drawing.Point(298, 286);
            this.button_generate.Name = "button_generate";
            this.button_generate.Size = new System.Drawing.Size(183, 108);
            this.button_generate.TabIndex = 5;
            this.button_generate.Text = "Generate";
            this.button_generate.UseVisualStyleBackColor = true;
            this.button_generate.Click += new System.EventHandler(this.button_generate_Click);
            // 
            // id_generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 486);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.button_csv);
            this.Controls.Add(this.label_csv);
            this.Controls.Add(this.button_json);
            this.Controls.Add(this.label_design);
            this.Controls.Add(this.preview_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "id_generator";
            this.Text = "ID Generator";
            ((System.ComponentModel.ISupportInitialize)(this.preview_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox preview_box;
        private System.Windows.Forms.Label label_design;
        private System.Windows.Forms.Button button_json;
        private System.Windows.Forms.Label label_csv;
        private System.Windows.Forms.Button button_csv;
        private System.Windows.Forms.Button button_generate;

    }
}

