using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rental
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create the app controller
            AppController controller = new AppController();

            fillWithTestData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(controller));
        }

        public static void fillWithTestData()
        {
            // Initialise NH and SQLite
            NHibernateService.Init();

            // Insert some data
            Employee employee1 = new Employee("Vinko", "Zadric");
            Employee employee2 = new Employee("Mlako", "Vader");
            Employee employee3 = new Employee("Hesimono", "Kaero");
            Client client = new Client("Marin", "Veljko", employee3);
            Client client1 = new Client("John", "Make", employee1);
            Client client2 = new Client("Mark", "Shannon", employee3);
            Client client3 = new Client("Laplace", "Smith", employee1);

            // Fill the repos
            PersonRepository.Instance.Add(employee1);
            PersonRepository.Instance.Add(employee2);
            PersonRepository.Instance.Add(employee3);
            PersonRepository.Instance.Add(client);
            PersonRepository.Instance.Add(client1);
            PersonRepository.Instance.Add(client2);
            PersonRepository.Instance.Add(client3);

            // Add some rentals
            // Create some features (payed and included)
            IList<SpecialFeatures> sF = new List<SpecialFeatures>();
            sF.Add(new SpecialFeatures(50, "Boat trip"));
            sF.Add(new SpecialFeatures(15, "Dinner near the sea"));

            IList<RentalInclude> rF = new List<RentalInclude>();
            rF.Add(new RentalInclude(Offer.balcony, 2));
            rF.Add(new RentalInclude(Offer.kitchen, 2));
            rF.Add(new RentalInclude(Offer.room, 4));

            // Create the apartmant via the factory and add it to the repo
            Apartment apartmant = ApartmanFactory.createApartman(client, "Vila Zrinka",
                "A beautiful vila on the sea, breathtaking view. Enjoy the warm sun on your skin and let go all your woories.",
                "12004", "Torovinkova 5", 45, rF, sF);
            RentalRepository.Instance.Add(apartmant);

            // Add more apartments
            IList<SpecialFeatures> sF1 = new List<SpecialFeatures>();
            sF1.Add(new SpecialFeatures(5, "Dinner"));
            sF1.Add(new SpecialFeatures(3, "Brunch"));

            IList<RentalInclude> rF1 = new List<RentalInclude>();
            rF1.Add(new RentalInclude(Offer.balcony, 1));
            rF1.Add(new RentalInclude(Offer.kitchen, 1));
            rF1.Add(new RentalInclude(Offer.room, 3));

            Apartment apartmant1 = ApartmanFactory.createApartman(client1, "Cove",
              "A small house down the lake, enjoy the silence and nature.",
                "54005", "Lake Wrakka 5", 25, rF1, sF1);
            RentalRepository.Instance.Add(apartmant1);

            // Add more apartments
            IList<SpecialFeatures> sF2 = new List<SpecialFeatures>();
            sF2.Add(new SpecialFeatures(5, "Dinner"));
            sF2.Add(new SpecialFeatures(8, "Pool"));

            IList<RentalInclude> rF2 = new List<RentalInclude>();
            rF2.Add(new RentalInclude(Offer.balcony, 2));
            rF2.Add(new RentalInclude(Offer.bathroom, 2));
            rF2.Add(new RentalInclude(Offer.room, 7));

            Apartment apartmant2 = ApartmanFactory.createApartman(client3, "Kabin in the Woods",
              "A small house in the forest, enjoy the silence and nature. Bring proper equipment and enjoy hunting.",
                "54005", "Forest Smek 17", 35, rF2, sF2);
            RentalRepository.Instance.Add(apartmant2);

            // Add transactions
            RentalInformation transaction = new RentalInformation(apartmant, DateTime.Now, DateTime.Now.AddDays(2), apartmant.DailyPrice);
            RentalInformation transaction1 = new RentalInformation(apartmant, DateTime.Now.AddDays(5), DateTime.Now.AddDays(10), apartmant.DailyPrice);
            RentalInformation transaction2 = new RentalInformation(apartmant1, DateTime.Now.AddDays(2), DateTime.Now.AddDays(15), apartmant2.DailyPrice);

            RentalInfoRepository.Instance.Add(transaction);
            RentalInfoRepository.Instance.Add(transaction1);
            RentalInfoRepository.Instance.Add(transaction2);
        }
    }
}
