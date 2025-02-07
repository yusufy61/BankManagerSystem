using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagerSystem.Exceptions
{
    public class YetersizBakiyeException : Exception
    {
        public YetersizBakiyeException(string message) : base(message)
        {
        }
    }
}
