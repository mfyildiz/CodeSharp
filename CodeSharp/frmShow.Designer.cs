namespace CodeSharp
{
    partial class frmShow
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
            this.rtxthor = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxthor
            // 
            this.rtxthor.BackColor = System.Drawing.Color.DarkSlateGray;
            this.rtxthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxthor.CausesValidation = false;
            this.rtxthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxthor.Location = new System.Drawing.Point(0, 0);
            this.rtxthor.Name = "rtxthor";
            this.rtxthor.ReadOnly = true;
            this.rtxthor.Size = new System.Drawing.Size(492, 455);
            this.rtxthor.TabIndex = 0;
            this.rtxthor.Text = "";
            // 
            // frmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 455);
            this.ControlBox = false;
            this.Controls.Add(this.rtxthor);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxthor;
    }
}