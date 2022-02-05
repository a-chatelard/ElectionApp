using System.Collections.Generic;

namespace ElectionApp
{
    public class Scrutin
    {
        public bool Cloture { get; set; } = false;

        public List<Tour> Tours = new();
    }
}
