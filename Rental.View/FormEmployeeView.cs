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
    public partial class FormEmployeeView : Form
    {
        private IController _controller;
        private IPersonRepository _repo;

        public FormEmployeeView(IController con, IPersonRepository r)
        {
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormEmployeeView_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            IList<Employee> pList = _repo.GetAllEmpoyees();
            foreach (Employee p in pList)
            {
                ListViewItem listViewItemNew = new ListViewItem(Convert.ToString(p.Id));
                listViewItemNew.SubItems.Add(p.Name);
                listViewItemNew.SubItems.Add(p.LastName);


                // Make a string of clients
                String clients = "";
                for(int i = 0; i < p.AdvisingClients.Count; ++i)
                {
                    Client c = p.AdvisingClients[i];
                    if (i == p.AdvisingClients.Count - 1)
                        clients += "[" + Convert.ToString(c.Id) + "] " + c.Name + " " + c.LastName;
                    else
                        clients += "[" + Convert.ToString(c.Id) + "] " + c.Name + " " + c.LastName + ", ";
                }

                listViewItemNew.SubItems.Add(clients);
                listView1.Items.Add(listViewItemNew);
            }
        }
    }
}
