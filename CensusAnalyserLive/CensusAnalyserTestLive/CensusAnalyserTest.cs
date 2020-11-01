using NUnit.Framework;
using System.Collections.Generic;
using CensusAnalyserLive;
using CensusAnalyserLive.DTO;
using static CensusAnalyserLive.CensusAnalyser;
namespace CensusAnalyserTestLive
{
    public class CensusAnalyserTest
    {
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodeFilePath = @"C:\Users\Sammy Striker\source\repos\CensusAnalyserLive\CensusAnalyserTestLive\CSVFiles\IndiaStateCode.csv";
        static string indianStateWrongFilePath = @"WrongIndiaStateCodeData.csv";
        static string indianStateWrongTypeFilePath = @"C:\Users\Sammy Striker\source\repos\CensusAnalyserLive\CensusAnalyserTestLive\CSVFiles\IndiaStateCode.txt";
        static string indianStateIncorrectDelimiterFilePath = @"C:\Users\Sammy Striker\source\repos\CensusAnalyserLive\CensusAnalyserTestLive\CSVFiles\DelimiterIndiaStateCode.csv";
        static string indianStateIncorrectHeaderFilePath = @"C:\Users\Sammy Striker\source\repos\CensusAnalyserLive\CensusAnalyserTestLive\CSVFiles\WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateWrongTypeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectDelimiterFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateIncorrectHeaderFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}