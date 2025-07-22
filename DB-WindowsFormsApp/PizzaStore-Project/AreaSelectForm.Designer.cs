namespace PizzaStore_Project
{
    partial class AreaSelectForm
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
            this.Delivery_RBtn = new System.Windows.Forms.RadioButton();
            this.Pickup_RBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderType_panel = new System.Windows.Forms.Panel();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Delivery_RBtn
            // 
            this.Delivery_RBtn.AutoSize = true;
            this.Delivery_RBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Delivery_RBtn.Font = new System.Drawing.Font("Sitka Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delivery_RBtn.ForeColor = System.Drawing.Color.White;
            this.Delivery_RBtn.Location = new System.Drawing.Point(240, 133);
            this.Delivery_RBtn.Name = "Delivery_RBtn";
            this.Delivery_RBtn.Size = new System.Drawing.Size(229, 56);
            this.Delivery_RBtn.TabIndex = 0;
            this.Delivery_RBtn.Text = "DELIVERY";
            this.Delivery_RBtn.UseVisualStyleBackColor = false;
            this.Delivery_RBtn.CheckedChanged += new System.EventHandler(this.Delivery_RBtn_CheckedChanged);
            // 
            // Pickup_RBtn
            // 
            this.Pickup_RBtn.AutoSize = true;
            this.Pickup_RBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Pickup_RBtn.Font = new System.Drawing.Font("Sitka Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pickup_RBtn.ForeColor = System.Drawing.Color.White;
            this.Pickup_RBtn.Location = new System.Drawing.Point(551, 133);
            this.Pickup_RBtn.Name = "Pickup_RBtn";
            this.Pickup_RBtn.Size = new System.Drawing.Size(193, 56);
            this.Pickup_RBtn.TabIndex = 1;
            this.Pickup_RBtn.Text = "PICK UP";
            this.Pickup_RBtn.UseVisualStyleBackColor = false;
            this.Pickup_RBtn.CheckedChanged += new System.EventHandler(this.Pickup_RBtn_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(363, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Order Type";
            // 
            // OrderType_panel
            // 
            this.OrderType_panel.Location = new System.Drawing.Point(240, 238);
            this.OrderType_panel.Name = "OrderType_panel";
            this.OrderType_panel.Size = new System.Drawing.Size(537, 269);
            this.OrderType_panel.TabIndex = 3;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Font = new System.Drawing.Font("Sitka Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.ForeColor = System.Drawing.Color.Fuchsia;
            this.ConfirmBtn.Location = new System.Drawing.Point(408, 542);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(185, 57);
            this.ConfirmBtn.TabIndex = 4;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // AreaSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 627);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.OrderType_panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pickup_RBtn);
            this.Controls.Add(this.Delivery_RBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AreaSelectForm";
            this.Text = "AreaSelectForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton Delivery_RBtn;
        public System.Windows.Forms.RadioButton Pickup_RBtn;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel OrderType_panel;
        public System.Windows.Forms.Button ConfirmBtn;
    }
}