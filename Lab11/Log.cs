using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public struct Log
    {
        public string message;
        public bool success;
        public ConsoleColor color;
        public Log(string message, bool success)
		{
            this.message = message;
            this.success = success;
            this.color = ConsoleColor.White; //Белый цвет - стандартный. 
		}
        public Log(string message, ConsoleColor color)
        {
            this.message = message;
            success = true;
            this.color = color;
        }
        public Log(string message, bool success, ConsoleColor color)
        {
            this.message = message;
            this.success = success;
            this.color = color;
        }
        public void Clear()
		{
            message = "";
            success = false;
            color = ConsoleColor.White;
        }
    }
}
