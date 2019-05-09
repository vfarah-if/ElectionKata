# This file is auto-generated, any changes made to this file will be lost


Feature: ElectionResultsConverter
	As an election data analyst
          Given a short hand version of the election results          
          I want the election results converted to a specific format

Scenario: Convert small subset of election results to an expected format
			Given an election result converter
			When I receive '" + TestData.SmallInput + "'
			Then the data should be converted to '" + TestData.SmallInputExpectedResult + "'

Scenario: Convert full election results to an expected format
			Given an election result converter
			When I receive '" + TestData.LargeInput + "'
			Then the data should be converted to '" + TestData.LargeInputExpectedResult + "'