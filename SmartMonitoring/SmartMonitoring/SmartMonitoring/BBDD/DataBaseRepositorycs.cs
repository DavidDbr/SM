using SQLite;

namespace SmartMonitoring.BBDD
{
    class DataBaseRepository
    {
        private readonly DataBaseContext dataBase;
        private static object locker = new object();

        public DataBaseRepository (DataBaseContext dataBase)
        {
            this.dataBase = dataBase;
        }

      

        
    }
}
