using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace MoodAnalyzerMSTest
{
    [TestClass]
    public class MoodAnalyzerTest
    {
        private MoodAnalyzer moodAnalyzer = null;
        
        [TestInitialize]
        public void InitialSetUp()
        {
            moodAnalyzer = new MoodAnalyzer("sad");
        }

        [TestMethod]
        [DataRow("I am in sad mood!")]
        public void GivenSad_ReturnSad(string message)
        {
            //Arrange
            moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyseMood();
            string expected = "sad";
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("I am in any mood!")]
        public void GivenAnyMood_ReturnHappy(string message)
        {
            //Arrange
            moodAnalyzer = new MoodAnalyzer(message);
            //Act
            string actual = moodAnalyzer.AnalyseMood();
            string expected = "happy";
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
