using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexBlock
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private int size = 11;
        private HexBlock.Difficulty difficulty = Difficulty.NULL;
        private bool solo;

        private void x11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            size = 11;
        }

        private void x13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            size = 13;
        }

        private void x19ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            size = 19;
        }

        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solo = false;
        }

        private void playerVsAIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solo = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var game = new Form1(new Board(size, solo, difficulty));
            Hide();
            game.ShowDialog();
        }
    }
}
