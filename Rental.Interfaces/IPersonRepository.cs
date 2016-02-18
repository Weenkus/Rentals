using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public interface IPersonRepository
    {

        int Count();

        Person Get(int id);

        Person Get(Person person);

        Person GetByIndex(int index);

        IList<Person> GetAll();

        IList<Employee> GetAllEmpoyees();

        IList<Client> GetAllClients();

        void Add(Person person);

        void Remove(int id);

        void Remove(Person person);

        void Clear();

        bool Contains(Person person);

        void Update(Person person);
    }
}
