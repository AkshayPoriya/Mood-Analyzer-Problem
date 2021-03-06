using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;
using System;
using System.Reflection;

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

        [TestMethod]
        [DataRow(null)]
        public void GivenNullMood_ThrowCustomException(string message)
        {
            try
            {
                //Arrange
                moodAnalyzer = new MoodAnalyzer(message);
            }
            catch(MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "Mood Should not be null!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("")]
        public void GivenEmptyMood_ThrowCustomException(string message)
        {
            try
            {
                //Arrange
                moodAnalyzer = new MoodAnalyzer(message);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "Mood Should not be empty!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer")]
        public void GivenClassName_CreateDefaultObjectUsingReflection(string className, string constructorName)
        {
            //Arrange
            //Act
            object expected = new MoodAnalyzer();
            object actual = MoodAnalyzerReflection.CreateMoodAnalyzerObject(className, constructorName);
            //Assert
            Assert.AreEqual(expected.GetType(), actual.GetType()); // To check if both objects are of same type
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1")]
        public void GivenClassNameImproper_DefaultConstructorThrowNoSuchClassException(string className, string constructorName)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerReflection.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch(MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "No such class exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer1")]
        public void GivenConstructorNameImproper_DefaultConstructorThrowNoSuchMethodException(string className, string constructorName)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerReflection.CreateMoodAnalyzerObject(className, constructorName);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "No such constructor exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer","I am in Sad Mood", "sad")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "I am in Happy Mood", "happy")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", "", "Mood Should not be empty!")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", null, "Mood Should not be null!")]
        public void GivenClassName_CreateParamterizedObjectUsingReflection(string className, string constructorName, string message, string expected)
        {
            try
            {
                //Arrange
                moodAnalyzer = (MoodAnalyzer)MoodAnalyzerReflection.CreateMoodAnalyzerObject(className, constructorName, message);
                //Act
                string actual = moodAnalyzer.AnalyseMood();
                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", "I am in Sad Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", "I am in Happy Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", "")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer1", null)]
        public void GivenClassNameImproper_ParameterizedConstructorThrowNoSuchClassException(string className, string constructorName, string message)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerReflection.CreateMoodAnalyzerObject(className, constructorName, message);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "No such class exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", "I am in Sad Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", "I am in Happy Mood")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", "")]
        [DataRow("MoodAnalyzerProblem.MoodAnalyzer1", "MoodAnalyzer", null)]
        public void GivenConstructorNameImproper_ParameterizedConstructorThrowNoSuchMethodException(string className, string constructorName, string message)
        {
            try
            {
                //Arrange
                object actual = MoodAnalyzerReflection.CreateMoodAnalyzerObject(className, constructorName, message);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                string expected = "No such constructor exist!";
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("AnalyseMood", "i am in any mood","happy")]
        [DataRow("AnalyseMood", "i am in sad mood","sad")]
        [DataRow("AnalyseMood", "", "Mood Should not be empty!")]
        [DataRow("AnalyseMood", null, "Mood Should not be null!")]
        public void GivenProperName_InvokeAnalyseMoodWithReflection(string methodName, string message, string expected)
        {
            try
            {
                //Arrange
                //Act
                string actual = MoodAnalyzerReflection.InvokeAnalyseMood(methodName, message);
                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch(MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("AnalyseMod", "i am in any mood", "No such method exist!")]
        [DataRow("AnalyseMoood", "i am in sad mood", "No such method exist!")]
        [DataRow("AnalyzeMood", "", "No such method exist!")]
        [DataRow("AnalyseMood1", null, "No such method exist!")]
        public void GivenImproperName_ThrowNoSuchMethodExceptionWhileInvokingMethod(string methodName, string message, string expected)
        {
            try
            {
                //Arrange
                //Act
                string actual = MoodAnalyzerReflection.InvokeAnalyseMood(methodName, message);
                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [DataRow("message", "any mood", "happy")]
        [DataRow("message", "sad mood", "sad")]
        [DataRow("message", "", "Mood Should not be empty!")]
        [DataRow("message", null, "Mood Should not be null!")]
        [DataRow("message1", "any mood", "No such method exist!")]
        [DataRow("messages", "sad mood", "No such method exist!")]
        public void TestSetFieldFunction(string fieldName, string message, string expected)
        {
            try
            {
                //Arrange
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
                moodAnalyzer = (MoodAnalyzer)MoodAnalyzerReflection.SetField(moodAnalyzer, fieldName, message);
                //Act
                string actual = moodAnalyzer.AnalyseMood();
                //Assert
                Assert.AreEqual(expected, actual);
            }
            catch(MoodAnalyzerException ex)
            {
                //Act
                string actual = ex.Message;
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
