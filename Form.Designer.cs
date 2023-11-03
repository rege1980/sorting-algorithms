namespace WinFormsApp3
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            insertSortBut = new Button();
            inputBox = new TextBox();
            outputBox = new TextBox();
            selSortBut = new Button();
            bubSortBut = new Button();
            mrgSortBut = new Button();
            qkSortBut = new Button();
            label1 = new Label();
            label2 = new Label();
            randCheck = new CheckBox();
            randCountUD = new NumericUpDown();
            genBut = new Button();
            timeLab = new Label();
            randSrc = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)randCountUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)randSrc).BeginInit();
            SuspendLayout();
            // 
            // insertSortBut
            // 
            insertSortBut.Enabled = true;
            insertSortBut.FlatStyle = FlatStyle.System;
            insertSortBut.Location = new Point(320, 113);
            insertSortBut.Name = "insertSortBut";
            insertSortBut.Size = new Size(87, 29);
            insertSortBut.TabIndex = 5;
            insertSortBut.Text = "Insertion sort";
            insertSortBut.UseVisualStyleBackColor = true;
            insertSortBut.Click += insertSortBut_Click;
            // 
            // inputBox
            // 
            inputBox.Location = new Point(77, 33);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(273, 23);
            inputBox.TabIndex = 6;
            // 
            // outputBox
            // 
            outputBox.Location = new Point(77, 200);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(273, 23);
            outputBox.TabIndex = 7;
            // 
            // selSortBut
            // 
            selSortBut.Location = new Point(227, 113);
            selSortBut.Name = "selSortBut";
            selSortBut.Size = new Size(87, 29);
            selSortBut.TabIndex = 8;
            selSortBut.Text = "Selection sort";
            selSortBut.UseVisualStyleBackColor = true;
            selSortBut.Click += selSortBut_Click;
            // 
            // bubSortBut
            // 
            bubSortBut.Location = new Point(134, 113);
            bubSortBut.Name = "bubSortBut";
            bubSortBut.Size = new Size(87, 29);
            bubSortBut.TabIndex = 9;
            bubSortBut.Text = "Bubble sort";
            bubSortBut.UseVisualStyleBackColor = true;
            bubSortBut.Click += bubSortBut_Click;
            // 
            // mrgSortBut
            // 
            mrgSortBut.Enabled = false;
            mrgSortBut.Location = new Point(413, 113);
            mrgSortBut.Name = "mrgSortBut";
            mrgSortBut.Size = new Size(87, 29);
            mrgSortBut.TabIndex = 10;
            mrgSortBut.Text = "Merge sort";
            mrgSortBut.UseVisualStyleBackColor = true;
            mrgSortBut.Click += mrgSortBut_Click;
            // 
            // qkSortBut
            // 
            qkSortBut.Enabled = false;
            qkSortBut.Location = new Point(506, 113);
            qkSortBut.Name = "qkSortBut";
            qkSortBut.Size = new Size(87, 29);
            qkSortBut.TabIndex = 11;
            qkSortBut.Text = "Quick sort";
            qkSortBut.UseVisualStyleBackColor = true;
            qkSortBut.Click += qkSortBut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 36);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 12;
            label1.Text = "INPUT:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 203);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 13;
            label2.Text = "OUTPUT:";
            // 
            // randCheck
            // 
            randCheck.AutoSize = true;
            randCheck.Location = new Point(356, 35);
            randCheck.Name = "randCheck";
            randCheck.Size = new Size(154, 19);
            randCheck.TabIndex = 14;
            randCheck.Tag = "";
            randCheck.Text = "Use random numbers of";
            randCheck.UseVisualStyleBackColor = true;
            randCheck.CheckStateChanged += randCheck_CheckStateChanged;
            // 
            // randCountUD
            // 
            randCountUD.AutoSize = true;
            randCountUD.Enabled = false;
            randCountUD.Location = new Point(516, 33);
            randCountUD.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            randCountUD.Name = "randCountUD";
            randCountUD.Size = new Size(100, 23);
            randCountUD.TabIndex = 15;
            randCountUD.TextAlign = HorizontalAlignment.Center;
            randCountUD.ThousandsSeparator = true;
            randCountUD.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // genBut
            // 
            genBut.Enabled = false;
            genBut.Location = new Point(622, 32);
            genBut.Name = "genBut";
            genBut.Size = new Size(75, 23);
            genBut.TabIndex = 16;
            genBut.Text = "Generate";
            genBut.UseVisualStyleBackColor = true;
            genBut.Click += genBut_Click;
            // 
            // timeLab
            // 
            timeLab.AutoSize = true;
            timeLab.Location = new Point(77, 272);
            timeLab.Name = "timeLab";
            timeLab.Size = new Size(72, 15);
            timeLab.TabIndex = 17;
            timeLab.Text = "Sorting took";
            timeLab.Visible = false;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 311);
            Controls.Add(timeLab);
            Controls.Add(genBut);
            Controls.Add(randCountUD);
            Controls.Add(randCheck);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(qkSortBut);
            Controls.Add(mrgSortBut);
            Controls.Add(bubSortBut);
            Controls.Add(selSortBut);
            Controls.Add(outputBox);
            Controls.Add(inputBox);
            Controls.Add(insertSortBut);
            Name = "Form";
            Text = "Sorting Algorithms";
            ((System.ComponentModel.ISupportInitialize)randCountUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)randSrc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button insertSortBut;
        private TextBox inputBox;
        private TextBox outputBox;
        private Button selSortBut;
        private Button bubSortBut;
        private Button button1;
        private Button button2;
        private Button mrgSortBut;
        private Button qkSortBut;
        private Label label1;
        private Label label2;
        private CheckBox randCheck;
        private NumericUpDown randCountUD;
        private Button genBut;
        private Label timeLab;
        private BindingSource randSrc;
    }
}