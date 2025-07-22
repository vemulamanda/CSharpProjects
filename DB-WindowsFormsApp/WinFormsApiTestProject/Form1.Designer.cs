namespace WinFormsApiTestProject
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
            MainApiDataTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // MainApiDataTextBox
            // 
            MainApiDataTextBox.Location = new Point(93, 33);
            MainApiDataTextBox.Multiline = true;
            MainApiDataTextBox.Name = "MainApiDataTextBox";
            MainApiDataTextBox.ScrollBars = ScrollBars.Horizontal;
            MainApiDataTextBox.Size = new Size(640, 353);
            MainApiDataTextBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(845, 180);
            button1.Name = "button1";
            button1.Size = new Size(164, 65);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 530);
            Controls.Add(button1);
            Controls.Add(MainApiDataTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MainApiDataTextBox;
        private Button button1;
    }
}
