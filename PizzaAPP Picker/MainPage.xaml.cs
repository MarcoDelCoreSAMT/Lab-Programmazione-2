using PizzaAPP_Picker.Models;

namespace PizzaAPP_Picker
{
    public partial class MainPage : ContentPage
    {
        List<Zappi> pizze;
        public MainPage()
        {
            InitializeComponent();
            ShowGUI();
        }

        private void ShowGUI()
        {
            pizze = new List<Zappi>();
            pizze.Add(new Zappi("Margherita", 10, "dotnet_bot.png", "Carlino - Peppa Pig"));
            pizze.Add(new Zappi("Prosciutto", 14, "dotnet_bot.png", "Carco Del More - Culatello di zibello"));
            pizze.Add(new Zappi("Bohdan", 67, "dotnet_bot.png", "Tartufo - Insulina - boh...(dan)"));

            PizzaPicker.ItemsSource = pizze;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Zappi selectedPizza = (Zappi)PizzaPicker.SelectedItem;

            lbPizzaNome.Text = selectedPizza.Nome;
            lbPizzaPrezzo.Text = selectedPizza.Prezzo.ToString() + "Fr.-";
        }
    }

}
