using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IECFW.ExceptionHandling
{
    public class NotificationException : Exception
    {
        public NotificationException(string message)
            : base(message)
        {

        }

        public NotificationException(string message, Exception error)
            : base(message, error)
        {

        }

        public NotificationException(string message, string type)
            : base(message)
        {
            Type = type;
        }

        public NotificationException(string message, string type, Exception error)
            : base(message, error)
        {
            Type = type;
        }

        public string Type { get; set; }


    }
}
