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
            this.label_design = new System.Windows.Forms.Label();
            this.button_json = new System.Windows.Forms.Button();
            this.label_csv = new System.Windows.Forms.Label();
            this.button_csv = new System.Windows.Forms.Button();
            this.button_generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_design
            // 
            this.label_design.AutoSize = true;
            this.label_design.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_design.Location = new System.Drawing.Point(163, 48);
            this.label_design.Name = "label_design";
            this.label_design.Size = new System.Drawing.Size(136, 29);
            this.label_design.TabIndex = 1;
            this.label_design.Text = "Design File";
            // 
            // button_json
            // 
            this.button_json.Location = new System.Drawing.Point(178, 91);
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
            this.label_csv.Location = new System.Drawing.Point(173, 155);
            this.label_csv.Name = "label_csv";
            this.label_csv.Size = new System.Drawing.Size(109, 29);
            this.label_csv.TabIndex = 3;
            this.label_csv.Text = "Data File";
            // 
            // button_csv
            // 
            this.button_csv.Location = new System.Drawing.Point(178, 210);
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
            this.button_generate.Location = new System.Drawing.Point(146, 295);
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
            this.ClientSize = new System.Drawing.Size(501, 506);
            this.Controls.Add(this.button_generate);
            this.Controls.Add(this.button_csv);
            this.Controls.Add(this.label_csv);
            this.Controls.Add(this.button_json);
            this.Controls.Add(this.label_design);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "id_generator";
            this.Text = "ID Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_design;
        private System.Windows.Forms.Button button_json;
        private System.Windows.Forms.Label label_csv;
        private System.Windows.Forms.Button button_csv;
        private System.Windows.Forms.Button button_generate;

    }
}

