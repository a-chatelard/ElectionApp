namespace ElectionApp
{
    public class CandidatTour
    {
        public Candidat Candidat { get; set; }
        public int NombreVotes { get; set; }
        public Tour Tour { get; set; }

        public CandidatTour() { }

        public CandidatTour(Candidat candidat, int nombreVotes, Tour tour)
        {
            Candidat = candidat;
            NombreVotes = nombreVotes;
            Tour = tour;
        }
    }
}
