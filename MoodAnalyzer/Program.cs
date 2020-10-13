using System;
using System.Reflection;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ///Change Field With Reflection
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in sad mood!"); //This instance can also be created with Reflection
                // Meta information of MoodAnalyzer
                var moodAnalyzerType = typeof(MoodAnalyzer);
                // Meta information of messageField 
                //GetField Returns an object that represents the field with the specified name, if found; otherwise, null.
                var messageField = moodAnalyzerType.GetField("message", BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine("Initial message was : "+messageField.GetValue(moodAnalyzer));
                Console.WriteLine($"Mood was {moodAnalyzer.AnalyseMood()}!");
                messageField.SetValue(moodAnalyzer,"I am in happy mood!");
                Console.WriteLine("Current message is : " + messageField.GetValue(moodAnalyzer));
                Console.WriteLine($"Mood is {moodAnalyzer.AnalyseMood()}!");
            }
            catch(MoodAnalyzerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
