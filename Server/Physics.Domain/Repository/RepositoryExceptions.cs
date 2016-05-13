using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physics.Domain.Repository
{
    public class NotExistException : Exception
    {
        public NotExistException()
        {

        }
        public NotExistException(string message) : base(message)
        {

        }
    }
}