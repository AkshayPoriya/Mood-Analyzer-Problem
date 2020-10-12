using System;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer("I am in sad mood");
            Console.WriteLine($"Mood is {moodAnalyzer.AnalyseMood()}!");
        }
    }
}
