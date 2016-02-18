using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental
{
    public interface IRentalRepository
    {
        int Count();

        Rental Get(int id);

        Rental Get(Rental rental);

        IList<Rental> GetAll();

        IList<Apartment> GetAllApartmants();

        Rental GetByIndex(int index);

        void Add(Rental rental);

        void Remove(int id);

        void Remove(Rental rental);

        void Clear();

        bool Contains(Rental rental);

        void Update(Rental rental);
    }
}
