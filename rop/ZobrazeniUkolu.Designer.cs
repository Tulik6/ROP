namespace rop
{
    partial class ZobrazeniUkolu
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ukolLabel = new System.Windows.Forms.Label();
            this.prioritaLabel = new System.Windows.Forms.Label();
            this.datumLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.kategorieLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.splnenoLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(38, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Úkol:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(38, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Priorita:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(38, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Datum splnění:";
            // 
            // ukolLabel
            // 
            this.ukolLabel.AutoSize = true;
            this.ukolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ukolLabel.Location = new System.Drawing.Point(39, 67);
            this.ukolLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.ukolLabel.Name = "ukolLabel";
            this.ukolLabel.Size = new System.Drawing.Size(45, 24);
            this.ukolLabel.TabIndex = 1;
            this.ukolLabel.Text = "úkol";
            // 
            // prioritaLabel
            // 
            this.prioritaLabel.AutoSize = true;
            this.prioritaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prioritaLabel.Location = new System.Drawing.Point(39, 142);
            this.prioritaLabel.Name = "prioritaLabel";
            this.prioritaLabel.Size = new System.Drawing.Size(66, 24);
            this.prioritaLabel.TabIndex = 1;
            this.prioritaLabel.Text = "priorita";
            // 
            // datumLabel
            // 
            this.datumLabel.AutoSize = true;
            this.datumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumLabel.Location = new System.Drawing.Point(39, 319);
            this.datumLabel.Name = "datumLabel";
            this.datumLabel.Size = new System.Drawing.Size(62, 24);
            this.datumLabel.TabIndex = 1;
            this.datumLabel.Text = "datum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(38, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kategorie:";
            // 
            // kategorieLabel
            // 
            this.kategorieLabel.AutoSize = true;
            this.kategorieLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kategorieLabel.Location = new System.Drawing.Point(39, 232);
            this.kategorieLabel.Name = "kategorieLabel";
            this.kategorieLabel.Size = new System.Drawing.Size(66, 24);
            this.kategorieLabel.TabIndex = 1;
            this.kategorieLabel.Text = "priorita";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Zavřít";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(332, 38);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 305);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // splnenoLabel
            // 
            this.splnenoLabel.AutoSize = true;
            this.splnenoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.splnenoLabel.Location = new System.Drawing.Point(371, 177);
            this.splnenoLabel.Name = "splnenoLabel";
            this.splnenoLabel.Size = new System.Drawing.Size(79, 29);
            this.splnenoLabel.TabIndex = 4;
            this.splnenoLabel.Text = "label5";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(572, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Potvrdit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ZobrazeniUkolu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 409);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.splnenoLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datumLabel);
            this.Controls.Add(this.kategorieLabel);
            this.Controls.Add(this.prioritaLabel);
            this.Controls.Add(this.ukolLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ZobrazeniUkolu";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ukolLabel;
        private System.Windows.Forms.Label prioritaLabel;
        private System.Windows.Forms.Label datumLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label kategorieLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label splnenoLabel;
        private System.Windows.Forms.Button button2;
    }
}