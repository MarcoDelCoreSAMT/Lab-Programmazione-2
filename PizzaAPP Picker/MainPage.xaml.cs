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
            pizze.Add(new Zappi("Margherita", 10, "margherits.png", "Pomodoro - Mozzarella"));
            pizze.Add(new Zappi("Prosciutto", 14, "bizzaprosciuts.png", "Pomodoro - Mozzarella - Prosciutto - Pomodorini"));
            pizze.Add(new Zappi("Orrenda", 67, "surprais.png", "Preferisco non specificarlo..."));

            PizzaPicker.ItemsSource = pizze;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Zappi selectedPizza = (Zappi)PizzaPicker.SelectedItem;

            imgPizza.Source = selectedPizza.Image;
            lbPizzaNome.Text = selectedPizza.Nome;
            lbPizzaPrezzo.Text = selectedPizza.Prezzo.ToString() + " Fr.-";
            lbIngredienti.Text = selectedPizza.Ingredienti;
        }
    }

}
