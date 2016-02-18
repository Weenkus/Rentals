using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

using NHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Criterion;
using System.Text.RegularExpressions;

namespace Rental
{
    public class Tests
    {
        [Fact]
        public void PersonCreation()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee = new Employee("Vinko", "Zadric");
            Client client = new Client("Marin", "Veljko", employee);

            PersonRepository.Instance.Add(employee);
            PersonRepository.Instance.Add(client);


            Client get = ((Client)PersonRepository.Instance.Get(client));
            // Check if the repository saved successfully
            Assert.Equal(client.DedicatedAgent.AdvisingClients.Count, get.DedicatedAgent.AdvisingClients.Count);

            Assert.Equal(employee.Id, PersonRepository.Instance.Get(employee).Id);
            Assert.Equal(employee.LastName, PersonRepository.Instance.Get(employee).LastName);
            // Test the client link created via the constructor
            Assert.Equal(client.DedicatedAgent.Id, employee.Id);
        }

        [Fact]
        public void FactoryCreationApartmant()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee = new Employee("Vinko", "Zadric");
            Client client = new Client("Marin", "Veljko", employee);

            PersonRepository.Instance.Add(employee);
            PersonRepository.Instance.Add(client);

            // Create some features (payed and included)
            IList<SpecialFeatures> sF = new List<SpecialFeatures>();
            sF.Add(new SpecialFeatures(200, "Izlet na more."));
            sF.Add(new SpecialFeatures(150, "Vecer u finom restoranu."));

            IList<RentalInclude> rF = new List<RentalInclude>();
            rF.Add(new RentalInclude(Offer.balcony, 2));
            rF.Add(new RentalInclude(Offer.kitchen, 2));
            rF.Add(new RentalInclude(Offer.room, 4));

            // Create the apartmant via the factory and add it to the repo
            Apartment a = ApartmanFactory.createApartman(client, "Vila zrinka", "Prekrasna vila na moru...",
                "12004", "Torovinkova 5", 200, rF, sF);
            RentalRepository.Instance.Add(a);

            Assert.Equal(RentalRepository.Instance.Get(a).Id, a.Id);
            Assert.Equal(RentalRepository.Instance.Get(a).Name, a.Name);

