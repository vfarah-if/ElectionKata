namespace ElectionKata
{
    internal class ElectionResult
    {
        internal ElectionResult(string party, double voteCount)
        {
            Party = party;
            VoteCount = voteCount;
        }

        public string Party { get; }
        public double VoteCount { get; }
    }
}