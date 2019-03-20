using System;
using System.Collections.Generic;
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
                { "C", "Conservative Party" }
            };
        }
        public string Convert(string electionData)
        {
            if (string.IsNullOrWhiteSpace(electionData))
            {
                throw new ArgumentException(PollingDataIsRequired, nameof(electionData));
            }

            var result = electionData.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return $"{result[0]} || {partyCodes[result[2].Trim()]} | 100%";
        }
    }
}
