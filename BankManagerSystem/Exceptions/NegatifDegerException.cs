using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagerSystem.Exceptions
{
    public class NegatifDegerException : Exception
    {
        public NegatifDegerException(string message) : base(message)
        {
        }
    }
}
