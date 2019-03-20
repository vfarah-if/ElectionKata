using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static ElectionKata.ErrorMessages;

namespace ElectionKata
{
    public class ElectionResultsConverter
    {
        private readonly Dictionary<string, string> partyCodes;

        public ElectionResultsConverter()
        {
            this.partyCodes = new Dictionary<string, string>()
            {
                { "C", "Conservative Party" },
                { "L", "Labour Party" },
                { "UKIP", "UKIP" },
                { "LD", "Liberal Democrats" },
                { "G", "Green Party" },
                { "Ind", "Independent" },
                { "SNP", "SNP" },
            };
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
                var result = inputLine.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var constituency = result[0].Trim();
                dataBuilder.Append($"{constituency}");
                var electionResults = ExtractElectionResults(result);
                var sumOfAllVotes = electionResults.Sum(x => x.VoteCount);                
                foreach (var electionResult in electionResults)
                {
                    decimal percentage = electionResult.VoteCount / sumOfAllVotes;
                    dataBuilder.Append($" || {electionResult.Party} | {percentage:0.00%}");
                }
                dataBuilder.AppendLine();
            }

            return dataBuilder.ToString();
        }

        private List<ElectionResult> ExtractElectionResults(string[] result)
        {
            var results = new List<ElectionResult>();
            for (int i = 1; i <= result.Length - 1; i += 2)
            {
                var voteCount = System.Convert.ToInt32(result[i].Trim());
                var party = partyCodes[result[i + 1].Trim()];
                results.Add(new ElectionResult(party, voteCount));
            }

            return results;
        }
    }
}
