using System;

namespace MoodAnalyzerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MoodAnalyzer moodAnalyzer = new MoodAnalyzer("");
                Console.WriteLine($"Mood is {moodAnalyzer.AnalyseMood()}!");
            }
            catch(MoodAnalyzerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
