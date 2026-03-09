namespace AppQuiz;

public partial class ResultPage : ContentPage
{

	// Percorso dove leggere e salvare il file txt, in questo caso per il punteggio migliore
	private static readonly string _filePath = Path.Combine(
		FileSystem.AppDataDirectory, "bestscore.txt");

    int _score = 0;
	public ResultPage(int score)
	{
		// la variabile nasce e muore nel costruttore, da assegnare o da rendere globale
		_score = score;
		InitializeComponent();
		
        ShowGUI();
    }

	// variabile globalizzata
	private void ShowGUI() 
	{
        lblScore.Text = _score.ToString();

        var best = LoadBestScore();

        BestScoreLabel.Text =
            $"{best.name} - {best.score} punti ({best.date})";

        champ.Source = "win.png";
	}

    private async void OnRestart_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

	private void SaveBestScore(string name, int score) 
	{
        // Allochiamo lo score estrapolato dal file txt nella variabile best
        var best = LoadBestScore();

        // Se score del giocatore è maggiore di best (già salvato), allora abbiamo un nuovo record da salvare
        if (score > best.score)
		{
			try 
			{
                string today = DateTime.Now.ToString("yyyy-MM-dd");
                string line = $"{name};{score};{today}";

                File.WriteAllText(_filePath, line);

            } catch (Exception e) 
			{
				DisplayAlert("Errore", "Impossibile salvare: " + e.Message, "OK");
            }
		}
    }

    private (string name, int score, string date) LoadBestScore()
    {
        if (!File.Exists(_filePath))
            return ("Nessuno", 0, "-");

        try
        {
            string content = File.ReadAllText(_filePath);
            string[] parts = content.Split(';');

            if (parts.Length == 3)
            {
                string name = parts[0];
                int score = int.Parse(parts[1]);
                string date = parts[2];

                return (name, score, date);
            }
        }
        catch
        {
            DisplayAlert("Errore", "Il file potrebbe essere corrotto, non esistente o con valori sbagliati", "OK");
        }

        return ("Errore", 0, "-");
    }

    private async void OnSave_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;

        if (string.IsNullOrWhiteSpace(name))
        {
            await DisplayAlert("Errore", "Inserisci un nome valido", "OK");
            return;
        }

        SaveBestScore(name, _score);

        ShowGUI();
    }
}