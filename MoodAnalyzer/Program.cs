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
                //Calling AnalyseMood using Reflection
                string mood = MoodAnalyzerReflection.InvokeAnalyseMood("AnalyseMood", "i am in any mood!");
                Console.WriteLine($"Mood is {mood}!");
            }
            catch(MoodAnalyzerException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
