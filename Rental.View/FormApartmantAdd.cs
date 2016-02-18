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
    public partial class FormApartmantAdd : Form
    {
        private IController _controller;
        private IPersonRepository _repo;
        private IRentalRepository _rentalRepo;

        private IList<RentalInclude> _includes = new List<RentalInclude>();
        private IList<SpecialFeatures> _specials = new List<SpecialFeatures>();

        public FormApartmantAdd(IController con, IPersonRepository p, IRentalRepository r)
        {
            _rentalRepo = r;
            _repo = p;
            _controller = con;
            InitializeComponent();
        }

        private void FormApartmantAdd_Load(object sender, EventArgs e)
        {
            // Load all clients as possible owners
            IList<Client> clientList = _repo.GetAllClients();
            Dictionary<Client, string> clientMap = new Dictionary<Client, string>();
            foreach (Client c in clientList)
            {
                String present = "[" + c.Id + "] " + c.ToString();
                clientMap.Add(c, present);
            }
            cbOwner.DataSource = new BindingSource(clientMap, null);
            cbOwner.DisplayMember = "Value";
            cbOwner.ValueMember = "Key";

            // Load offers
            var values = Enum.GetValues(typeof(Offer));
            Dictionary<Offer, string> offerMap = new Dictionary<Offer, string>();
            foreach (Offer o in values)
            {
                offerMap.Add(o, o.ToString());
            }
            cbOffer.DataSource = new BindingSource(offerMap, null);
            cbOffer.DisplayMember = "Value";
            cbOffer.ValueMember = "Key";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check for includes or specials
            if(_includes.Count == 0 || _specials.Count == 0)
            {
                DialogResult result = MessageBox.Show("If you add a aprtmant without include or special features it is less like that it will be rented.\nAre you sure you want to continue?"
                    , "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    addApartmant();
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                addApartmant();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddIncludes_Click(object sender, EventArgs e)
        {
            // Check if all fields were filled
            if (String.IsNullOrWhiteSpace(tbNumer.Text))
            {
                MessageBox.Show("You must add a number for the offer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Store the new client and close the form (if the inputs are correct)
            else
            {
                if (!tbDailyPrice.Text.All(char.IsDigit))
                    MessageBox.Show("The numbeer should have only digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    RentalInclude newInclude = new RentalInclude(((KeyValuePair<Offer, string>)cbOffer.SelectedItem).Key, Convert.ToInt32(tbNumer.Text));
                    _includes.Add(newInclude);

                    // Add to list view
                    ListViewItem listViewItemNew = new ListViewItem(Convert.ToString(newInclude.Number));
                    listViewItemNew.SubItems.Add(newInclude.Offer.ToString());
                    listViewIncludes.Items.Add(listViewItemNew);
                }
            }
        }

        private void btnAddSpecials_Click(object sender, EventArgs e)
        {
            // Check if all fields were filled
            if (String.IsNullOrWhiteSpace(tbPriceSPecial.Text)
                && String.IsNullOrWhiteSpace(tbDescriptionSpecial.Text))
            {
                MessageBox.Show("You must fill all fields to add a special feature.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Store the new client and close the form (if the inputs are correct)
            else
            {
                if (tbDescriptionSpecial.Text.Any(char.IsDigit) || !tbPriceSPecial.Text.All(char.IsDigit))
                    MessageBox.Show("Price must only have digits while the description should have digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    SpecialFeatures newSpecial = new SpecialFeatures(Convert.ToInt32(tbPriceSPecial.Text), tbDescriptionSpecial.Text);
                    _specials.Add(newSpecial);

                    // Add to list view
                    ListViewItem listViewItemNew = new ListViewItem(newSpecial.Description);
                    listViewItemNew.SubItems.Add(newSpecial.Price.ToString());
                    listViewSpecials.Items.Add(listViewItemNew);
                }
            }
        }

        private void addApartmant()
        {
            // Check if other features are ok
            if (String.IsNullOrWhiteSpace(tbDescription.Text)
                && String.IsNullOrWhiteSpace(tbName.Text)
                && String.IsNullOrWhiteSpace(tbDailyPrice.Text)
                && String.IsNullOrWhiteSpace(tbAddress.Text)
                && String.IsNullOrWhiteSpace(tbPostal.Text))
            {
                MessageBox.Show("You must fill all fields to add a new apartmant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Check if the fields are inputed correctly
                if (tbName.Text.Contains(" ") || tbName.Text.Any(char.IsDigit) ||
                    tbDescription.Text.Any(char.IsDigit) ||
                    !tbDailyPrice.Text.All(char.IsDigit) ||
                    tbAddress.Text.Contains(" ") || tbAddress.Text.Any(char.IsDigit) ||
                    tbPostal.Text.Contains(" ") || !tbPostal.Text.All(char.IsDigit))
                    MessageBox.Show("Name and surname must be space and digit free.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Apartment newApartment = ApartmanFactory.createApartman(((KeyValuePair<Client, string>)cbOwner.SelectedItem).Key,
                        tbName.Text, tbDescription.Text, tbPostal.Text, tbAddress.Text,
                        Convert.ToInt32(tbDailyPrice.Text), _includes, _specials);
                    _rentalRepo.Add(newApartment);
                    _controller.ShowApartmants();
                    this.Close();
                }
            }
        }

    }
}
