namespace WindowsFormsApp2
{
    partial class Dispatch
    {
        private string callPath;
        private string responsePath;
        private MachineLearning ml;
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dispatch));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.save_button = new System.Windows.Forms.Button();
            this.select_button = new System.Windows.Forms.Button();
            this.analyse_button = new System.Windows.Forms.Button();
            this.import_button = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.options_box = new System.Windows.Forms.GroupBox();
            this.label_time = new System.Windows.Forms.Label();
            this.trackBar_time_start = new System.Windows.Forms.TrackBar();
            this.label_week = new System.Windows.Forms.Label();
            this.checkedListBox_week = new System.Windows.Forms.CheckedListBox();
            this.label_month = new System.Windows.Forms.Label();
            this.checkedListBox_month = new System.Windows.Forms.CheckedListBox();
            this.label_year = new System.Windows.Forms.Label();
            this.checkedListBox_year = new System.Windows.Forms.CheckedListBox();
            this.Import_panel = new System.Windows.Forms.Panel();
            this.Result_box = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Min_button = new System.Windows.Forms.Button();
            this.Close_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar_time_end = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label_start_time = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_end_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.options_box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time_start)).BeginInit();
            this.Import_panel.SuspendLayout();
            this.Result_box.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time_end)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.splitContainer1.Panel1.Controls.Add(this.save_button);
            this.splitContainer1.Panel1.Controls.Add(this.select_button);
            this.splitContainer1.Panel1.Controls.Add(this.analyse_button);
            this.splitContainer1.Panel1.Controls.Add(this.import_button);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dispatch_MouseDown);
            this.splitContainer1.Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dispatch_MouseMove);
            this.splitContainer1.Panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dispatch_MouseUp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.Import_panel);
            this.splitContainer1.Panel2.Controls.Add(this.Min_button);
            this.splitContainer1.Panel2.Controls.Add(this.Close_button);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1225, 746);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dispatch_MouseDown);
            this.splitContainer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dispatch_MouseMove);
            this.splitContainer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dispatch_MouseUp);
            // 
            // save_button
            // 
            this.save_button.FlatAppearance.BorderSize = 0;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.save_button.Image = ((System.Drawing.Image)(resources.GetObject("save_button.Image")));
            this.save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_button.Location = new System.Drawing.Point(11, 236);
            this.save_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(252, 58);
            this.save_button.TabIndex = 3;
            this.save_button.Text = "   Save Rules";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Download_Model_Click);
            // 
            // select_button
            // 
            this.select_button.FlatAppearance.BorderSize = 0;
            this.select_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.select_button.Image = ((System.Drawing.Image)(resources.GetObject("select_button.Image")));
            this.select_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.select_button.Location = new System.Drawing.Point(11, 121);
            this.select_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(252, 58);
            this.select_button.TabIndex = 2;
            this.select_button.Text = " Select";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.Select_button_Click);
            // 
            // analyse_button
            // 
            this.analyse_button.FlatAppearance.BorderSize = 0;
            this.analyse_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analyse_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.analyse_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.analyse_button.Image = ((System.Drawing.Image)(resources.GetObject("analyse_button.Image")));
            this.analyse_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.analyse_button.Location = new System.Drawing.Point(11, 178);
            this.analyse_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.analyse_button.Name = "analyse_button";
            this.analyse_button.Size = new System.Drawing.Size(252, 58);
            this.analyse_button.TabIndex = 1;
            this.analyse_button.Text = "  Analyse";
            this.analyse_button.UseVisualStyleBackColor = true;
            this.analyse_button.Click += new System.EventHandler(this.Analyse_button_Click);
            // 
            // import_button
            // 
            this.import_button.FlatAppearance.BorderSize = 0;
            this.import_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import_button.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.import_button.Image = ((System.Drawing.Image)(resources.GetObject("import_button.Image")));
            this.import_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.import_button.Location = new System.Drawing.Point(11, 62);
            this.import_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(252, 58);
            this.import_button.TabIndex = 0;
            this.import_button.Text = "  Import";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.Import_button_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.options_box);
            this.panel4.Location = new System.Drawing.Point(32, 492);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(869, 242);
            this.panel4.TabIndex = 6;
            // 
            // options_box
            // 
            this.options_box.Controls.Add(this.label_end_time);
            this.options_box.Controls.Add(this.label13);
            this.options_box.Controls.Add(this.label_start_time);
            this.options_box.Controls.Add(this.label11);
            this.options_box.Controls.Add(this.trackBar_time_end);
            this.options_box.Controls.Add(this.label_time);
            this.options_box.Controls.Add(this.trackBar_time_start);
            this.options_box.Controls.Add(this.label_week);
            this.options_box.Controls.Add(this.checkedListBox_week);
            this.options_box.Controls.Add(this.label_month);
            this.options_box.Controls.Add(this.checkedListBox_month);
            this.options_box.Controls.Add(this.label_year);
            this.options_box.Controls.Add(this.checkedListBox_year);
            this.options_box.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.options_box.Location = new System.Drawing.Point(20, 7);
            this.options_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.options_box.Name = "options_box";
            this.options_box.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.options_box.Size = new System.Drawing.Size(835, 231);
            this.options_box.TabIndex = 0;
            this.options_box.TabStop = false;
            this.options_box.Text = "Options";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(473, 28);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(47, 21);
            this.label_time.TabIndex = 7;
            this.label_time.Text = "Time";
            // 
            // trackBar_time_start
            // 
            this.trackBar_time_start.Location = new System.Drawing.Point(465, 83);
            this.trackBar_time_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_time_start.Maximum = 24;
            this.trackBar_time_start.Name = "trackBar_time_start";
            this.trackBar_time_start.Size = new System.Drawing.Size(332, 56);
            this.trackBar_time_start.TabIndex = 6;
            this.trackBar_time_start.Scroll += new System.EventHandler(this.trackBar_time_start_Scroll);
            // 
            // label_week
            // 
            this.label_week.AutoSize = true;
            this.label_week.Location = new System.Drawing.Point(169, 28);
            this.label_week.Name = "label_week";
            this.label_week.Size = new System.Drawing.Size(58, 21);
            this.label_week.TabIndex = 5;
            this.label_week.Text = "Week";
            // 
            // checkedListBox_week
            // 
            this.checkedListBox_week.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkedListBox_week.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox_week.CheckOnClick = true;
            this.checkedListBox_week.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox_week.FormattingEnabled = true;
            this.checkedListBox_week.Items.AddRange(new object[] {
            "Sun",
            "Mon",
            "Tue",
            "Wed",
            "Thr",
            "Fri",
            "Sat"});
            this.checkedListBox_week.Location = new System.Drawing.Point(169, 52);
            this.checkedListBox_week.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox_week.Name = "checkedListBox_week";
            this.checkedListBox_week.Size = new System.Drawing.Size(131, 149);
            this.checkedListBox_week.TabIndex = 4;
            // 
            // label_month
            // 
            this.label_month.AutoSize = true;
            this.label_month.Location = new System.Drawing.Point(13, 28);
            this.label_month.Name = "label_month";
            this.label_month.Size = new System.Drawing.Size(65, 21);
            this.label_month.TabIndex = 3;
            this.label_month.Text = "Month";
            // 
            // checkedListBox_month
            // 
            this.checkedListBox_month.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkedListBox_month.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox_month.CheckOnClick = true;
            this.checkedListBox_month.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox_month.FormattingEnabled = true;
            this.checkedListBox_month.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.checkedListBox_month.Location = new System.Drawing.Point(13, 52);
            this.checkedListBox_month.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox_month.Name = "checkedListBox_month";
            this.checkedListBox_month.Size = new System.Drawing.Size(131, 149);
            this.checkedListBox_month.TabIndex = 2;
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Location = new System.Drawing.Point(323, 28);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(49, 21);
            this.label_year.TabIndex = 1;
            this.label_year.Text = "Year";
            // 
            // checkedListBox_year
            // 
            this.checkedListBox_year.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkedListBox_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox_year.CheckOnClick = true;
            this.checkedListBox_year.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox_year.FormattingEnabled = true;
            this.checkedListBox_year.Location = new System.Drawing.Point(323, 52);
            this.checkedListBox_year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox_year.Name = "checkedListBox_year";
            this.checkedListBox_year.Size = new System.Drawing.Size(131, 149);
            this.checkedListBox_year.TabIndex = 0;
            // 
            // Import_panel
            // 
            this.Import_panel.Controls.Add(this.Result_box);
            this.Import_panel.Location = new System.Drawing.Point(32, 81);
            this.Import_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Import_panel.Name = "Import_panel";
            this.Import_panel.Size = new System.Drawing.Size(869, 412);
            this.Import_panel.TabIndex = 5;
            // 
            // Result_box
            // 
            this.Result_box.Controls.Add(this.label9);
            this.Result_box.Controls.Add(this.label10);
            this.Result_box.Controls.Add(this.label8);
            this.Result_box.Controls.Add(this.label7);
            this.Result_box.Controls.Add(this.label6);
            this.Result_box.Controls.Add(this.label5);
            this.Result_box.Controls.Add(this.label4);
            this.Result_box.Controls.Add(this.label3);
            this.Result_box.Controls.Add(this.label2);
            this.Result_box.Controls.Add(this.label1);
            this.Result_box.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result_box.Location = new System.Drawing.Point(20, 2);
            this.Result_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Result_box.Name = "Result_box";
            this.Result_box.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Result_box.Size = new System.Drawing.Size(835, 402);
            this.Result_box.TabIndex = 0;
            this.Result_box.TabStop = false;
            this.Result_box.Text = "Result";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 330);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 367);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 20);
            this.label10.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 20);
            this.label7.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 0;
            // 
            // Min_button
            // 
            this.Min_button.FlatAppearance.BorderSize = 0;
            this.Min_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Min_button.Image = ((System.Drawing.Image)(resources.GetObject("Min_button.Image")));
            this.Min_button.Location = new System.Drawing.Point(869, 30);
            this.Min_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Min_button.Name = "Min_button";
            this.Min_button.Size = new System.Drawing.Size(33, 28);
            this.Min_button.TabIndex = 2;
            this.Min_button.UseVisualStyleBackColor = true;
            this.Min_button.Click += new System.EventHandler(this.Min_button_Click);
            // 
            // Close_button
            // 
            this.Close_button.FlatAppearance.BorderSize = 0;
            this.Close_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close_button.Image = ((System.Drawing.Image)(resources.GetObject("Close_button.Image")));
            this.Close_button.Location = new System.Drawing.Point(908, 30);
            this.Close_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Close_button.Name = "Close_button";
            this.Close_button.Size = new System.Drawing.Size(33, 28);
            this.Close_button.TabIndex = 2;
            this.Close_button.UseVisualStyleBackColor = true;
            this.Close_button.Click += new System.EventHandler(this.Close_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(271, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(391, 37);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Dispatch Analyser";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(32, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 59);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 12);
            this.panel1.TabIndex = 0;
            // 
            // trackBar_time_end
            // 
            this.trackBar_time_end.Location = new System.Drawing.Point(465, 154);
            this.trackBar_time_end.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_time_end.Maximum = 24;
            this.trackBar_time_end.Name = "trackBar_time_end";
            this.trackBar_time_end.Size = new System.Drawing.Size(332, 56);
            this.trackBar_time_end.TabIndex = 8;
            this.trackBar_time_end.Value = 24;
            this.trackBar_time_end.Scroll += new System.EventHandler(this.trackBar_time_end_Scroll);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(473, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 19);
            this.label11.TabIndex = 9;
            this.label11.Text = "Start time";
            // 
            // label_start_time
            // 
            this.label_start_time.AutoSize = true;
            this.label_start_time.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_start_time.Location = new System.Drawing.Point(787, 85);
            this.label_start_time.Name = "label_start_time";
            this.label_start_time.Size = new System.Drawing.Size(37, 19);
            this.label_start_time.TabIndex = 10;
            this.label_start_time.Text = "0:00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(473, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 19);
            this.label13.TabIndex = 11;
            this.label13.Text = "End time";
            // 
            // label_end_time
            // 
            this.label_end_time.AutoSize = true;
            this.label_end_time.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_end_time.Location = new System.Drawing.Point(787, 156);
            this.label_end_time.Name = "label_end_time";
            this.label_end_time.Size = new System.Drawing.Size(45, 19);
            this.label_end_time.TabIndex = 12;
            this.label_end_time.Text = "24:00";
            // 
            // Dispatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1225, 746);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Dispatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatch";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.options_box.ResumeLayout(false);
            this.options_box.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time_start)).EndInit();
            this.Import_panel.ResumeLayout(false);
            this.Result_box.ResumeLayout(false);
            this.Result_box.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_time_end)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.Button analyse_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Close_button;
        private System.Windows.Forms.Button Min_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Import_panel;
        private System.Windows.Forms.GroupBox Result_box;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox options_box;
        private System.Windows.Forms.CheckedListBox checkedListBox_year;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.TrackBar trackBar_time_start;
        private System.Windows.Forms.Label label_week;
        private System.Windows.Forms.CheckedListBox checkedListBox_week;
        private System.Windows.Forms.Label label_month;
        private System.Windows.Forms.CheckedListBox checkedListBox_month;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.TrackBar trackBar_time_end;
        private System.Windows.Forms.Label label_start_time;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_end_time;
        private System.Windows.Forms.Label label13;
    }
}

