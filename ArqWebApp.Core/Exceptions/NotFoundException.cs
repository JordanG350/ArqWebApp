using System;
using System.Collections.Generic;
using System.Text;

namespace ArqWebApp.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
