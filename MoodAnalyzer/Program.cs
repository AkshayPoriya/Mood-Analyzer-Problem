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
                //Creating instance of MoodAnalyzer using Reflection
                MoodAnalyzer moodAnalyzer = (MoodAnalyzer)MoodAnalyzerFactory.CreateMoodAnalyzerObject("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer","sad");
                Console.WriteLine($"Mood is {moodAnalyzer.AnalyseMood()}!");
            }
            catch(MoodAnalyzerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
