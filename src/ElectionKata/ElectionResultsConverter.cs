using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static ElectionKata.ErrorMessages;

namespace ElectionKata
{
    public class ElectionResultsConverter
    {
        private readonly IReadOnlyDictionary<string, string> partyDescriptions;

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

        public ElectionResultsConverter(IReadOnlyDictionary<string, string> partyDescriptions)
        {
            this.partyDescriptions = partyDescriptions;
        }

        public string Convert(string electionData)
        {
            if (string.IsNullOrWhiteSpace(electionData))
            {
                throw new ArgumentException(PollingDataIsRequired, nameof(electionData));
            }

            var constituencyElectionResults = GetConstituencyElectionResults(electionData).ToList();
            var dataBuilder = new StringBuilder(constituencyElectionResults.Count);
            foreach (var constituencyElectionResult in constituencyElectionResults)
            {
                dataBuilder.AppendLine(constituencyElectionResult.ToString());
            }

            return dataBuilder.ToString();
        }

        private IEnumerable<ConstituencyElectionResult> GetConstituencyElectionResults(string electionData)
        {
            foreach (var inputLine in electionData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var constituencyElectionStrings = inputLine.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var constituency = constituencyElectionStrings[0].Trim();
                var electionResults = ExtractElectionResults(constituencyElectionStrings).AsReadOnly();
                var constituencyResult = new ConstituencyElectionResult(constituency, electionResults);
                yield return constituencyResult;
            }
        }

        private List<ElectionResult> ExtractElectionResults(IReadOnlyList<string> constituencyElectionStrings)
        {
            var results = new List<ElectionResult>();
            for (var i = 1; i < constituencyElectionStrings.Count - 1; i += 2)
            {
                var voteCount = System.Convert.ToInt32(constituencyElectionStrings[i].Trim());
                var party = partyDescriptions[constituencyElectionStrings[i + 1].Trim()];
                results.Add(new ElectionResult(party, voteCount));
            }

            return results;
        }
    }
}
