using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerReflection
    {
        // className will be in format of namespace.MyClass while constructor name will be MyClass
        public static object CreateMoodAnalyzerObject(string className, string constructorName, string message = "DEfaULT")
        {
            string pattern = @"." + constructorName + "$";
            bool isMatch = Regex.IsMatch(className, pattern);
            // isMatch will be true if constructorName and className are same, they need not be valid
            if (isMatch)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    var typeMoodAnalyzer = assembly.GetType(className);
                    //The Activator.CreateInstance method creates an instance of a type 
                    //defined in an assembly by invoking the constructor that best matches the specified arguments. 
                    //If no arguments are specified then the constructor that takes no parameters, that is, the default constructor, is invoked.
                    if(message == "DEfaULT")
                        return Activator.CreateInstance(typeMoodAnalyzer);
                    else
                        return Activator.CreateInstance(typeMoodAnalyzer, message);


                }
                catch(ArgumentNullException)
                {
                    // Exceptions: System.ArgumentNullException, when type is null.
                    // Catch block will execute when className is not valid, though className and ConstructorName are same
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_CLASS, "No such class exist!");
                }
            }
            else
            {
                //This block will execute when constructorName don't match with className, though any of them can be invalid
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "No such constructor exist!");
            }
        }
        // Invoke method using reflection
        public static string InvokeAnalyseMood(string methodName, string message)
        {
            try
            {
                // First an instance of MoodAnalyzer is created with the help of reflection
                MoodAnalyzer moodAnalyzer = (MoodAnalyzer)MoodAnalyzerReflection.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                // Meta information of MoodAnalyzer
                var moodAnalyzerType = typeof(MoodAnalyzer);
                // Meta information of methodName provided in arguments while calling this function
                //GetMethod Returns an object that represents the public method with the specified name, if found; otherwise, null.
                var analyseMoodMethod = moodAnalyzerType.GetMethod(methodName);
                // Now invoke method using meta information of method, need an instance of class and parameters as arguments
                var mood = analyseMoodMethod.Invoke(moodAnalyzer, null);
                return mood.ToString();
            }
            catch(NullReferenceException)
            {
                // Get methods returns null incase no method is found with given methodName
                // Invoke method will throw exception
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "No such method exist!");
            }
            catch (TargetInvocationException ex)
            {
                // When message is null or empty this exception is thrown
                throw ex.InnerException;
            }
        }

        public static object SetField(MoodAnalyzer moodAnalyzer, string fieldName, string newMessage)
        {
            try
            {
                // Meta information of MoodAnalyzer
                var moodAnalyzerType = typeof(MoodAnalyzer);
                // Meta information of messageField 
                //GetField Returns an object that represents the field with the specified name, if found; otherwise, null.
                var messageField = moodAnalyzerType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
                messageField.SetValue(moodAnalyzer, newMessage);
                return moodAnalyzer;
            }
            catch (NullReferenceException)
            {
                // GetField returns null incase no field is found with given fieldName
                // SetValue method will throw exception
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NO_SUCH_METHOD, "No such method exist!");
            }

        }
    }
}
