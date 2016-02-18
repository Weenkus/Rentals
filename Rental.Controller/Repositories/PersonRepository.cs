using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Criterion;
using System.Text.RegularExpressions;

namespace Rental
{
    public class PersonRepository : IPersonRepository
    {
        // Repo is a singlton, make data consistancy easier and more practical
        private static PersonRepository instance;
        private IList<Person> _personList = new List<Person>();

        private PersonRepository() { }

        public static PersonRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersonRepository();
                }
                return instance;
            }
        }

        private void LoadData()
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    _personList = session.CreateCriteria<Person>().List<Person>();
                }
            }
        }
        
        public int Count()
        {
            LoadData();
            return _personList.Count;
        }

        public Person Get(int id)
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.Get<Person>(id);
                }
            }
        }

        public Person Get(Person person)
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.Get<Person>(person.Id);
                }
            }
        }

        public Person GetByIndex(int index)
        {
            LoadData();
            if (index < _personList.Count)
                return _personList.ElementAt(index);
            else
                return null;
        }

        public IList<Person> GetAll()
        {
            LoadData();
            return _personList;
        }

        public IList<Client> GetAllClients()
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.CreateCriteria<Client>().List<Client>();
                }
            }
        }

        public IList<Employee> GetAllEmpoyees()
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.CreateCriteria<Employee>().List<Employee>();
                }
            }
        }

        public void Add(Person person)
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(person);
                    transaction.Commit();
                }
            }
        }

        public void Remove(int id)
        {
            LoadData();
            if (_personList.Any(x => x.Id == id))
            {
                using (var session = NHibernateService.SessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(_personList.Where(x => x.Id == id).SingleOrDefault());
                        transaction.Commit();
                    }
                }
            }
        }

        public void Remove(Person person)
        {
            LoadData();
            if (_personList.Any(x => x.Id == person.Id))
            {
                using (var session = NHibernateService.SessionFactory.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        //session.Delete<Person>(person.Id);
                        session.Delete(person);
                        transaction.Commit();
                    }
                }
            }
        }

        public void Clear()
        {
            LoadData();
            _personList.Clear();
        }

        public bool Contains(Person person)
        {
            LoadData();
            return _personList.Any(p => p.Id == person.Id);
        }

        public void Update(Person person)
        {
            using (var session = NHibernateService.SessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    //session.Delete<Person>(person.Id);
                    //session.Save(person);
                    session.SaveOrUpdate(person);
                    transaction.Commit();
                }
            }
        }
    }
}
