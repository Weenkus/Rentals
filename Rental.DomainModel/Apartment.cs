using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class Apartment : Rental
    {
        private IList<SpecialFeatures> _payedFeatures;
        private IList<RentalInclude> _includedFeatures;
        private String _postalCode;
        private String _address;

        public Apartment() { }

        public Apartment(Client owner, String name, String description, String postal,
            String address, Double price, IList<RentalInclude> rFeatures, IList<SpecialFeatures> sFeatures)
        {
            this.Owner = owner;
            this.Name = name;
            this.Description = description;
            this._postalCode = postal;
            this._address = address;
            this._payedFeatures = sFeatures;
            this._includedFeatures = rFeatures;
            this.DailyPrice = price;
        }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Apartment;
            if (toCompareWith == null)
                return false;
            return this.Id == toCompareWith.Id
                && this.Address == toCompareWith.Address
                && this.Owner.Id == toCompareWith.Owner.Id
                && this.DailyPrice == toCompareWith.DailyPrice
                && this.Description == toCompareWith.Description
                && this.PostalCode == toCompareWith.PostalCode
                && this.PayedFeatures == toCompareWith.PayedFeatures;
        }


        public virtual IList<SpecialFeatures> PayedFeatures
        {
            get
            {
                return _payedFeatures;
            }

            set
            {
                _payedFeatures = value;
            }
        }

        public virtual IList<RentalInclude> IncludedFeatures
        {
            get
            {
                return _includedFeatures;
            }

            set
            {
                _includedFeatures = value;
            }
        }

        public virtual string PostalCode
        {
            get
            {
                return _postalCode;
            }

            set
            {
                _postalCode = value;
            }
        }

        public virtual string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }
    }
}
