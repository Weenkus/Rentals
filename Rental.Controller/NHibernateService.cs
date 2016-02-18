using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using System.IO;
using System.Data.SQLite;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;

namespace Rental
{
    public class NHibernateService
    {
        private static Configuration _cfg;
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory;
            }

            set
            {
                _sessionFactory = value;
            }
        }

        public static void Init()
        {
            // Create the database
            //SQLiteConnection.CreateFile("MyDatabase.sqlite");

    //        Configuration c = new Configuration();
    //        c.Configure();

            //c.AddAssembly(Assembly.GetCallingAssembly());
    //        _cfg = c;

            // SchemaUpdate creates tables in db if they don't exists
            // SchemaCreate will erase all previous tables (getting fresh database every run)


            _sessionFactory = CreateSessionFactory();
            //BuildSchema(_cfg);



            //new SchemaUpdate(c).Execute(true, true);
        }

        public static ISession OpenSession()
        {
            ISessionFactory f = _cfg.BuildSessionFactory();
            return f.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile("MyDatabase.db")
              )
              .Mappings(m =>
              {
                  m.FluentMappings.AddFromAssemblyOf<Rental>();
              }
                )
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("MyDatabase.db"))
                File.Delete("MyDatabase.db");

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
