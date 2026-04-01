using System.Collections.Generic;

namespace HelloList
{
    public partial class MainPage : ContentPage
    {
        List<string> frutti; 

        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            frutti = new List<string>();
            frutti.Add("Mela");
            frutti.Add("Pera");
            frutti.Add("Banana");
            pickFrutti.ItemsSource = frutti;
        }
    }

}
