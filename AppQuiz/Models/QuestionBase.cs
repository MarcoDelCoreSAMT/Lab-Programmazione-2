using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    // classe astratta
    internal abstract class QuestionBase
    {
        // === CAMPI E PROPRIETÀ ===

        private string _text; // "_" utilizzato nella notazione per le variabili private

        // shortcut per utilizzare attr private aggiungendo get e set ("propfull" + tab)
        // si possono fare controlli di plausbilità del dato

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        

        private int _points;

        public int Points
        {
            get { return _points; }
            set 
            {
                if (value < 0)
                {
                    _points = 0;
                }
                else 
                {
                    _points = value;
                }   
            }
        }

        // Immagine per domanda
        private string _image;

        public string Immagine
        {
            get { return _image; }
            set { _image = value; }
        }



        // === COSTRUTTORE ===
        public QuestionBase(string text, int points, string image) 
        {
            _text = text;
            _points = points;
            _image = image;
        }

        // metodi astratti da riferimento
        public abstract bool CheckAnswer(bool userAnswer);
    }
}
