using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzerException:Exception
    {
        public enum ExceptionType
        {
            NULL,
            EMPTY,
            NO_SUCH_CLASS,
            NO_SUCH_METHOD
        }
        private ExceptionType type;
        public MoodAnalyzerException(ExceptionType type, string message):base(message)
        {
            this.type = type;
        }
    }
}
