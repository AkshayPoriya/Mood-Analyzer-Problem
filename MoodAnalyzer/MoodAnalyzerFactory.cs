using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerFactory
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
    }
}
