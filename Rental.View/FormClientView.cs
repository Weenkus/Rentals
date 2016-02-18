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
    public partial class FormClientView : Form
    {
        private IController _controller;
        private IPersonRepository _repo;

        public FormClientView(IController con, IPersonRepository r)
        {
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormClientView_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            IList<Client> pList = _repo.GetAllClients();
            foreach (Client p in pList)
            {
                ListViewItem listViewItemNew = new ListViewItem(Convert.ToString(p.Id));
                listViewItemNew.SubItems.Add(p.Name);
                listViewItemNew.SubItems.Add(p.LastName);

                String dedicatedAgent = "[" + Convert.ToString(p.Id) + "] " +  p.DedicatedAgent.Name + " " + p.DedicatedAgent.LastName;
                listViewItemNew.SubItems.Add(dedicatedAgent);

                listView1.Items.Add(listViewItemNew);
            }
        }
    }
}
