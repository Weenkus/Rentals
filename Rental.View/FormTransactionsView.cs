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
    public partial class FormTransactionsView : Form
    {
        private IController _controller;
        private IRentalInfoRepository _repo;

        public FormTransactionsView(IController con, IRentalInfoRepository r)
        {
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormTransactionsView_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            IList<RentalInformation> riList = _repo.GetAll();
            foreach (RentalInformation t in riList)
            {
                ListViewItem listViewItemNew = new ListViewItem(Convert.ToString(t.Id));
                listViewItemNew.SubItems.Add(t.Rented.Owner.ToString());
                listViewItemNew.SubItems.Add(t.Rented.Name.ToString());
                listViewItemNew.SubItems.Add(t.Start.ToLongDateString());
                listViewItemNew.SubItems.Add(t.End.ToLongDateString());
                listViewItemNew.SubItems.Add(t.DailyCost.ToString());

                listView1.Items.Add(listViewItemNew);
            }
        }
    }
}
