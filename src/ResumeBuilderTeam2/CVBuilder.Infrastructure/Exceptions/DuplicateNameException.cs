﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Infrastructure.Exceptions
{
    public class DuplicateNameException : Exception
    {
        public DuplicateNameException(string message) : base(message) { }
    }
}
