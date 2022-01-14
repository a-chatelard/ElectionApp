using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionApp
{
    public class TourElection
    {
        public Scrutin Scrutin { get; set; }
        public int NumeroTour { get; set; }
        public List<CandidatScrutin> Participants { get; set; } = new();
    }
}
