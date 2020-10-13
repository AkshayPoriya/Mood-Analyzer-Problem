using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        private string message;

        public MoodAnalyzer()
        {
            message = "";
        }
        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        
        // This function analyze mood, return sad if string contains sad
        // if string is empty throw a custom exception indicating mood should not be empty
        // if string is null then also throw a custom exception showing mood should not be null
        // else return happy
        public string AnalyseMood()
        {
            try
            {
                if (this.message.Equals(""))
                {
                    throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.EMPTY, "Mood Should not be empty!");
                }
                if (this.message.ToLower().Contains("sad"))
                {
                    return "sad";
                }
                return "happy";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyzerException(MoodAnalyzerException.ExceptionType.NULL, "Mood Should not be null!");
            }
        }
    }
}
