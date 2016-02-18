using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class AppController : IController
    {
        public void ShowEmplyoees()
        {
            FormEmployeeView f = new FormEmployeeView(this, PersonRepository.Instance);
            f.ShowDialog();
        }

        public void ShowClients()
        {
            FormClientView f = new FormClientView(this, PersonRepository.Instance);
            f.ShowDialog();
        }

        public void ShowApartmants()
        {
            FormApartmantView f = new FormApartmantView(this, RentalRepository.Instance);
            f.ShowDialog();
        }

        public void ShowTransactions()
        {
            FormTransactionsView f = new FormTransactionsView(this, RentalInfoRepository.Instance);
            f.ShowDialog();
        }

        public void AddClient()
        {
            FormClientAdd f = new FormClientAdd(this, PersonRepository.Instance);
            f.ShowDialog();
        }

        public void AddEmployee()
        {
            FormEmployeeAdd f = new FormEmployeeAdd(this, PersonRepository.Instance);
            f.ShowDialog();
        }

        public void AddTransactions()
        {
            FormTranscationsAdd f = new FormTranscationsAdd(this, RentalRepository.Instance, RentalInfoRepository.Instance);
            f.ShowDialog();
        }

        public void EditClient()
        {
            FormClientEdit f = new FormClientEdit(this, PersonRepository.Instance, RentalRepository.Instance);
            f.ShowDialog();
        }

        public void EditEmployee()
        {
            FormEmployeeEdit f = new FormEmployeeEdit(this, PersonRepository.Instance);
            f.ShowDialog();
        }

        public void AddApartment()
        {
            FormApartmantAdd f = new FormApartmantAdd(this, PersonRepository.Instance, RentalRepository.Instance);
            f.ShowDialog();
        }
    }
}
