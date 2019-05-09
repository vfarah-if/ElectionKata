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
            Given("an election result converter", () => electionResultsConverter = new ElectionResultsConverter(PartyRepository.Create()));
            When($"I receive '{SmallInput}'", () =>
            {
                actualResult = electionResultsConverter.Convert(SmallInput);
            });
            Then($"the data should be converted to '{SmallInputExpectedResult}'", () => actualResult.ShouldBe(SmallInputExpectedResult));
        }

        [Scenario("Convert full election results to an expected format")]
        public void ConvertLargeElectionResultsAsExpected()
        {
            Given("an election result converter", () => electionResultsConverter = new ElectionResultsConverter(PartyRepository.Create()));
            When($"I receive '{LargeInput}'", () =>
            {
                actualResult = electionResultsConverter.Convert(LargeInput);
            });
            Then($"the data should be converted to '{LargeInputExpectedResult}'", () => actualResult.ShouldBe(LargeInputExpectedResult));
        }
    }

}
