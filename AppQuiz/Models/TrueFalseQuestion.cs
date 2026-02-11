using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
	// ":" indica ereditarietà (estende/specializza la classe base)
	internal class TrueFalseQuestion : QuestionBase
	{
		private bool _correctAnswer;

		public bool CorrectAnswer
		{
			get { return _correctAnswer; }
			set { _correctAnswer = value; }
		}

        // in c# non ce super() come in java, ma si può chiamare il costruttore della classe base con "base()"
        public TrueFalseQuestion(string text, int points, bool correctAnswer, string image) : base(text, points, image)
		{
            CorrectAnswer = correctAnswer;
        }

		// no notation "@Override", ma direttamente il nome
        public override bool CheckAnswer(bool userAnswer)
        {
			return userAnswer == CorrectAnswer;
        }
    }
}
