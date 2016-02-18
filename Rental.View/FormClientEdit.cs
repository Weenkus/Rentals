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
    public partial class FormClientEdit : Form
    {
        private IController _controller;
        private IPersonRepository _repo;
        private IRentalRepository _rentalRepo;

        public FormClientEdit(IController con, IPersonRepository p, IRentalRepository r)
        {
            _repo = p;
            _rentalRepo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormClientAdd_Load(object sender, EventArgs e)
        {
            // Agents
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


            // Clients
            IList<Client> cList = _repo.GetAllClients();
            Dictionary<Client, string> clientMap = new Dictionary<Client, string>();
            for(int i = 0; i < cList.Count; ++i)
            {
                Client c = cList[i];
                // Set a proper agent for the client
                if(i == 0)
                    cbAgents.SelectedItem = clientMap.SingleOrDefault(p => p.Key.Id == c.Id);

                String present = "[" + c.Id + "] " + c.ToString();
                clientMap.Add(c, present);
            }
            cbClients.DataSource = new BindingSource(clientMap, null);
            cbClients.DisplayMember = "Value";
            cbClients.ValueMember = "Key";
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            // Check if all fields were filled
            if (String.IsNullOrWhiteSpace(tbName.Text)
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
                    // Fatch the original client and edit it, then save
                    Client selectedClient = (Client)_repo.Get(((KeyValuePair<Client, string>)cbClients.SelectedItem).Key);
                    selectedClient.Name = tbName.Text;
                    selectedClient.LastName = tbSurname.Text;
                    selectedClient.DedicatedAgent = ((KeyValuePair<Employee, string>)cbAgents.SelectedItem).Key;

                    _repo.Update(selectedClient);
                    this.Close();
                }
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            Client selectedClient = (Client)_repo.Get(((KeyValuePair<Client, string>)cbClients.SelectedItem).Key);


            // Check if there were any rentals in the client possession
            IList<Rental> rList = _rentalRepo.GetAll();
            bool hasREntals = false;
            foreach (Rental r in rList)
            {
                if (r.Owner.Id == selectedClient.Id)
                    hasREntals = true;
            }

            // The Client has rentals, ask the user for action
            if (hasREntals)
            {             
                DialogResult result = MessageBox.Show("The client owns rentals, removing the client will remove them as well. Are you sure you want to continue?"
                    , "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    // Remove all rentals that the client owned
                    IList<Rental> rentals = _rentalRepo.GetAll();
                    bool removed = false;
                    String apartmantNames = "";
                    foreach (Rental r in rentals)
                    {
                        if (r.Owner.Id == selectedClient.Id)
                        {
                            _rentalRepo.Remove(r);
                            removed = true;
                            apartmantNames += r.Name + "\n ";
                        }
                    }

                    if (removed)
                        MessageBox.Show("The client had apartmants in the system, they were all deleted together with the client.\nRemoved apartmats:\n\n" + apartmantNames,
                            "Apartmants", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _repo.Remove(selectedClient);
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    //...
                }
            } else
            {
                // The client doesn't have any apartmants remove him
                _repo.Remove(selectedClient);
                this.Close();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update all the data
            Client selectedCLient = ((KeyValuePair<Client, string>)cbClients.SelectedItem).Key;
            tbName.Text = selectedCLient.Name;
            tbSurname.Text = selectedCLient.LastName;

            String present = "[" + selectedCLient.DedicatedAgent.Id + "] " + selectedCLient.DedicatedAgent.ToString();
            cbAgents.SelectedItem = new KeyValuePair<Employee, string>(selectedCLient.DedicatedAgent, present);
        }
    }
}
