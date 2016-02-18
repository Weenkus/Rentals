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
    public partial class FormEmployeeEdit : Form
    {
        private IController _controller;
        private IPersonRepository _repo;

        public FormEmployeeEdit(IController con, IPersonRepository p)
        {
            _repo = p;
            _controller = con;
            InitializeComponent();
        }

        private void FormEmployeeEdit_Load(object sender, EventArgs e)
        {
            // Agents
            IList<Employee> eList = _repo.GetAllEmpoyees();
            Dictionary<Employee, string> hashMap = new Dictionary<Employee, string>();
            foreach (Employee em in eList)
            {
                String present = "[" + em.Id + "] " + em.ToString();
                hashMap.Add(em, present);
            }
            cbEmployees.DataSource = new BindingSource(hashMap, null);
            cbEmployees.DisplayMember = "Value";
            cbEmployees.ValueMember = "Key";

        }


        private void btEdit_Click(object sender, EventArgs e)
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
                    // Fatch the original client and edit it, then save
                    Employee selectedClient = (Employee)_repo.Get(((KeyValuePair<Employee, string>)cbEmployees.SelectedItem).Key);
                    selectedClient.Name = tbName.Text;
                    selectedClient.LastName = tbSurname.Text;

                    _repo.Update(selectedClient);
                    this.Close();
                }
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            Employee selectedEmployee = (Employee)_repo.Get(((KeyValuePair<Employee, string>)cbEmployees.SelectedItem).Key);
            _repo.Remove(selectedEmployee);
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update all the data
            Employee selectedEmployee = ((KeyValuePair<Employee, string>)cbEmployees.SelectedItem).Key;
            tbName.Text = selectedEmployee.Name;
            tbSurname.Text = selectedEmployee.LastName;
        }
    }
}
