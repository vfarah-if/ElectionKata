using System.Collections.Generic;

namespace ElectionKata
{
    public class PartyRepository
    {
        private readonly IReadOnlyDictionary<string, string> partyDescriptions;

        public PartyRepository()
        {
            partyDescriptions = new Dictionary<string, string>
            {
                {"C", "Conservative Party"},
                {"L", "Labour Party"},
                {"UKIP", "UKIP"},
                {"LD", "Liberal Democrats"},
                {"G", "Green Party"},
                {"Ind", "Independent"},
                {"SNP", "SNP"},
            };
        }

        public PartyRepository(IReadOnlyDictionary<string, string> partyDescriptions)
        {
            this.partyDescriptions = partyDescriptions;
        }

        public virtual string GetPartyDescription(string partyCode)
        {
            return partyDescriptions[partyCode];
        }

        public static PartyRepository Create(IReadOnlyDictionary<string, string> partyDescriptions = null)
        {
            return partyDescriptions != null ? new PartyRepository(partyDescriptions) : new PartyRepository();
        }
    }
}
