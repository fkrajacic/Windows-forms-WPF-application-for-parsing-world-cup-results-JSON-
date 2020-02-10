namespace WinFormsTest
{
    partial class Form_Lang
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnEngleski = new System.Windows.Forms.Button();
            this.btnHrvatski = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberite jezik";
            // 
            // btnEngleski
            // 
            this.btnEngleski.Location = new System.Drawing.Point(57, 99);
            this.btnEngleski.Name = "btnEngleski";
            this.btnEngleski.Size = new System.Drawing.Size(88, 30);
            this.btnEngleski.TabIndex = 3;
            this.btnEngleski.Text = "Engleski";
            this.btnEngleski.UseVisualStyleBackColor = true;
            this.btnEngleski.Click += new System.EventHandler(this.btnEngleski_Click);
            // 
            // btnHrvatski
            // 
            this.btnHrvatski.Location = new System.Drawing.Point(209, 103);
            this.btnHrvatski.Name = "btnHrvatski";
            this.btnHrvatski.Size = new System.Drawing.Size(75, 23);
            this.btnHrvatski.TabIndex = 4;
            this.btnHrvatski.Text = "Hrvatski";
            this.btnHrvatski.UseVisualStyleBackColor = true;
            this.btnHrvatski.Click += new System.EventHandler(this.btnHrvatski_Click);
            // 
            // Form_Lang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 184);
            this.Controls.Add(this.btnHrvatski);
            this.Controls.Add(this.btnEngleski);
            this.Controls.Add(this.label1);
            this.Name = "Form_Lang";
            this.Text = "Form_Lang";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEngleski;
        private System.Windows.Forms.Button btnHrvatski;
    }
}