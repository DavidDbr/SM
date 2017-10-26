using System;
using SQLite;

namespace SmartMonitoring.BBDD
{
    public class DTCData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string DtcFound { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
