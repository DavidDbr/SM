using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.OBDII.Excepciones
{
    public class BufferFullException : Exception
    {
        public BufferFullException()
        {
        }

        public BufferFullException(string message) : base(message)
        {
        }

        public BufferFullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
