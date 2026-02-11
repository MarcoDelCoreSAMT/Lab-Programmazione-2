using AppQuiz.Models;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;

        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("C# è un linguaggio ad oggetti?", 10, true, "https://it.wikipedia.org/wiki/File:C_Sharp_Logo_2023.svg"));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 15, false, "https://www.python.org/community/logos/"));
            ShowQuestion();
        }

        // L'evento porta con se il sender che è il button
        private void OnAnswer_Clicked(object sender, EventArgs e)
        {
            // Downcast a bottone, controlla se è True o False 
            Button btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                DisplayAlert("Giusto!", "Bravo hai risposto correttamente!.", "GODO");
            }
            else {
                DisplayAlert("Errato!", "Risposta sbagliata...", "Accidenti...");
            }
                _currentIndex++;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            // Controlla se ci sono ancora domande dentro la lista da mostrare
            if (_currentIndex < _questions.Count)
            {
                // creo un oggetto Question che contiene la domanda corrente
                QuestionBase current = _questions[_currentIndex];
                QuestionImage.Source = current.Immagine; 
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punteggio: {_score}";
            }
            else
            {
                QuestionTextLabel.Text = $"Quiz completato!\nPunteggio finale: {_score}/25";
                QuestionImage.Source = "https://tenor.com/search/ok-emoji-gifs";
                TrueButton.IsEnabled = FalseButton.IsEnabled = false;
            }
        }

    }

}
