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
            _questions.Add(new TrueFalseQuestion("C# è un linguaggio ad oggetti?", 10, true, "csharp_logo.png"));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 15, false, "python_symbol.png"));
            ShowQuestion();
            btnResult.IsEnabled = false;
        }

        // L'evento porta con se il sender che è il button
        private async void OnAnswer_Clicked(object sender, EventArgs e)
        {
            // Downcast a bottone, controlla se è True o False 
            Button btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Points;
                await DisplayAlert("Giusto!", "Bravo hai risposto correttamente!.", "GODO");
            }
            else {
                await DisplayAlert("Errato!", "Risposta sbagliata...", "Accidenti...");
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
                QuestionImage.Source = "fineciao.png";
                TrueButton.IsEnabled = FalseButton.IsEnabled = false;
                QuestionImage.IsEnabled = false;
                QuestionTextLabel.Text = "Fine";
                ScoreLabel.Text = "";
                btnResult.IsEnabled = true;
            }
        }

        private void btnResult_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }

        private async void OnQuizFinished() 
        {
            // Richiamiamo il metodo PushAsync e gli passiamo il nuovo oggetto ResultPage
            // Attendiamo senza bloccare la pagina grazie ad await e async
            await Navigation.PushAsync(new ResultPage(_score));
        }
    }

}
