using System.Collections.Generic;
using System.Linq;

namespace ElectionApp
{
    public class Tour
    {
        public Scrutin Scrutin { get; set; } = null;
        public int Numero { get; set; }

        public List<CandidatTour> CandidatsTours { get; set; } = new();

        public Tour()
        {

        }

        public Tour(Scrutin scrutin)
        {
            Scrutin = scrutin;
        }



        public float GetPourcentageVoteCandidat(Candidat candidat)
        {
            var totalVote = CandidatsTours.Sum(ct => ct.NombreVotes);
            int voteCandidat = CandidatsTours.SingleOrDefault(ct => ct.Candidat == candidat).NombreVotes;

            return voteCandidat / totalVote * 100;
        } 
    }
}
