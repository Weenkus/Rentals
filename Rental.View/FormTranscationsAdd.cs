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
    public partial class FormTranscationsAdd : Form
    {
        private IController _controller;
        private IRentalRepository _repo;
        private IRentalInfoRepository _transactionRepo;

        public FormTranscationsAdd(IController con, IRentalRepository r, IRentalInfoRepository t)
        {
            _transactionRepo = t;
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormTranscationsAdd_Load(object sender, EventArgs e)
        {
            IList<Rental> rList = _repo.GetAll();
            Dictionary<Rental, string> rentalMap = new Dictionary<Rental, string>();
            foreach (Rental r in rList)
            {
                String present = "[" + r.Id + "] " + r.Name.ToString() + " (" + r.DailyPrice.ToString() + "€)";
                rentalMap.Add(r, present);
            }
            cbRentals.DataSource = new BindingSource(rentalMap, null);
            cbRentals.DisplayMember = "Value";
            cbRentals.ValueMember = "Key";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if the To date is later than From
            int result = DateTime.Compare(dtpFrom.Value.Date, dtpTo.Value.Date);
            if (result >= 0)
            {
                MessageBox.Show("Date from must be before the date to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Store the new client and close the form (if the inputs are correct)
            else
            {
                // Check if for the choosen period the apartmant is not rented
                IList<RentalInformation> transactions = _transactionRepo.GetAll();
                bool addTransaction = true;
                foreach(RentalInformation t in transactions)
                {
                    int cmp1 = DateTime.Compare(dtpFrom.Value.Date, t.End.Date);
                    int cmp2 = DateTime.Compare(dtpTo.Value.Date, t.Start.Date);
                    // Check with the transactions of the SELECTED RENTAL (apartmant)
                    if ((cmp1 < 0 && cmp2 > 0) && ((KeyValuePair<Rental, string>)cbRentals.SelectedItem).Key.Id == t.Rented.Id)
                    {
                        MessageBox.Show("The choosen apartmant is already rented for that period.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _controller.ShowTransactions();
                        addTransaction = false;
                        break;
                    }
                }

                // The transactions is valid
                if(addTransaction)
                {
                    RentalInformation newTransaction = new RentalInformation(((KeyValuePair<Rental, string>)cbRentals.SelectedItem).Key,
                        dtpFrom.Value, dtpTo.Value, ((KeyValuePair<Rental, string>)cbRentals.SelectedItem).Key.DailyPrice);
                    _transactionRepo.Add(newTransaction);
                    _controller.ShowTransactions();
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
