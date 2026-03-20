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
            // Creo una nuova nota, leggo le due entry, nasce e muore qua
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
            File.AppendAllText(percorsoFile,
                rigaDaScrivere + Environment.NewLine);

            // Pulisce i campi di input
            EntTitolo.Text = "";
            EntTesto.Text = "";

            // Conferma 
            await DisplayAlert("Bom!", "l'hai salvata bene!", "garzie");
        }

        private void OnLeggiClicked(object sender, EventArgs e)
        {
            // IMPORTANTISSIMA: se il file non esiste, File.ReadAllLines() da errore, quindi prima controllo se esiste.
            if (File.Exists(percorsoFile))
            {
                // legge tutte le righe, ognuna di esse rappresenta un elemento dell'array 
                string[] righe = File.ReadAllLines(percorsoFile);
                editDisplay.Text = ""; // pulisce l'editor

                // cicla l'array delle righe
                foreach (string riga in righe)
                {
                    // riga --> oggetto Nota
                    Nota n = Nota.daRigaAOggetto(riga);
                    if (n != null) // check validità riga
                    { 
                        editDisplay.Text += "TITOLO: " + n.Titolo + "\n\n";
                        editDisplay.Text += "TESTO: " + n.Testo + "\n";
                        editDisplay.Text += "-----------------------\n";
                    }
                }
            }
            else
            {
                editDisplay.Text = "Il file è vuoto o non esiste.";
            }
        }
    }
}
