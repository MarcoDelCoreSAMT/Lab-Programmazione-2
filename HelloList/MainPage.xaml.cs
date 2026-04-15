using HelloList.Model;
using System.Collections.Generic;

namespace HelloList
{
    public partial class MainPage : ContentPage
    {
        // Lista di stringhe
        // List<string> frutti; 

        // Lista di oggetti Frutto
        List<Frutto> frutti;

        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            frutti = new List<Frutto>();
            frutti.Add(new Frutto("Mela", "Italia"));
            frutti.Add(new Frutto("Kiwi", "Groelandia"));
            frutti.Add(new Frutto("Banana", "Spagna"));

            // frutti.Remove("Mela"); --> x lista di stringhe 

            // frutti.Insert(2, "Ananas"); --> x lista di stringhe

            // Rimuoverebbe Kiwi
            frutti.RemoveAt(0);
            // Popolo l'item source col Picker (ListView con la lista di frutti)
            pickFrutti.ItemsSource = frutti;
        }
    }

}
