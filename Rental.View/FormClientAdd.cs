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
    public partial class FormClientAdd : Form
    {
        private IController _controller;
        private IPersonRepository _repo;

        public FormClientAdd(IController con, IPersonRepository r)
        {
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormClientAdd_Load(object sender, EventArgs e)
        {
            IList<Employee> eList = _repo.GetAllEmpoyees();
            Dictionary<Employee, string> hashMap = new Dictionary<Employee, string>();
            foreach (Employee em in eList)
            {
                String present = "[" + em.Id + "] " + em.ToString();
                hashMap.Add(em, present);
            }
            cbAgents.DataSource = new BindingSource(hashMap, null);
            cbAgents.DisplayMember = "Value";
            cbAgents.ValueMember = "Key";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if all fields were filled
            if(String.IsNullOrWhiteSpace(tbName.Text) 
                && String.IsNullOrWhiteSpace(tbSurname.Text)
                && String.IsNullOrWhiteSpace(cbAgents.Text))
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
                    Employee dedicatedAgent = ((KeyValuePair<Employee, string>)cbAgents.SelectedItem).Key;
                    Client newClient = new Client(tbName.Text, tbSurname.Text, dedicatedAgent);
                    _repo.Add(newClient);
                    _controller.ShowClients();
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
