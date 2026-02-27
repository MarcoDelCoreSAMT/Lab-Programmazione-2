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
            _questions.Add(new OpenQuestion("Qual'è il nome per il framework Microsoft per app cross-platform", 20, ".NET MAUI", "freimuork.png"));
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

                if (current is TrueFalseQuestion)
                {
                    TrueButton.IsVisible = FalseButton.IsVisible = true;
                    OpenAnswerEntry.IsVisible = false;
                    SubmitOpenButton.IsVisible = false;
                }
                else if (current is OpenQuestion)
                {
                    TrueButton.IsVisible = FalseButton.IsVisible = false;
                    OpenAnswerEntry.IsVisible = true;
                    SubmitOpenButton.IsVisible = true;
                }
                else
                {
                    QuestionImage.Source = "fineciao.png";
                    OpenAnswerEntry.IsVisible = false;
                    SubmitOpenButton.IsVisible = false;
                    TrueButton.IsEnabled = FalseButton.IsEnabled = false;
                    QuestionImage.IsEnabled = false;
                    QuestionTextLabel.Text = "Fine";
                    ScoreLabel.Text = "";
                    btnResult.IsEnabled = true;
                }
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

        private async void SubmitOpenButton_Clicked(object sender, EventArgs e)
        {
            OpenQuestion current = (OpenQuestion)_questions[_currentIndex];

            if (current.CheckOpenAnswer(OpenAnswerEntry.Text))
            {
                _score += current.Points;
                await DisplayAlert("Corretto!", "Risposta giusta!", "OK");
            }
            else
            {
                await DisplayAlert("Errore", "Risposta sbagliata", "OK");
            }

            OpenAnswerEntry.Text = "";
            _currentIndex++;
            QuestionImage.Source = "fineciao.png";
            OpenAnswerEntry.IsVisible = false;
            SubmitOpenButton.IsVisible = false;
            TrueButton.IsEnabled = FalseButton.IsEnabled = false;
            QuestionImage.IsEnabled = false;
            QuestionTextLabel.Text = "Fine";
            ScoreLabel.Text = "";
            btnResult.IsEnabled = true;
        }
    }

}
