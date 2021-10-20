using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HexBlock;

namespace howto_hexagonal_grid
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void x11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 v2 = new Form1(new Board(11));
            Hide();
            v2.ShowDialog();
        }
    }
}
