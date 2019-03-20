namespace ElectionKata
{
    internal class ElectionResult
    {
        internal ElectionResult(string party, int voteCount)
        {
            this.Party = party;
            this.VoteCount = voteCount;
        }

        public string Party { get; }
        public double VoteCount { get; }
    }
}