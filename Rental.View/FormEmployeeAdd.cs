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
    public partial class FormEmployeeAdd : Form
    {
        private IController _controller;
        private IPersonRepository _repo;

        public FormEmployeeAdd(IController con, IPersonRepository r)
        {
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Check if all fields were filled
            if (String.IsNullOrWhiteSpace(tbName.Text)
                && String.IsNullOrWhiteSpace(tbSurname.Text))
            {
                MessageBox.Show("You must fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Store the new client and close the form (if the inputs are correct)
            else
            {
                if (tbName.Text.Contains(" ") || tbName.Text.Any(char.IsDigit) ||
                    tbSurname.Text.Contains(" ") || tbSurname.Text.Any(char.IsDigit))
                    MessageBox.Show("Name and surname must be space and digit free.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Employee newEmployee = new Employee(tbName.Text, tbSurname.Text);
                    _repo.Add(newEmployee);
                    _controller.ShowEmplyoees();
                    this.Close();
                }
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
