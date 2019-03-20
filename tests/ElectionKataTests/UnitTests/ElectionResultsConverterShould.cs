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

        [Theory]
        [InlineData("Cardiff West, 11014, C", "Cardiff West ||")]
        [InlineData("Cardiff West, 11014, C", "Cardiff West || Conservative Party |")]
        public void ExtractValidDataFromASingleLine(string input, string expected)
        {
            var actual = electionResultsConverter.Convert(input);

            actual.Should().StartWith(expected);
        }
    }
}
