
namespace howto_hexagonal_grid
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x11ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x13ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x19ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameModesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizesToolStripMenuItem,
            this.gameModesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sizesToolStripMenuItem
            // 
            this.sizesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x11ToolStripMenuItem,
            this.x13ToolStripMenuItem,
            this.x19ToolStripMenuItem});
            this.sizesToolStripMenuItem.Name = "sizesToolStripMenuItem";
            this.sizesToolStripMenuItem.Size = new System.Drawing.Size(67, 29);
            this.sizesToolStripMenuItem.Text = "Sizes";
            // 
            // x11ToolStripMenuItem
            // 
            this.x11ToolStripMenuItem.Name = "x11ToolStripMenuItem";
            this.x11ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.x11ToolStripMenuItem.Text = "11x11";
            this.x11ToolStripMenuItem.Click += new System.EventHandler(this.x11ToolStripMenuItem_Click);
            // 
            // x13ToolStripMenuItem
            // 
            this.x13ToolStripMenuItem.Name = "x13ToolStripMenuItem";
            this.x13ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.x13ToolStripMenuItem.Text = "13x13";
            // 
            // x19ToolStripMenuItem
            // 
            this.x19ToolStripMenuItem.Name = "x19ToolStripMenuItem";
            this.x19ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.x19ToolStripMenuItem.Text = "19x19";
            // 
            // gameModesToolStripMenuItem
            // 
            this.gameModesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsAIToolStripMenuItem});
            this.gameModesToolStripMenuItem.Name = "gameModesToolStripMenuItem";
            this.gameModesToolStripMenuItem.Size = new System.Drawing.Size(134, 29);
            this.gameModesToolStripMenuItem.Text = "Game modes";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs Player";
            // 
            // playerVsAIToolStripMenuItem
            // 
            this.playerVsAIToolStripMenuItem.Name = "playerVsAIToolStripMenuItem";
            this.playerVsAIToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.playerVsAIToolStripMenuItem.Text = "Player vs AI";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sizesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x11ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x13ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x19ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameModesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerVsAIToolStripMenuItem;
    }
}