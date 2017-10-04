using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.BBDD
{
    public interface ISQLite
    {

        SQLiteConnection GetConnection();

        void initBBDD();
    }
}

