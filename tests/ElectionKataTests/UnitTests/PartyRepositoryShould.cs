using System;
using System.Collections.Generic;
using ElectionKata;
using FluentAssertions;
using Xunit;

namespace ElectionKataTests.UnitTests
{
    public class PartyRepositoryShould
    {
        private IReadOnlyDictionary<string, string> partyInformationList;
        private readonly PartyRepository partyRepository;

        public PartyRepositoryShould()
        {
            this.partyInformationList = new Dictionary<string, string>
            {
                {"key1", "value"},
                {"key2", "value2"}
            };
            this.partyRepository = new PartyRepository(partyInformationList);
        }

        [Fact]
        public void GetPartyInformationByCode()
        {
            foreach (var partyInformation in partyInformationList)
            {
                var actual = partyRepository.GetPartyDescription(partyInformation.Key);

                actual.Should().Be(partyInformation.Value);
            }
        }

        [Fact]
        public void ThrowAKeyNotFoundExceptionWhenPartyDoesNotExist()
        {
            var unknownPartyCode = "Unknown";

            Action testAction = () => partyRepository.GetPartyDescription(unknownPartyCode);

            testAction.Should().Throw<KeyNotFoundException>();
        }
    }
}
