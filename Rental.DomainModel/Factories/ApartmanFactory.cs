using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public class ApartmanFactory
    {
        public static Apartment createApartman(Client owner, String name, String description, String postal,
            String address, Double monthlyPrice, IList<RentalInclude> rFeatures, IList<SpecialFeatures> sFeatures)
        {
            Apartment apartmant = new Apartment(owner, name, description, postal, address,
                monthlyPrice, rFeatures, sFeatures);
            return apartmant;
        }

        public static Apartment createApartman(Client owner, String name, String description, String postal,
            String address, Double monthlyPrice)
        {
            Apartment apartmant = new Apartment(owner, name, description, postal, address,
               monthlyPrice, null, null);
            return apartmant;
        }
    }
}
