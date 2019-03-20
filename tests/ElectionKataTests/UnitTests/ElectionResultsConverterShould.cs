using System;
using ElectionKata;
using FluentAssertions;
using Xunit;

namespace ElectionKataTests.UnitTests
{
    public class ElectionResultsConverterShould
    {
        private readonly ElectionResultsConverter electionResultsConverter;

        public ElectionResultsConverterShould()
        {
            electionResultsConverter = new ElectionResultsConverter();
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

        [Fact]
        public void ExtractTheConstituency()
        {
            var input = "Cardiff West, 11014, C, 17803, L, 4923, UKIP, 2069, LD";
            var expected = "Cardiff West ||";

            var actual = electionResultsConverter.Convert(input);

            actual.Should().Be(expected);
        }
    }
}
