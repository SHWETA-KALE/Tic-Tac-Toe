﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Exceptions
{
    public class IsNullOrWhiteSpaceException:Exception
    {
        public IsNullOrWhiteSpaceException(string message) : base(message) { }
    }
}
