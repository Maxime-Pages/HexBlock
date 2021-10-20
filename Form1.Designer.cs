using System.Windows.Forms;

namespace howto_hexagonal_grid
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
            this.picGrid = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // picGrid
            // 
            this.picGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picGrid.BackColor = System.Drawing.Color.White;
            this.picGrid.Location = new System.Drawing.Point(13, 14);
            this.picGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picGrid.Name = "picGrid";
            this.picGrid.Size = new System.Drawing.Size(390, 365);
            this.picGrid.TabIndex = 1;
            this.picGrid.TabStop = false;
            this.picGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.picGrid_Paint);
            this.picGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseClick);
            this.picGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGrid_MouseMove);
            this.picGrid.Resize += new System.EventHandler(this.picGrid_Resize);
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 402);
            this.Controls.Add(this.picGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "howto_hexagonal_grid";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGrid;
    }
}

