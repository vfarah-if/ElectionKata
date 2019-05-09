using ElectionKata;
using FluentAssertions;
using System;
using Moq;
using Xunit;
using static System.Environment;

namespace ElectionKataTests.UnitTests
{
    public class ElectionResultsConverterShould
    {
        private readonly ElectionResultsConverter electionResultsConverter;
        private Mock<PartyRepository> partyRepositoryMock;

        public ElectionResultsConverterShould()
        {
            SetupPartyRepositoryWithMockData();
            electionResultsConverter = new ElectionResultsConverter(partyRepositoryMock.Object);
        }

        private void SetupPartyRepositoryWithMockData()
        {
            partyRepositoryMock = new Mock<PartyRepository>();
            partyRepositoryMock.Setup(x => x.GetPartyDescription("C")).Returns("Conservative Party");
            partyRepositoryMock.Setup(x => x.GetPartyDescription("L")).Returns("Labour Party");
            partyRepositoryMock.Setup(x => x.GetPartyDescription("UKIP")).Returns("UKIP");
            partyRepositoryMock.Setup(x => x.GetPartyDescription("LD")).Returns("Liberal Democrats");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowAnExceptionWhenInvalidInputAssigned(string invalidElectionData)
        {
            Action action = () => this.electionResultsConverter.Convert(invalidElectionData);

            action.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{ErrorMessages.PollingDataIsRequired}Parameter name: electionData");
        }

        [Theory]
        [InlineData(
            "Cardiff West, 11014, C",
            "Cardiff West ||")]
        [InlineData(
            "Cardiff West, 11014, C",
            "Cardiff West || Conservative Party |")]
        [InlineData(
            "Cardiff West, 11014, C",
            "Cardiff West || Conservative Party | 100.00%")]
        [InlineData(
            "Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD",
            "Cardiff West || Conservative Party | 30.76% || Labour Party | 49.72% || UKIP | 13.75% || Liberal Democrats | 5.78%")]
        public void ExtractValidDataFromASingleLine(string input, string expected)
        {
            var actual = electionResultsConverter.Convert(input);

            actual.Should().StartWith(expected);
        }

        [Fact]
        public void ExtractValidDataFromASimpleMultiLine()
        {
            var input = "Cardiff West, 11014, C," + NewLine +
                        "Islington South & Finsbury, 22547, L";
            var expected = $"Cardiff West || Conservative Party | 100.00%" + NewLine +
                           "Islington South & Finsbury || Labour Party | 100.00%";

            var actual = electionResultsConverter.Convert(input);

            actual.Should().Be(expected);
        }
    }
}
