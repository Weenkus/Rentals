using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rental
{
    public class Person
    {
        private int _id;
        private String _name;
        private String _lastName;

        public override string ToString()
        {
            return Name + " " + LastName;
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Person;
            if (toCompareWith == null)
                return false;
            return this.Id == toCompareWith.Id
                && this.Name == toCompareWith.Name
                && this.LastName == toCompareWith.LastName;
        }

        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

    }
}
