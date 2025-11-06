namespace WinFormsAppDemo
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
            btnClickThis = new Button();
            lblHelloWorld = new Label();
            empty1 = new Label();
            NameHolder = new TextBox();
            SuspendLayout();
            // 
            // btnClickThis
            // 
            btnClickThis.BackColor = Color.Red;
            btnClickThis.Location = new Point(497, 265);
            btnClickThis.Name = "btnClickThis";
            btnClickThis.Size = new Size(102, 34);
            btnClickThis.TabIndex = 0;
            btnClickThis.Text = "Click Me Please!";
            btnClickThis.UseVisualStyleBackColor = false;
            btnClickThis.Click += button1_Click;
            // 
            // lblHelloWorld
            // 
            lblHelloWorld.AutoSize = true;
            lblHelloWorld.Location = new Point(376, 239);
            lblHelloWorld.Name = "lblHelloWorld";
            lblHelloWorld.Size = new Size(100, 15);
            lblHelloWorld.TabIndex = 2;
            lblHelloWorld.Text = "Type Your Name: ";
            lblHelloWorld.Click += label1_Click;
            // 
            // empty1
            // 
            empty1.AutoSize = true;
            empty1.BackColor = SystemColors.ControlDarkDark;
            empty1.Font = new Font("Viner Hand ITC", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            empty1.ForeColor = SystemColors.ControlText;
            empty1.Location = new Point(206, 335);
            empty1.Name = "empty1";
            empty1.Size = new Size(651, 78);
            empty1.TabIndex = 3;
            empty1.Text = "Your Name will Print here";
            empty1.Click += label1_Click_1;
            // 
            // NameHolder
            // 
            NameHolder.Location = new Point(482, 236);
            NameHolder.Name = "NameHolder";
            NameHolder.Size = new Size(168, 23);
            NameHolder.TabIndex = 4;
            NameHolder.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 618);
            Controls.Add(NameHolder);
            Controls.Add(empty1);
            Controls.Add(lblHelloWorld);
            Controls.Add(btnClickThis);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClickThis;
        private Label lblHelloWorld;
        private Label empty1;
        private TextBox NameHolder;
    }
}
