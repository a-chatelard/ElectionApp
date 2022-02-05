using ElectionApp.Exceptions;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace ElectionApp.Specs.Steps
{
    [Binding]
    public sealed class ElectionStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        

        public ElectionStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"un scrutin clôturé")]
        public void GivenUnScrutinCloture()
        {
            var scrutin = new Scrutin();
            scrutin.Cloture = true;
            _scenarioContext["scrutin"] = scrutin;
        }

        [Given(@"un scrutin non clôturé")]
        public void GivenUnScrutinNonCloture()
        {
            var scrutin = new Scrutin();
            scrutin.Cloture = false;
            _scenarioContext["scrutin"] = scrutin;
        }


        [Given(@"le tour numéro (.*)")]
        public void GivenUnTour(int numeroTour)
        {
            try
            {
                var tour = new Tour(numeroTour);
                if (_scenarioContext.TryGetValue("scrutin", out Scrutin scrutin))
                {
                    scrutin.Tours.Add(tour);
                    _scenarioContext["scrutin"] = scrutin;
                }
                _scenarioContext["tour"] = tour;
            }
            catch (TourScrutinInvalideException e)
            {
                _scenarioContext["result"] = e.Message;
            }
        }


        [Given(@"le candidat (.*) avec (.*) votes")]
        public void GivenUnCandidatAvecVotes(string nomCandidat, int nbVotes)
        {
            var candidat = new Candidat(nomCandidat);
            _scenarioContext[nomCandidat] = candidat;
            var tour = (Tour) _scenarioContext["tour"];
            var candidatTour = new CandidatTour(candidat, nbVotes, tour);
            tour.CandidatsTours.Add(candidatTour);
            _scenarioContext["tour"] = tour;
        }

        [When(@"le pourcentage de votes est calculé")]
        public void WhenLePourcentageDeVotesEstCalcule()
        {
            var tour = (Tour)_scenarioContext["tour"];
            foreach(var candidatTour in tour.CandidatsTours)
            {
                var pourcentageVote = tour.GetPourcentageVoteCandidat(candidatTour.Candidat);
                _scenarioContext[candidatTour.Candidat.Nom + "Pourcentage"] = pourcentageVote;
            }
        }

        [When(@"le vainqueur du scrutin est déterminé")]
        public void WhenLeVainqueurDuTourEstDetermine()
        {
            var scrutin = (Scrutin) _scenarioContext["scrutin"];
            try
            {
                var resultat = scrutin.DeterminerGagnant();
                _scenarioContext["result"] = resultat;
            }
            catch (ScrutinNonClotureException e)
            {
                _scenarioContext["result"] = e.Message;
            }            
        }


        [Then(@"le candidat (.*) a (.*)% votes")]
        public void ThenLeCandidatAVotes(string nomCandidat, float pourcentageVoteExpected)
        {
            var pourcentageCandidat = (float) _scenarioContext[nomCandidat + "Pourcentage"];
            pourcentageCandidat.Should().Be(pourcentageVoteExpected);
        }

        [Then(@"le message '(.*)' est affiché")]
        public void ThenLeMessageEstAffiche(string message)
        {
            var resultat = (string)_scenarioContext["result"];
            resultat.Should().Be(message);
        }
    }
}



