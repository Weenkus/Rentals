using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class Client : Person
    {
        private Employee _dedicatedAgent;

        public Client() { }

        public Client(String name, String lastName, Employee emp)
        {
            this.Name = name;
            this.LastName = lastName;
            this._dedicatedAgent = emp;
            emp.AdvisingClients.Add(this);
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Client;
            if (toCompareWith == null)
                return false;
            return this.Id == toCompareWith.Id
                && this.Name == toCompareWith.Name
                && this.LastName == toCompareWith.LastName
                && this.DedicatedAgent.Equals(toCompareWith.DedicatedAgent);
        }

        public virtual Employee DedicatedAgent
        {
            get
            {
                return _dedicatedAgent;
            }

            set
            {
                _dedicatedAgent = value;
            }
        }
    }
}
