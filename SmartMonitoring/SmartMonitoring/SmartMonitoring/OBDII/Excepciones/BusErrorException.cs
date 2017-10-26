using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.OBDII.Excepciones
{
    public class BusErrorException : Exception
    {
        public BusErrorException()
        {
        }

        public BusErrorException(string message) : base(message)
        {
        }

        public BusErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
