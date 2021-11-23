using System;

namespace BlazorGenUI.Reflection.Exceptions
{
    public class ContextNullException : Exception
    {
        public ContextNullException()
        {

        }
        public ContextNullException(string message) : base(message)
        {

        }
    }
}
