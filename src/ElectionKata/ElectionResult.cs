namespace ElectionKata
{
    internal class ElectionResult
    {
        internal ElectionResult(string party, decimal voteCount)
        {
            Party = party;
            VoteCount = voteCount;
        }

        public string Party { get; }
        public decimal VoteCount { get; }
    }
}