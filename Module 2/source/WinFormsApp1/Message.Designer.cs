namespace WinFormsApp1
{
    partial class Message
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
            this.helloLabel = new System.Windows.Forms.Label();
            this.messageCloseBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Location = new System.Drawing.Point(12, 9);
            this.helloLabel.MaximumSize = new System.Drawing.Size(260, 40);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(35, 15);
            this.helloLabel.TabIndex = 0;
            this.helloLabel.Text = "Hello";
            // 
            // messageCloseBtn
            // 
            this.messageCloseBtn.Location = new System.Drawing.Point(100, 76);
            this.messageCloseBtn.Name = "messageCloseBtn";
            this.messageCloseBtn.Size = new System.Drawing.Size(84, 23);
            this.messageCloseBtn.TabIndex = 1;
            this.messageCloseBtn.Text = "Hi, program";
            this.messageCloseBtn.UseVisualStyleBackColor = true;
            this.messageCloseBtn.Click += new System.EventHandler(this.messageCloseBtn_Click);
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.ControlBox = false;
            this.Controls.Add(this.messageCloseBtn);
            this.Controls.Add(this.helloLabel);
            this.MaximumSize = new System.Drawing.Size(300, 150);
            this.Name = "Message";
            this.Text = "Message";
            this.Load += new System.EventHandler(this.Message_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label helloLabel;
        private Button messageCloseBtn;
    }
}