namespace ApiFrontendDemo
{
    partial class Form1
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
            splitContainer1 = new SplitContainer();
            WeatherBox = new RichTextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            btnGetMovies = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnAddMovie = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGetWeather = new Button();
            movieGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movieGrid).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(WeatherBox);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel3);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel2);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(movieGrid);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // WeatherBox
            // 
            WeatherBox.BorderStyle = BorderStyle.None;
            WeatherBox.Dock = DockStyle.Fill;
            WeatherBox.ForeColor = SystemColors.WindowText;
            WeatherBox.Location = new Point(0, 150);
            WeatherBox.Name = "WeatherBox";
            WeatherBox.Size = new Size(266, 300);
            WeatherBox.TabIndex = 3;
            WeatherBox.Text = "";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(btnGetMovies);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(0, 100);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(266, 50);
            flowLayoutPanel3.TabIndex = 2;
            // 
            // btnGetMovies
            // 
            btnGetMovies.Location = new Point(3, 3);
            btnGetMovies.Name = "btnGetMovies";
            btnGetMovies.Size = new Size(111, 38);
            btnGetMovies.TabIndex = 0;
            btnGetMovies.Text = "Get Movies";
            btnGetMovies.UseVisualStyleBackColor = true;
            btnGetMovies.Click += btnGetMovies_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnAddMovie);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 50);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(266, 50);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // btnAddMovie
            // 
            btnAddMovie.Location = new Point(3, 3);
            btnAddMovie.Name = "btnAddMovie";
            btnAddMovie.Size = new Size(111, 41);
            btnAddMovie.TabIndex = 0;
            btnAddMovie.Text = "Add Movie";
            btnAddMovie.UseVisualStyleBackColor = true;
            btnAddMovie.Click += btnAddMovie_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnGetWeather);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(266, 50);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnGetWeather
            // 
            btnGetWeather.Location = new Point(3, 3);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(111, 44);
            btnGetWeather.TabIndex = 0;
            btnGetWeather.Text = "Get Weather";
            btnGetWeather.UseVisualStyleBackColor = true;
            btnGetWeather.Click += btnGetWeather_Click;
            // 
            // movieGrid
            // 
            movieGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movieGrid.Dock = DockStyle.Fill;
            movieGrid.Location = new Point(0, 0);
            movieGrid.Name = "movieGrid";
            movieGrid.Size = new Size(530, 450);
            movieGrid.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)movieGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button btnGetMovies;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnAddMovie;
        private FlowLayoutPanel flowLayoutPanel1;
        private DataGridView movieGrid;
        private RichTextBox WeatherBox;
        private Button btnGetWeather;
    }
}
