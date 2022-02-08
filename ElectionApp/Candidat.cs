using System.Collections.Generic;

namespace ElectionApp
{
    public class Candidat
    {
        public string Nom { get; set; }

        public List<CandidatTour> CandidatsTours { get; set; } = null;

        public Candidat() { }

        public Candidat(string nom)
        {
            Nom = nom;
        }
    }
}
