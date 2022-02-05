using System;

namespace ElectionApp.Exceptions
{
    public class TourScrutinInvalideException : Exception
    {
        public TourScrutinInvalideException(string message) : base(message)
        {
        }
    }
}
