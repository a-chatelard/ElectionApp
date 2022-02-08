using ElectionApp.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ElectionApp
{
    public class Tour
    {
        public Scrutin Scrutin { get; set; } = null;
        public int Numero { get; set; }

        public List<CandidatTour> CandidatsTours { get; set; } = new();

        public Tour(int numero)
        {
            if (numero > 2)
            {
                throw new TourScrutinInvalideException("Maximum deux tours de scrutin");
            }
            Numero = numero;
        }

        public Tour(Scrutin scrutin)
        {
            Scrutin = scrutin;
        }

        public float GetPourcentageVoteCandidat(Candidat candidat)
        {
            var totalVote = CandidatsTours.Sum(ct => ct.NombreVotes);
            var voteCandidat = CandidatsTours.SingleOrDefault(ct => ct.Candidat == candidat).NombreVotes;
            return (float)voteCandidat / totalVote * 100;
        } 

        /*
         *Cas de l'égalité entre le 2eme et le 3eme candidat au premier tour : le tour est annulé.  
         */

        /*
         *Cas du vote blanc : le vote blanc est comptabilisé. Si vote blanc >50% au premier tour, il n'y a pas de vainqueur au scrutin. Une nouvelle élection doit avoir lieu.
         Dans le cas d'un second tour, pour être élu, le candidat doit avoir plus de 50% des suffrages exprimés pour être élu. Sinon, une nouvelle élection doit avoir lieu.
         */
        public List<Candidat> GetVainqueur()
        {
            var vainqueurs = new List<Candidat>();
            var resultatsCandidats = CandidatsTours.OrderByDescending(c => GetPourcentageVoteCandidat(c.Candidat)).ToList();
            var pourcentagePremierCandidat = GetPourcentageVoteCandidat(resultatsCandidats[0].Candidat);
            if (pourcentagePremierCandidat > 50)
            {
                vainqueurs.Add(resultatsCandidats[0].Candidat);
            }
            else
            {
                if (Numero == 1)
                {
                    vainqueurs.Add(resultatsCandidats[0].Candidat);
                    vainqueurs.Add(resultatsCandidats[1].Candidat);
                } 
            }
            return vainqueurs;
        }
    }
}
