
namespace TicTacTocGame
{
    partial class Form1
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
            this.TicTacPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TicTacPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TicTacPictureBox
            // 
            this.TicTacPictureBox.Location = new System.Drawing.Point(9, 4);
            this.TicTacPictureBox.Name = "TicTacPictureBox";
            this.TicTacPictureBox.Size = new System.Drawing.Size(450, 450);
            this.TicTacPictureBox.TabIndex = 0;
            this.TicTacPictureBox.TabStop = false;
            this.TicTacPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.TicTacPictureBox_Paint);
            this.TicTacPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TicTacPictureBox_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 462);
            this.Controls.Add(this.TicTacPictureBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TicTacPictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.PictureBox TicTacPictureBox;
        #endregion
    }
}

