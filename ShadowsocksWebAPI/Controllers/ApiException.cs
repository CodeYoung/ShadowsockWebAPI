using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShadowsocksWebAPI.Controllers
{
    [Serializable]
    public class ApiException : Exception
    {
        private string v1;
        private string v2;

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}