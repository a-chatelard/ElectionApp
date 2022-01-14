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

        [Given(@"un premier candidat avec (.*) votes")]
        public void GivenUnPremierCandidatAvecVotes(int nbVotes)
        {

        }
    }
}
