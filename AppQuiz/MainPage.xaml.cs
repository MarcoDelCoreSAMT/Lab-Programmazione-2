using AppQuiz.Models;
using Microsoft.Maui.Controls.Shapes;

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
            btnResult.IsEnabled = false;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_questions.Count == 0)
            {
                await LoadQuestions();
                ShowQuestion();
            }
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
                await DisplayAlert("Giusto!", "Bravo hai risposto correttamente!.", "Avanti");
            }
            else {
                await DisplayAlert("Errato!", "Risposta sbagliata...", "Avanti");
            }
            
            _currentIndex++;
            ShowQuestion();
        }

        private async Task LoadQuestions()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("domande.txt");
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                string line = await reader.ReadLineAsync();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(';');

                string type = parts[0];
                string text = parts[1];
                int points = int.Parse(parts[2]);
                string answer = parts[3];
                string image = parts[4];

                if (type == "TF")
                {
                    bool correct = bool.Parse(answer);

                    _questions.Add(
                        new TrueFalseQuestion(text, points, correct, image)
                    );
                }
                else if (type == "OPEN")
                {
                    _questions.Add(
                        new OpenQuestion(text, points, answer, image)
                    );
                }
            }
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
            OpenQuestion current = _questions[_currentIndex] as OpenQuestion;

            if (current.CheckOpenAnswer(OpenAnswerEntry.Text))
            {
                _score += current.Points;
                await DisplayAlert("Corretto!", "Risposta giusta!", "Avanti");
            }
            else
            {
                await DisplayAlert("Errato!", "Risposta sbagliata", "Avanti");
            }

            OpenAnswerEntry.Text = "";

            _currentIndex++;

            ShowQuestion();
        }

    }

}