            Assert.Equal(RentalRepository.Instance.Get(a).Description, a.Description);
            Assert.Equal(RentalRepository.Instance.Get(a).Owner.Name, client.Name);
        }

        [Fact]
        public void RepositoryCRUDTestingPerson()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee1 = new Employee("Vinko", "Zadric");
            Employee employee2 = new Employee("Mlako", "Vader");
            Employee employee3 = new Employee("Hesimono", "Kaero");
            Client client = new Client("Marin", "Veljko", employee1);

            // Fill the repos
            PersonRepository.Instance.Add(employee1);
            PersonRepository.Instance.Add(employee2);
            PersonRepository.Instance.Add(employee3);
            PersonRepository.Instance.Add(client);

            // Check number
            Assert.Equal(PersonRepository.Instance.Count(), 4);

            // Check delete function of a repo
            PersonRepository.Instance.Remove(employee3);
            Assert.Equal(PersonRepository.Instance.Count(), 3);

            Assert.Equal(PersonRepository.Instance.Contains(employee3), false);

            // Update
            Employee emp = (Employee)PersonRepository.Instance.Get(employee2);
            int empId = emp.Id;
            emp.LastName = "Brega";
            PersonRepository.Instance.Update(emp);

            // Should still be only 3 people in the repo
            Assert.Equal(PersonRepository.Instance.Count(), 3);

            // Check if update worked
            Assert.Equal(PersonRepository.Instance.Get(empId).Id, emp.Id);
            Assert.Equal(PersonRepository.Instance.Get(empId).Name, emp.Name);
            Assert.Equal(PersonRepository.Instance.Get(empId).LastName, emp.LastName);
        }

        [Fact]
        public void SimpleTransactionCreation()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee = new Employee("Vinko", "Zadric");
            Client client = new Client("Marin", "Veljko", employee);

            // Create some features (payed and included)
            IList<SpecialFeatures> sF = new List<SpecialFeatures>();
            sF.Add(new SpecialFeatures(200, "Izlet na more."));
            sF.Add(new SpecialFeatures(150, "Vecer u finom restoranu."));

            IList<RentalInclude> rF = new List<RentalInclude>();
            rF.Add(new RentalInclude(Offer.balcony, 2));
            rF.Add(new RentalInclude(Offer.kitchen, 2));
            rF.Add(new RentalInclude(Offer.room, 4));

            // Create the apartmant via the factory and add it to the repo
            Apartment a = ApartmanFactory.createApartman(client, "Vila zrinka", "Prekrasna vila na moru...",
                "12004", "Torovinkova 5", 200, rF, sF);
            RentalRepository.Instance.Add(a);


            RentalInformation transaction = new RentalInformation(a, DateTime.Now, DateTime.Now.AddDays(2), a.DailyPrice);
            Assert.Equal(transaction.Rented.Owner.Id, client.Id);
            Assert.Equal(transaction.Rented.Owner.Name, client.Name);
        }

        [Fact]
        public void RepositoryCRUDTestingRental()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee = new Employee("Vinko", "Zadric");
            Client client = new Client("Marin", "Veljko", employee);

            // Clean repos (because they are singeltons, they might still have some data left in them)
            PersonRepository.Instance.Clear();
            RentalRepository.Instance.Clear();

            // Fill the repos
            PersonRepository.Instance.Add(employee);
            PersonRepository.Instance.Add(client);

            // Create some features (payed and included)
            IList<SpecialFeatures> sF = new List<SpecialFeatures>();
            sF.Add(new SpecialFeatures(200, "Boat trip."));
            sF.Add(new SpecialFeatures(150, "Dinner near the sea."));

            IList<RentalInclude> rF = new List<RentalInclude>();
            rF.Add(new RentalInclude(Offer.balcony, 2));
            rF.Add(new RentalInclude(Offer.kitchen, 2));
            rF.Add(new RentalInclude(Offer.room, 4));

            // Create the apartmant via the factory and add it to the repo
            Apartment a = ApartmanFactory.createApartman(client, "Vila zrinka", "A beautiful vila on the sea, breathtaking view...",
                "12004", "Torovinkova 5", 200, rF, sF);
            RentalRepository.Instance.Add(a);

            // Check repo numbers
            Assert.Equal(PersonRepository.Instance.Count(), 2);
            Assert.Equal(RentalRepository.Instance.Count(), 1);

            // Check delete function of a repo
            RentalRepository.Instance.Remove(a);
            Assert.Equal(RentalRepository.Instance.Count(), 0);

            Assert.Equal(RentalRepository.Instance.Contains(a), false);
        }

        [Fact]
        public void RepoGetAll()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee1 = new Employee("Vinko", "Zadric");
            Employee employee2 = new Employee("Mlako", "Vader");
            Employee employee3 = new Employee("Hesimono", "Kaero");
            Client client = new Client("Marin", "Veljko", employee1);

            // Clean repos (because they are singeltons, they might still have some data left in them)
            PersonRepository.Instance.Clear();

            // Fill the repos
            PersonRepository.Instance.Add(employee1);
            PersonRepository.Instance.Add(employee2);
            PersonRepository.Instance.Add(employee3);
            PersonRepository.Instance.Add(client);

            Assert.Equal(PersonRepository.Instance.GetAll().Count, 4);
        }

        [Fact]
        public void TestClientCRUD()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            // Insert some data
            Employee employee1 = new Employee("Vinko", "Zadric");
            Employee employee2 = new Employee("Mlako", "Vader");
            Employee employee3 = new Employee("Hesimono", "Kaero");
            Client client = new Client("Marin", "Veljko", employee1);
            Client client1 = new Client("John", "Make", employee1);
            Client client2 = new Client("Mark", "Shannon", employee3);
            Client client3 = new Client("Laplace", "Smith", employee1);

            // Fill the repos
            PersonRepository.Instance.Add(employee1);
            PersonRepository.Instance.Add(employee2);
            PersonRepository.Instance.Add(employee3);
            PersonRepository.Instance.Add(client);
            PersonRepository.Instance.Add(client1);

            // Check number
            Assert.Equal(PersonRepository.Instance.Count(), 7);

            // Check delete function of a repo
            PersonRepository.Instance.Remove(client);
            Assert.Equal(PersonRepository.Instance.Count(), 6);

            // Check relations
            Assert.Equal(PersonRepository.Instance.Contains(client), false);
            Assert.Equal(PersonRepository.Instance.Contains(employee1), true);

            // Update
            Client cli = (Client)PersonRepository.Instance.Get(client1);
            int cId = cli.Id;
            cli.LastName = "Hekko";
            PersonRepository.Instance.Update(cli);

            // Should still be only 6 people in the repo
            Assert.Equal(PersonRepository.Instance.Count(), 6);

            // Check if update worked
            Assert.Equal(PersonRepository.Instance.Get(cId).Id, cli.Id);
            Assert.Equal(PersonRepository.Instance.Get(cId).Name, cli.Name);
            Assert.Equal(PersonRepository.Instance.Get(cId).LastName, cli.LastName);
        }

        [Fact]
        public void TransactionCreationAndRepoCRUD()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee employee = new Employee("Vinko", "Zadric");
            Client client = new Client("Marin", "Veljko", employee);

            PersonRepository.Instance.Add(employee);
            PersonRepository.Instance.Add(client);


            // Create some features (payed and included)
            IList<SpecialFeatures> sF = new List<SpecialFeatures>();
            sF.Add(new SpecialFeatures(200, "Izlet na more."));
            sF.Add(new SpecialFeatures(150, "Vecer u finom restoranu."));

            IList<RentalInclude> rF = new List<RentalInclude>();
            rF.Add(new RentalInclude(Offer.balcony, 2));
            rF.Add(new RentalInclude(Offer.kitchen, 2));
            rF.Add(new RentalInclude(Offer.room, 4));

            // Create the apartmant via the factory and add it to the repo
            Apartment a = ApartmanFactory.createApartman(client, "Vila zrinka", "Prekrasna vila na moru...",
                "12004", "Torovinkova 5", 200, rF, sF);
            RentalRepository.Instance.Add(a);


            RentalInformation transaction = new RentalInformation(a, DateTime.Now, DateTime.Now.AddDays(2), a.DailyPrice);
            RentalInfoRepository.Instance.Add(transaction);

            // Check if the repository saved successfully
            Assert.Equal(RentalInfoRepository.Instance.Count(), 1);

            Assert.Equal(RentalInfoRepository.Instance.Get(transaction.Id).Id, transaction.Id);
            Assert.Equal(RentalInfoRepository.Instance.Get(transaction.Id).DailyCost, transaction.DailyCost);
            Assert.Equal(RentalInfoRepository.Instance.Contains(transaction), true);

            // Test the link
            Assert.Equal(transaction.Rented.Owner.Id, client.Id);

            // Test removal
            RentalInfoRepository.Instance.Remove(transaction);
            Assert.Equal(RentalInfoRepository.Instance.Count(), 0);
            Assert.Equal(RentalInfoRepository.Instance.Contains(transaction), false);
        }

        [Fact]
        public void DatabaseTransactionTesting()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            Employee person = new Employee("Vinko", "Zadric");

            // Try to open a session
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(person);
                    transaction.Commit();

                    Employee newPerson = session.CreateCriteria<Employee>().List<Employee>().ElementAt(0);

                    Assert.Equal(person.Name, newPerson.Name);
                    Assert.Equal(person.LastName, newPerson.LastName);
                }
            }
        }
    }
}
