namespace PGG
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.checkR = new System.Windows.Forms.CheckBox();
            this.checkB = new System.Windows.Forms.CheckBox();
            this.checkG = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelR = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelG = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelB = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSelected = new System.Windows.Forms.Panel();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(857, 80);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(640, 590);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 590);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(451, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 41);
            this.button4.TabIndex = 6;
            this.button4.Text = "B Gray";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(262, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 41);
            this.button5.TabIndex = 7;
            this.button5.Text = "R Gray";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(357, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 41);
            this.button6.TabIndex = 8;
            this.button6.Text = "G Gray";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonGray_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(718, 203);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(84, 41);
            this.button7.TabIndex = 9;
            this.button7.Text = "<---";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(662, 5);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(84, 41);
            this.button8.TabIndex = 10;
            this.button8.Text = "BW";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonBlackWhite_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(718, 109);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(84, 41);
            this.button9.TabIndex = 11;
            this.button9.Text = "Load";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(718, 250);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(84, 41);
            this.button10.TabIndex = 12;
            this.button10.Text = "Clear";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(718, 156);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(84, 41);
            this.button11.TabIndex = 13;
            this.button11.Text = "Save";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // checkR
            // 
            this.checkR.AutoSize = true;
            this.checkR.Checked = true;
            this.checkR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkR.Location = new System.Drawing.Point(19, 14);
            this.checkR.Name = "checkR";
            this.checkR.Size = new System.Drawing.Size(55, 20);
            this.checkR.TabIndex = 14;
            this.checkR.Text = "Red";
            this.checkR.UseVisualStyleBackColor = true;
            this.checkR.CheckedChanged += new System.EventHandler(this.checkR_CheckedChanged);
            // 
            // checkB
            // 
            this.checkB.AutoSize = true;
            this.checkB.Checked = true;
            this.checkB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkB.Location = new System.Drawing.Point(182, 14);
            this.checkB.Name = "checkB";
            this.checkB.Size = new System.Drawing.Size(56, 20);
            this.checkB.TabIndex = 15;
            this.checkB.Text = "Blue";
            this.checkB.UseVisualStyleBackColor = true;
            this.checkB.CheckedChanged += new System.EventHandler(this.checkB_CheckedChanged);
            // 
            // checkG
            // 
            this.checkG.AutoSize = true;
            this.checkG.Checked = true;
            this.checkG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkG.Location = new System.Drawing.Point(98, 14);
            this.checkG.Name = "checkG";
            this.checkG.Size = new System.Drawing.Size(66, 20);
            this.checkG.TabIndex = 16;
            this.checkG.Text = "Green";
            this.checkG.UseVisualStyleBackColor = true;
            this.checkG.CheckedChanged += new System.EventHandler(this.checkG_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.labelR);
            this.panel1.Location = new System.Drawing.Point(16, 689);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 19);
            this.panel1.TabIndex = 17;
            // 
            // labelR
            // 
            this.labelR.AutoSize = true;
            this.labelR.Location = new System.Drawing.Point(0, 0);
            this.labelR.Name = "labelR";
            this.labelR.Size = new System.Drawing.Size(27, 16);
            this.labelR.TabIndex = 18;
            this.labelR.Text = "R =";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Controls.Add(this.labelG);
            this.panel2.Location = new System.Drawing.Point(93, 689);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(77, 19);
            this.panel2.TabIndex = 18;
            // 
            // labelG
            // 
            this.labelG.AutoSize = true;
            this.labelG.Location = new System.Drawing.Point(0, 0);
            this.labelG.Name = "labelG";
            this.labelG.Size = new System.Drawing.Size(27, 16);
            this.labelG.TabIndex = 18;
            this.labelG.Text = "G =";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Blue;
            this.panel3.Controls.Add(this.labelB);
            this.panel3.Location = new System.Drawing.Point(170, 689);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(77, 19);
            this.panel3.TabIndex = 19;
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(0, 0);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(26, 16);
            this.labelB.TabIndex = 18;
            this.labelB.Text = "B =";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 41);
            this.button1.TabIndex = 20;
            this.button1.Text = "Negative";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonNegative_Click);
            // 
            // panelSelected
            // 
            this.panelSelected.BackColor = System.Drawing.Color.Snow;
            this.panelSelected.Location = new System.Drawing.Point(247, 689);
            this.panelSelected.Name = "panelSelected";
            this.panelSelected.Size = new System.Drawing.Size(77, 19);
            this.panelSelected.TabIndex = 21;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(335, 681);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(47, 16);
            this.labelWidth.TabIndex = 22;
            this.labelWidth.Text = "Width: ";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(330, 697);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(52, 16);
            this.labelHeight.TabIndex = 23;
            this.labelHeight.Text = "Height: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(752, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 41);
            this.button2.TabIndex = 24;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonBrightness_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(842, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 41);
            this.button3.TabIndex = 25;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonBrightness_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(932, 5);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(84, 41);
            this.button12.TabIndex = 26;
            this.button12.Text = "*";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.buttonContrast_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1022, 5);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(84, 41);
            this.button13.TabIndex = 27;
            this.button13.Text = "/";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.buttonContrast_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1112, 5);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(84, 41);
            this.button14.TabIndex = 28;
            this.button14.Text = "Sobel";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.buttonSobel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 722);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.panelSelected);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkG);
            this.Controls.Add(this.checkB);
            this.Controls.Add(this.checkR);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Image Processor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.CheckBox checkR;
        private System.Windows.Forms.CheckBox checkB;
        private System.Windows.Forms.CheckBox checkG;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelG;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelSelected;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
    }
}

