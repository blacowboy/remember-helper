namespace remember_helper
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("仿宋_GB2312", 150F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(1384, 369);
            label1.TabIndex = 0;
            label1.Text = "1234";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.Font = new Font("楷体_GB2312", 30F);
            button1.Location = new Point(1498, 32);
            button1.Name = "button1";
            button1.Size = new Size(354, 91);
            button1.TabIndex = 1;
            button1.Text = "随机选择";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("楷体_GB2312", 30F);
            button2.Location = new Point(1498, 167);
            button2.Name = "button2";
            button2.Size = new Size(354, 91);
            button2.TabIndex = 2;
            button2.Text = "还不会的";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("楷体_GB2312", 30F);
            button3.Location = new Point(1498, 296);
            button3.Name = "button3";
            button3.Size = new Size(354, 91);
            button3.TabIndex = 3;
            button3.Text = "我背会啦";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1946, 426);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
