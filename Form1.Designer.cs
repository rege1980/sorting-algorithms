namespace sortingAlgorithms
{
    partial class Sorting
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
            butBub = new Button();
            boxInput = new TextBox();
            boxOutput = new TextBox();
            bwBubble = new System.ComponentModel.BackgroundWorker();
            butIns = new Button();
            butSel = new Button();
            butMer = new Button();
            butQui = new Button();
            strip = new StatusStrip();
            status = new ToolStripStatusLabel();
            barProgress = new ToolStripProgressBar();
            bwInsert = new System.ComponentModel.BackgroundWorker();
            bwSelect = new System.ComponentModel.BackgroundWorker();
            bwMerge = new System.ComponentModel.BackgroundWorker();
            bwQuick = new System.ComponentModel.BackgroundWorker();
            chkBoxText = new CheckBox();
            chkBoxRandom = new CheckBox();
            chkBoxFile = new CheckBox();
            butRand = new Button();
            UDRand = new NumericUpDown();
            labRand = new Label();
            strip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UDRand).BeginInit();
            SuspendLayout();
            // 
            // butBub
            // 
            butBub.Enabled = false;
            butBub.Location = new Point(37, 117);
            butBub.Name = "butBub";
            butBub.Size = new Size(90, 25);
            butBub.TabIndex = 0;
            butBub.Text = "Bubble Sort";
            butBub.UseVisualStyleBackColor = true;
            butBub.Click += sorting_Button_Click;
            // 
            // boxInput
            // 
            boxInput.Location = new Point(37, 67);
            boxInput.MaxLength = 200;
            boxInput.Name = "boxInput";
            boxInput.Size = new Size(234, 23);
            boxInput.TabIndex = 1;
            boxInput.TextChanged += boxInput_TextChanged;
            // 
            // boxOutput
            // 
            boxOutput.Location = new Point(39, 170);
            boxOutput.MaxLength = 200;
            boxOutput.Name = "boxOutput";
            boxOutput.ReadOnly = true;
            boxOutput.Size = new Size(472, 23);
            boxOutput.TabIndex = 2;
            // 
            // bwBubble
            // 
            bwBubble.WorkerReportsProgress = true;
            bwBubble.WorkerSupportsCancellation = true;
            bwBubble.DoWork += bwBubble_DoWork;
            bwBubble.ProgressChanged += ProgressChanged;
            bwBubble.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // butIns
            // 
            butIns.Enabled = false;
            butIns.Location = new Point(133, 117);
            butIns.Name = "butIns";
            butIns.Size = new Size(90, 25);
            butIns.TabIndex = 3;
            butIns.Text = "Insertion Sort";
            butIns.UseVisualStyleBackColor = true;
            butIns.Click += sorting_Button_Click;
            // 
            // butSel
            // 
            butSel.Enabled = false;
            butSel.Location = new Point(229, 117);
            butSel.Name = "butSel";
            butSel.Size = new Size(90, 25);
            butSel.TabIndex = 4;
            butSel.Text = "Selection Sort";
            butSel.UseVisualStyleBackColor = true;
            butSel.Click += sorting_Button_Click;
            // 
            // butMer
            // 
            butMer.Enabled = false;
            butMer.Location = new Point(325, 117);
            butMer.Name = "butMer";
            butMer.Size = new Size(90, 25);
            butMer.TabIndex = 5;
            butMer.Text = "Merge Sort";
            butMer.UseVisualStyleBackColor = true;
            butMer.Click += sorting_Button_Click;
            // 
            // butQui
            // 
            butQui.Enabled = false;
            butQui.Location = new Point(421, 117);
            butQui.Name = "butQui";
            butQui.Size = new Size(90, 25);
            butQui.TabIndex = 6;
            butQui.Text = "Quick Sort";
            butQui.UseVisualStyleBackColor = true;
            butQui.Click += sorting_Button_Click;
            // 
            // strip
            // 
            strip.Items.AddRange(new ToolStripItem[] { status, barProgress });
            strip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            strip.Location = new Point(0, 307);
            strip.Name = "strip";
            strip.Size = new Size(779, 22);
            strip.TabIndex = 7;
            strip.Text = "statusStrip1";
            // 
            // status
            // 
            status.Name = "status";
            status.Size = new Size(0, 17);
            // 
            // barProgress
            // 
            barProgress.Alignment = ToolStripItemAlignment.Right;
            barProgress.Name = "barProgress";
            barProgress.RightToLeft = RightToLeft.Yes;
            barProgress.RightToLeftLayout = true;
            barProgress.Size = new Size(200, 16);
            barProgress.Step = 1;
            barProgress.Visible = false;
            // 
            // bwInsert
            // 
            bwInsert.WorkerReportsProgress = true;
            bwInsert.WorkerSupportsCancellation = true;
            bwInsert.DoWork += bwInsert_DoWork;
            bwInsert.ProgressChanged += ProgressChanged;
            bwInsert.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bwSelect
            // 
            bwSelect.WorkerReportsProgress = true;
            bwSelect.WorkerSupportsCancellation = true;
            bwSelect.DoWork += bwSelect_DoWork;
            bwSelect.ProgressChanged += ProgressChanged;
            bwSelect.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bwMerge
            // 
            bwMerge.WorkerReportsProgress = true;
            bwMerge.WorkerSupportsCancellation = true;
            bwMerge.DoWork += bwMerge_DoWork;
            bwMerge.ProgressChanged += ProgressChanged;
            bwMerge.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // bwQuick
            // 
            bwQuick.WorkerReportsProgress = true;
            bwQuick.WorkerSupportsCancellation = true;
            bwQuick.DoWork += bwQuick_DoWork;
            bwQuick.ProgressChanged += ProgressChanged;
            bwQuick.RunWorkerCompleted += RunWorkerCompleted;
            // 
            // chkBoxText
            // 
            chkBoxText.AutoSize = true;
            chkBoxText.Checked = true;
            chkBoxText.CheckState = CheckState.Checked;
            chkBoxText.Location = new Point(39, 25);
            chkBoxText.Name = "chkBoxText";
            chkBoxText.Size = new Size(103, 19);
            chkBoxText.TabIndex = 8;
            chkBoxText.Text = "Enter numbers";
            chkBoxText.UseVisualStyleBackColor = true;
            chkBoxText.CheckedChanged += checkBoxChanged;
            // 
            // chkBoxRandom
            // 
            chkBoxRandom.AutoSize = true;
            chkBoxRandom.Location = new Point(325, 25);
            chkBoxRandom.Name = "chkBoxRandom";
            chkBoxRandom.Size = new Size(140, 19);
            chkBoxRandom.TabIndex = 9;
            chkBoxRandom.Text = "Use random numbers";
            chkBoxRandom.UseVisualStyleBackColor = true;
            chkBoxRandom.CheckedChanged += checkBoxChanged;
            // 
            // chkBoxFile
            // 
            chkBoxFile.AutoSize = true;
            chkBoxFile.Enabled = false;
            chkBoxFile.Location = new Point(623, 25);
            chkBoxFile.Name = "chkBoxFile";
            chkBoxFile.Size = new Size(64, 19);
            chkBoxFile.TabIndex = 10;
            chkBoxFile.Text = "Use file";
            chkBoxFile.UseVisualStyleBackColor = true;
            chkBoxFile.Visible = false;
            chkBoxFile.CheckedChanged += checkBoxChanged;
            // 
            // butRand
            // 
            butRand.Enabled = false;
            butRand.Location = new Point(325, 65);
            butRand.Name = "butRand";
            butRand.Size = new Size(90, 25);
            butRand.TabIndex = 11;
            butRand.Text = "Generate";
            butRand.UseVisualStyleBackColor = true;
            butRand.Click += butRand_Click;
            // 
            // UDRand
            // 
            UDRand.BackColor = SystemColors.Control;
            UDRand.BorderStyle = BorderStyle.None;
            UDRand.Enabled = false;
            UDRand.Increment = new decimal(new int[] { 25, 0, 0, 0 });
            UDRand.Location = new Point(421, 70);
            UDRand.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            UDRand.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            UDRand.Name = "UDRand";
            UDRand.Size = new Size(66, 19);
            UDRand.TabIndex = 12;
            UDRand.TextAlign = HorizontalAlignment.Center;
            UDRand.Value = new decimal(new int[] { 200, 0, 0, 0 });
            UDRand.ValueChanged += UDRand_Value_changed;
            // 
            // labRand
            // 
            labRand.AutoSize = true;
            labRand.Enabled = false;
            labRand.Location = new Point(493, 70);
            labRand.Name = "labRand";
            labRand.Size = new Size(54, 15);
            labRand.TabIndex = 13;
            labRand.Text = "numbers";
            // 
            // Sorting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 329);
            Controls.Add(labRand);
            Controls.Add(UDRand);
            Controls.Add(butRand);
            Controls.Add(chkBoxFile);
            Controls.Add(chkBoxRandom);
            Controls.Add(chkBoxText);
            Controls.Add(strip);
            Controls.Add(butQui);
            Controls.Add(butMer);
            Controls.Add(butSel);
            Controls.Add(butIns);
            Controls.Add(boxOutput);
            Controls.Add(boxInput);
            Controls.Add(butBub);
            Name = "Sorting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            strip.ResumeLayout(false);
            strip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)UDRand).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox boxInput;
        private TextBox boxOutput;
        private Button butBub;
        private Button butIns;
        private Button butSel;
        private Button butMer;
        private Button butQui;
        private StatusStrip strip;
        private ToolStripStatusLabel status;
        private ToolStripProgressBar barProgress;
        private System.ComponentModel.BackgroundWorker bwBubble;
        private System.ComponentModel.BackgroundWorker bwInsert;
        private System.ComponentModel.BackgroundWorker bwSelect;
        private System.ComponentModel.BackgroundWorker bwMerge;
        private System.ComponentModel.BackgroundWorker bwQuick;
        private CheckBox chkBoxText;
        private CheckBox chkBoxRandom;
        private CheckBox chkBoxFile;
        private Button butRand;
        private NumericUpDown UDRand;
        private Label labRand;
    }
}