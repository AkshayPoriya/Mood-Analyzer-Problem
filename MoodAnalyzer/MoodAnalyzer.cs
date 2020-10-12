﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        private string message;

        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        public string AnalyseMood()
        {
            if (this.message.ToLower().Contains("sad"))
            {
                return "sad";
            }
            return "happy";
        }
    }
}