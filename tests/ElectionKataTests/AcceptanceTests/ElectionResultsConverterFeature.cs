using System;
using CoreBDD;
using CoreBDD.SpecGeneration;
using ElectionKata;

namespace ElectionKataTests.AcceptanceTests
{
    [Feature(nameof(ElectionResultsConverter),
        @"As an election data analyst
          Given a short hand version of the election results          
          I want the election results converted to a specific format")]
    public class ElectionResultsConverterFeature : Specification, IDisposable
    {
        public void Dispose()
        {
            GenerateSpecs.OutputFeatureSpecs(this.GetType().Assembly.Location, @"..\..\..\Specs\");
        }
    }
}
