namespace Assignment_10._3._1
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
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            flowLayoutPanel8 = new FlowLayoutPanel();
            DeleteBtn = new Button();
            flowLayoutPanel7 = new FlowLayoutPanel();
            Updatebtn = new Button();
            SelectUpdatebtn = new Button();
            flowLayoutPanel6 = new FlowLayoutPanel();
            AddNewbtn = new Button();
            Submitbtn = new Button();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label6 = new Label();
            comboBox1 = new ComboBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label5 = new Label();
            salarytxtbox = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label4 = new Label();
            Nametxtbox = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            IDtxtbox = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanel6.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(329, 9);
            label1.Name = "label1";
            label1.Size = new Size(288, 25);
            label1.TabIndex = 0;
            label1.Text = "Employee Management System ";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel8);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel7);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel6);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel5);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel4);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel3);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel2);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(943, 522);
            splitContainer1.SplitterDistance = 314;
            splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel8
            // 
            flowLayoutPanel8.Controls.Add(DeleteBtn);
            flowLayoutPanel8.Dock = DockStyle.Top;
            flowLayoutPanel8.Location = new Point(0, 266);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            flowLayoutPanel8.Size = new Size(314, 38);
            flowLayoutPanel8.TabIndex = 7;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Location = new Point(3, 3);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(155, 23);
            DeleteBtn.TabIndex = 0;
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += DeleteBtn_Click;
            // 
            // flowLayoutPanel7
            // 
            flowLayoutPanel7.Controls.Add(Updatebtn);
            flowLayoutPanel7.Controls.Add(SelectUpdatebtn);
            flowLayoutPanel7.Dock = DockStyle.Top;
            flowLayoutPanel7.Location = new Point(0, 228);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            flowLayoutPanel7.Size = new Size(314, 38);
            flowLayoutPanel7.TabIndex = 6;
            // 
            // Updatebtn
            // 
            Updatebtn.Location = new Point(3, 3);
            Updatebtn.Name = "Updatebtn";
            Updatebtn.Size = new Size(155, 23);
            Updatebtn.TabIndex = 0;
            Updatebtn.Text = "Update";
            Updatebtn.UseVisualStyleBackColor = true;
            Updatebtn.Click += Updatebtn_Click;
            // 
            // SelectUpdatebtn
            // 
            SelectUpdatebtn.Location = new Point(164, 3);
            SelectUpdatebtn.Name = "SelectUpdatebtn";
            SelectUpdatebtn.Size = new Size(140, 23);
            SelectUpdatebtn.TabIndex = 1;
            SelectUpdatebtn.Text = "Select to Update";
            SelectUpdatebtn.UseVisualStyleBackColor = true;
            SelectUpdatebtn.Click += SelectUpdatebtn_Click;
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.Controls.Add(AddNewbtn);
            flowLayoutPanel6.Controls.Add(Submitbtn);
            flowLayoutPanel6.Dock = DockStyle.Top;
            flowLayoutPanel6.Location = new Point(0, 190);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(314, 38);
            flowLayoutPanel6.TabIndex = 5;
            // 
            // AddNewbtn
            // 
            AddNewbtn.Location = new Point(3, 3);
            AddNewbtn.Name = "AddNewbtn";
            AddNewbtn.Size = new Size(155, 29);
            AddNewbtn.TabIndex = 0;
            AddNewbtn.Text = "Add New";
            AddNewbtn.UseVisualStyleBackColor = true;
            AddNewbtn.Click += AddNewbtn_Click;
            // 
            // Submitbtn
            // 
            Submitbtn.Location = new Point(164, 3);
            Submitbtn.Name = "Submitbtn";
            Submitbtn.Size = new Size(140, 29);
            Submitbtn.TabIndex = 1;
            Submitbtn.Text = "Submit Record";
            Submitbtn.UseVisualStyleBackColor = true;
            Submitbtn.Click += Submitbtn_Click;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(label6);
            flowLayoutPanel5.Controls.Add(comboBox1);
            flowLayoutPanel5.Dock = DockStyle.Top;
            flowLayoutPanel5.Location = new Point(0, 152);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(314, 38);
            flowLayoutPanel5.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 0;
            label6.Text = "Department";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(79, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label5);
            flowLayoutPanel4.Controls.Add(salarytxtbox);
            flowLayoutPanel4.Dock = DockStyle.Top;
            flowLayoutPanel4.Location = new Point(0, 114);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(314, 38);
            flowLayoutPanel4.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 0;
            label5.Text = "Employee Salary";
            // 
            // salarytxtbox
            // 
            salarytxtbox.Location = new Point(102, 3);
            salarytxtbox.Name = "salarytxtbox";
            salarytxtbox.Size = new Size(128, 23);
            salarytxtbox.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.Controls.Add(Nametxtbox);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(0, 76);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(314, 38);
            flowLayoutPanel3.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 0;
            label4.Text = "Employee Name";
            // 
            // Nametxtbox
            // 
            Nametxtbox.Location = new Point(103, 3);
            Nametxtbox.Name = "Nametxtbox";
            Nametxtbox.Size = new Size(128, 23);
            Nametxtbox.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(IDtxtbox);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(0, 38);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(314, 38);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 0;
            label3.Text = "Employee ID";
            // 
            // IDtxtbox
            // 
            IDtxtbox.Location = new Point(82, 3);
            IDtxtbox.Name = "IDtxtbox";
            IDtxtbox.Size = new Size(128, 23);
            IDtxtbox.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(314, 38);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(174, 15);
            label2.TabIndex = 0;
            label2.Text = "Employee Management System";
            label2.Click += label2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(625, 522);
            dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 522);
            Controls.Add(splitContainer1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel6.ResumeLayout(false);
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private SplitContainer splitContainer1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel8;
        private Button DeleteBtn;
        private FlowLayoutPanel flowLayoutPanel7;
        private Button Updatebtn;
        private Button SelectUpdatebtn;
        private FlowLayoutPanel flowLayoutPanel6;
        private Button AddNewbtn;
        private Button Submitbtn;
        private FlowLayoutPanel flowLayoutPanel5;
        private Label label6;
        private ComboBox comboBox1;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label5;
        private TextBox salarytxtbox;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label4;
        private TextBox Nametxtbox;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private TextBox IDtxtbox;
        private DataGridView dataGridView1;
    }
}
