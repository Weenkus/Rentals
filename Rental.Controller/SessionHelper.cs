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
    public static class SessionHelper
    {
        public static void Delete<TEntity>(this ISession session, object id)
        {
            var queryString = string.Format("delete {0} where id = :id",
                                            typeof(TEntity));
            session.CreateQuery(queryString)
                   .SetParameter("id", id)
                   .ExecuteUpdate();
        }
    }
}
