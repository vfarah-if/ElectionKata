using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectionKata
{
    internal class ConstituencyElectionResult
    {
        internal ConstituencyElectionResult(string constituency, IReadOnlyList<ElectionResult> electionResults)
        {
            Constituency = constituency;
            ElectionResults = electionResults;
        }

        public string Constituency { get; }
        public IReadOnlyList<ElectionResult> ElectionResults { get; }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append($"{Constituency}");
            var sumOfAllVotes = ElectionResults.Sum(x => x.VoteCount);
            foreach (var electionResult in ElectionResults)
            {                
                decimal percentage = electionResult.VoteCount / sumOfAllVotes;
                result.Append($" || {electionResult.Party} | {percentage:0.00%}");
            }
            return result.ToString();
        }
    }
}
