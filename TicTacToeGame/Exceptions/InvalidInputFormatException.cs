using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.Exceptions
{
    public class InvalidInputFormatException:Exception
    {
        public InvalidInputFormatException(string message):base(message) { 
        
        }
    }
}
