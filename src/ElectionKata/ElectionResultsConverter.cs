using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ElectionKata.ErrorMessages;

namespace ElectionKata
{
    public class ElectionResultsConverter
    {
        private readonly Dictionary<string, string> partyDescriptions;

        public ElectionResultsConverter() : this(new Dictionary<string, string>()
        {
            {"C", "Conservative Party"},
            {"L", "Labour Party"},
            {"UKIP", "UKIP"},
            {"LD", "Liberal Democrats"},
            {"G", "Green Party"},
            {"Ind", "Independent"},
            {"SNP", "SNP"},
        })
        { }

        public ElectionResultsConverter(Dictionary<string, string> partyDescriptions)
        {
            this.partyDescriptions = partyDescriptions;
        }

        public string Convert(string electionData)
        {
            if (string.IsNullOrWhiteSpace(electionData))
            {
                throw new ArgumentException(PollingDataIsRequired, nameof(electionData));
            }

            var dataBuilder = new StringBuilder();
            foreach (var inputLine in electionData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var partyData = inputLine.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var constituency = partyData[0].Trim();
                var electionResults = ExtractElectionResults(partyData).AsReadOnly();
                var constituencyResult = new ConstituencyElectionResult(constituency, electionResults);
                dataBuilder.AppendLine(constituencyResult.ToString());
            }

            return dataBuilder.ToString();
        }

        private List<ElectionResult> ExtractElectionResults(string[] partyData)
        {
            var results = new List<ElectionResult>();
            for (int i = 1; i < partyData.Length - 1; i += 2)
            {
                var voteCount = System.Convert.ToInt32(partyData[i].Trim());
                var party = partyDescriptions[partyData[i + 1].Trim()];
                results.Add(new ElectionResult(party, voteCount));
            }

            return results;
        }
    }
}
