namespace Maintenance
{
    partial class TitleForm
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
            this.okΒutton = new System.Windows.Forms.Button();
            this.cancelΒutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okΒutton
            // 
            this.okΒutton.Location = new System.Drawing.Point(219, 39);
            this.okΒutton.Name = "okΒutton";
            this.okΒutton.Size = new System.Drawing.Size(75, 23);
            this.okΒutton.TabIndex = 0;
            this.okΒutton.Text = "OK";
            this.okΒutton.UseVisualStyleBackColor = true;
            this.okΒutton.Click += new System.EventHandler(this.okΒutton_Click);
            // 
            // cancelΒutton
            // 
            this.cancelΒutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelΒutton.Location = new System.Drawing.Point(13, 39);
            this.cancelΒutton.Name = "cancelΒutton";
            this.cancelΒutton.Size = new System.Drawing.Size(75, 23);
            this.cancelΒutton.TabIndex = 1;
            this.cancelΒutton.Text = "Cancel";
            this.cancelΒutton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 20);
            this.textBox1.TabIndex = 2;
            // 
            // TitleForm
            // 
            this.AcceptButton = this.okΒutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelΒutton;
            this.ClientSize = new System.Drawing.Size(305, 75);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cancelΒutton);
            this.Controls.Add(this.okΒutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TitleForm";
            this.Text = "TitleForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okΒutton;
        private System.Windows.Forms.Button cancelΒutton;
        private System.Windows.Forms.TextBox textBox1;
    }
}