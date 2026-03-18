using AppDiario.Models;

namespace AppDiario
{
    public partial class MainPage : ContentPage
    {
        // Percorso del file dove salvare le note - calcolato una sola volta
        // %appdata% local package com.companyAppDiario LocalState note.txt
        string percorsoFile = Path.Combine(
            FileSystem.AppDataDirectory,
            "note.txt"
        );

        public MainPage()
        {
            InitializeComponent(); // Carica lo XAML
        }

        private async void OnSalvaClicked(object sender, EventArgs e)
        {
            Nota nuovaNota = new Nota();

            nuovaNota.Titolo = EntTitolo.Text;
            nuovaNota.Testo = EntTesto.Text;

            if (string.IsNullOrEmpty(nuovaNota.Titolo))
            {
                await DisplayAlert("NO!",
                    "Dai per favore metti almeno il titolo", "Eh ok");
                return; // interrompe il metodo
            }

            // Serializza oggetto --> string CSV
            string rigaDaScrivere = nuovaNota.daOggettoARiga();

            // Scrive sul file (aggiunge in fondo)
            File.AppendAllText( percorsoFile,
                rigaDaScrivere + Environment.NewLine);

            // Pulisce i campi di input
            EntTitolo.Text = "";
            EntTesto.Text = "";

            // Conferma 
            await DisplayAlert("Bom!", "l'hai salvata bene!", "garzie");
        }

        private void OnLeggiClicked(object sender, EventArgs e)
        {

        }
    }

}
