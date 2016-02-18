using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public interface IRentalInfoRepository
    {
        int Count();

        RentalInformation Get(int id);

        RentalInformation Get(RentalInformation rentalInfo);

        IList<RentalInformation> GetAll();

        RentalInformation GetByIndex(int index);

        void Add(RentalInformation rentalInfo);

        void Remove(int id);

        void Remove(RentalInformation rentalInfo);

        void Clear();

        bool Contains(RentalInformation rentalInfo);

        void Update(RentalInformation rentalInfo);
    }
}
