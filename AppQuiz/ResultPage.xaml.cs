namespace AppQuiz;

public partial class ResultPage : ContentPage
{
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
		champ.Source = "win.png";
	}
}