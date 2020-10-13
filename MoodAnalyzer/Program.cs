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
                Console.WriteLine($"Initial Mood was {moodAnalyzer.AnalyseMood()}!");
                string newMessage = "I am in happy mood!";
                moodAnalyzer = (MoodAnalyzer)MoodAnalyzerReflection.SetField(moodAnalyzer, "message", newMessage);
                Console.WriteLine($"New Mood is {moodAnalyzer.AnalyseMood()}!");
            }
            catch(MoodAnalyzerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
