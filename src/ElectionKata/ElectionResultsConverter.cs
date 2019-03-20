using System;
using System.Collections.Generic;
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
                { "L", "Labour Party" }
            };
        }
        public string Convert(string electionData)
        {
            if (string.IsNullOrWhiteSpace(electionData))
            {
                throw new ArgumentException(PollingDataIsRequired, nameof(electionData));
            }

            StringBuilder dataBuilder = new StringBuilder();
            foreach (var inputLine in electionData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                var result = inputLine.Split(",", StringSplitOptions.RemoveEmptyEntries);
                dataBuilder.AppendLine($"{result[0]} || {partyCodes[result[2].Trim()]} | 100%");
            }

            return dataBuilder.ToString();
        }
    }
}
