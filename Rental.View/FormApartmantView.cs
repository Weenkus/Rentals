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
    public partial class FormApartmantView : Form
    {
        private IController _controller;
        private IRentalRepository _repo;

        public FormApartmantView(IController con, IRentalRepository r)
        {
            _repo = r;
            _controller = con;
            InitializeComponent();
        }

        private void FormApartmantView_Load(object sender, EventArgs e)
        {
            FillApartmants(null);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FillApartmants(tbSearch.Text);
        }

        private void FillApartmants(String filter)
        {
            listView1.Items.Clear();

            IList<Apartment> rList = _repo.GetAllApartmants();
            foreach (Apartment p in rList)
            {
                if(filter != null)
                {
                    if (!p.Name.ToLower().Contains(filter.ToLower()))
                        continue;
                }

                ListViewItem listViewItemNew = new ListViewItem(Convert.ToString(p.Id));
                listViewItemNew.SubItems.Add(p.Name);
                listViewItemNew.SubItems.Add(p.Description);

                String owner = "[" + Convert.ToString(p.Owner.Id) + "] " + p.Owner.Name + " " + p.Owner.LastName;
                listViewItemNew.SubItems.Add(owner);

                listViewItemNew.SubItems.Add(p.PostalCode);
                listViewItemNew.SubItems.Add(p.Address);
                listViewItemNew.SubItems.Add(Convert.ToString(p.DailyPrice));

                // Concat all incldudes
                String includes = "";
                for (int i = 0; i < p.IncludedFeatures.Count; ++i)
                {
                    if (i == p.IncludedFeatures.Count - 1)
                        includes += p.IncludedFeatures[i].ToString();
                    else
                        includes += p.IncludedFeatures[i].ToString() + ", ";
                }
                listViewItemNew.SubItems.Add(includes);

                // Concat all payed features
                String payed = "";
                for (int i = 0; i < p.PayedFeatures.Count; ++i)
                {
                    if (i == p.PayedFeatures.Count - 1)
                        payed += p.PayedFeatures[i].ToString();
                    else
                        payed += p.PayedFeatures[i].ToString() + ", ";
                }
                listViewItemNew.SubItems.Add(payed);


                listView1.Items.Add(listViewItemNew);
            }
        }
    }
}
