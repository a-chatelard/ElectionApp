﻿using ElectionApp.Exceptions;
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
