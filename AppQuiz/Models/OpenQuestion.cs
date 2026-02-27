using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class OpenQuestion : QuestionBase
    {
        public string CorrectAnswer { get; set; }

        public OpenQuestion(string text, int points, string correctAnswer, string imageSource) : base(text, points, imageSource)
        {
            CorrectAnswer = correctAnswer;
        }

        public override bool CheckAnswer(bool userAnswer)
        {
            // Non usato per le open question
            return false;
        }

        public bool CheckOpenAnswer(string userText)
        {
            if (userText == null)
            {
                 return false;
            }
            else
            {
                return userText.Trim().ToLower() == CorrectAnswer.Trim().ToLower();
            }
        }
    }
}
