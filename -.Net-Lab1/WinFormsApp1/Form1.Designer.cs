namespace WinFormsApp1
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
            seed_box = new TextBox();
            label2 = new Label();
            capacity = new TextBox();
            label3 = new Label();
            button1 = new Button();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            number_of_items = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 1;
            label1.Text = "Number of items";
            label1.Click += label1_Click;
            // 
            // seed_box
            // 
            seed_box.Location = new Point(26, 106);
            seed_box.Name = "seed_box";
            seed_box.Size = new Size(125, 27);
            seed_box.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 83);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 3;
            label2.Text = "seed";
            // 
            // capacity
            // 
            capacity.Location = new Point(26, 171);
            capacity.Name = "capacity";
            capacity.Size = new Size(125, 27);
            capacity.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 148);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 5;
            label3.Text = "capacity";
            // 
            // button1
            // 
            button1.Location = new Point(45, 214);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.Location = new Point(26, 262);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(395, 144);
            listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.HorizontalScrollbar = true;
            listBox2.Location = new Point(440, 19);
            listBox2.Name = "listBox2";
            listBox2.ScrollAlwaysVisible = true;
            listBox2.Size = new Size(339, 324);
            listBox2.TabIndex = 8;
            // 
            // number_of_items
            // 
            number_of_items.Location = new Point(26, 42);
            number_of_items.Name = "number_of_items";
            number_of_items.Size = new Size(125, 27);
            number_of_items.TabIndex = 9;
            number_of_items.TextChanged += number_of_items_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(number_of_items);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(capacity);
            Controls.Add(label2);
            Controls.Add(seed_box);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // private TextBox items;
        private Label label1;
        private TextBox seed_box;
        private Label label2;
        private TextBox capacity;
        private Label label3;
        private Button button1;
        private ListBox listBox1;
        private ListBox listBox2;
        private TextBox number_of_items;
    }
}
