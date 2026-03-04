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
		// Salvato prima di ShowGUI così mostra record aggiornato
		SaveBestScore(score);
        ShowGUI();
    }

	// variabile globalizzata
	private void ShowGUI() 
	{
		lblScore.Text = _score.ToString();

        BestScoreLabel.Text = LoadBestScore().ToString();

        champ.Source = "win.png";
	}

    private async void OnRestart_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

	private void SaveBestScore(int score) 
	{
        // Allochiamo lo score estrapolato dal file txt nella variabile best
        int best = LoadBestScore();

        // Se score del giocatore è maggiore di best (già salvato), allora abbiamo un nuovo record da salvare
        if (score > best)
		{
			try 
			{
				File.WriteAllText(_filePath, score.ToString());
            } catch (Exception e) 
			{
				DisplayAlert("Errore", "Impossibile salvare il punteggio" + e.Message, "OK");
            }
		}
    }

	private int LoadBestScore() 
	{
		if (!File.Exists(_filePath)) { 
			return 0;
		}

		// È buona abitudine gestire l'eccezione di lettura/scrittura 
		try
		{
			// Legge il contenuto del file txt
			string content = File.ReadAllText(_filePath);

			//Variabile locale per contenere il best score
			int best;

			if (int.TryParse(content, out best))
			{
				return best;
			}
			else
			{
				DisplayAlert("Errore", "Il file potrebbe essere corrotto, non esistere o non contiene un punteggio valido", "OK");
				return 0; // Se non esiste un punteggio migliore, ritorna 0
			}
		}
		catch (Exception ex) 
		{
			DisplayAlert("Errore", "Impossibile leggere il punteggio" + ex.Message, "OK");
			return 0;
		}
    }
}