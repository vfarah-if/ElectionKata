using System;

namespace ElectionKata
{
    public class InvalidVotingDataFormatException : ApplicationException
    {
        public InvalidVotingDataFormatException() 
            : base(ErrorMessages.InvalidElectionResultData)
        {
        }
    }
}