using System;
using static ElectionKata.ErrorMessages;

namespace ElectionKata
{
    public class ElectionResultsConverter
    {
        public string Convert(string electionData)
        {
            if (string.IsNullOrWhiteSpace(electionData))
            {
                throw new ArgumentException(PollingDataIsRequired, nameof(electionData));
            }

            var result = electionData.Split(",", StringSplitOptions.RemoveEmptyEntries);
            return $"{result[0]} ||";
        }
    }
}
