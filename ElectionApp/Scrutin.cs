using System.Collections.Generic;

namespace ElectionApp
{
    public class Scrutin
    {

        public bool Cloture { get; set; }
        public List<Candidat> Candidats = new();
    }
}
