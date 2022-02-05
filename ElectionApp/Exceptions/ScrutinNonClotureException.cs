using System;

namespace ElectionApp.Exceptions
{
    public class ScrutinNonClotureException : Exception
    {
        public ScrutinNonClotureException(string message) : base(message)
        {
        }
    }
}
