using System;

namespace BlazorGenUI.Reflection.Exceptions
{
    public class IncorrectTabNameException : Exception
    {
        public IncorrectTabNameException()
        {
            
        }
        public IncorrectTabNameException(string message) : base(message)
        {

        }
    }
}