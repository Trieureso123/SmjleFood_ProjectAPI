using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.Exceptions
{
    public class MapServiceException : Exception
    {
        public string Code { get; set; }
        public MapServiceException()
        {

        }

        public MapServiceException(string message) : base(message) { }

        public MapServiceException(string message, string code) : base(message) 
        {
            Code = code;
        }

        public MapServiceException(string message, Exception exception)
        {
        }
    }
}
