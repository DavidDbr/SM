using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.OBDII.Excepciones
{
    public class StoppedException : Exception
    {
        public StoppedException()
        {
        }

        public StoppedException(string message) : base(message)
        {
        }

        public StoppedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

