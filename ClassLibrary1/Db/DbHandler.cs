using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Db
{
    public class DbHandler
    {
        private MongoConection _mongo;

        public DbHandler()
        {
            _mongo = new MongoConection();
        }
    }
}
