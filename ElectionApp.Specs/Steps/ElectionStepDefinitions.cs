using System.Collections.Generic;
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

        [Given(@"un premier tour dans un scrutin non clôturé")]
        public void GivenUnPremierTourDansUnScrutinNonClôturé()
        {
            var scrutin = new Scrutin();
            var tour = new Tour(scrutin);
            _scenarioContext.Add("scrutinNonClôturé", scrutin);
            _scenarioContext.Add("tour")
        }


        [Given(@"le  candidat avec (.*) votes")]
        public void GivenUnPremierCandidatAvecVotes(int nbVotes)
        {
            var candidat = new Candidat("Premier candidat");
            _scenarioContext.Add("premierCandidat", candidat);

        }
    }
}


//besoin scrutin cloturé pour définir gagnant. Pas besoin pour calculer les %.
//scrutin methode getVainqueur avec booleen ifScrutinCloturé
