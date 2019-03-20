using CoreBDD;
using ElectionKata;
using static ElectionKataTests.TestData;

namespace ElectionKataTests.AcceptanceTests
{
    public class ConvertResultsByConstituencyShould : ElectionResultsConverterFeature
    {
        private ElectionResultsConverter electionResultsConverter;
        private string actualResult;

        [Scenario("Convert small subset of election results to an expected format")]
        public void ConvertSimpleElectionResultsAsExpected()
        {
            Given("an election result converter", () => electionResultsConverter = new ElectionResultsConverter());
            When($"I receive '{SimpleInput}'", () =>
            {
                actualResult = electionResultsConverter.Convert(SimpleInput);
            });
            Then($"the data should be converted to '{SimpleInputExpectedResult}'", () => actualResult.ShouldBe(SimpleInputExpectedResult));
        }

        [Scenario("Convert full election results to an expected format")]
        public void ConvertLargeElectionResultsAsExpected()
        {
            Given("an election result converter", () => electionResultsConverter = new ElectionResultsConverter());
            When($"I receive '{LargeInput}'", () =>
            {
                actualResult = electionResultsConverter.Convert(SimpleInput);
            });
            Then($"the data should be converted to '{LargeInputResult}'", () => actualResult.ShouldBe(LargeInputResult));
        }
    }

}
