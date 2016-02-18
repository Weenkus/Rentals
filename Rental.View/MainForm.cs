using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{
    public partial class MainForm : Form
    {
        private IController _controller;

        public MainForm(IController con)
        {
            _controller = con;
            InitializeComponent();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ShowEmplyoees();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _controller.ShowClients();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _controller.ShowApartmants();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _controller.AddClient();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.AddEmployee();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _controller.EditClient();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.EditEmployee();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _controller.AddApartment();
        }

        private void viewToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _controller.ShowTransactions();
        }

        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _controller.AddTransactions();
        }
    }
}
