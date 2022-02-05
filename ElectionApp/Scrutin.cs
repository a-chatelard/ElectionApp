using ElectionApp.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ElectionApp
{
    public class Scrutin
    {
        public bool Cloture { get; set; }

        public List<Tour> Tours = new();

        public string DeterminerGagnant()
        {
            if (!Cloture)
            {
                throw new ScrutinNonClotureException("Le scrutin n'est pas clôturé.");
            }
            var tourActuel = Tours.Last();
            List<Candidat> vainqueurs = tourActuel.GetVainqueur();
            if (vainqueurs.Count == 0)
            {
                return "Aucun vainqueur pour ce tour.";
            } else if (vainqueurs.Count == 1)
            {
                return vainqueurs.Single().Nom + " est le vainqueur.";
            } else
            {
                return $"Les candidats {vainqueurs[0].Nom} et {vainqueurs[1].Nom} passent au deuxième tour.";
            }
        }
    }
}
