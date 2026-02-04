namespace AppConvertitore
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {   
            // Costruttore: inizializza i componenti grafici
            InitializeComponent();
        }

        private void btnConverti_Clicked(object sender, EventArgs e)
        {
            string valoreImporto = entConversione.Text;
            if (string.IsNullOrEmpty(valoreImporto)) {
                return;
            }
            try
            {
                double franchi = Convert.ToDouble(valoreImporto);
                if (franchi > 0)
                {
                    double euro = franchi * 1.07;
                    lblRisultato.Text = string.Format("Risultato: {0:F2} €", euro);
                    lblRisultato.TextColor = Colors.Black;
                }
                else
                {
                    visualizzaErrore();
                }
            }
            catch (Exception ex)
            {
                visualizzaErrore();
            }
        }

        public void visualizzaErrore()
        {
            lblRisultato.Text = "Errore: inserire un valore numerico positivo.";
            lblRisultato.TextColor = Colors.Red;
        }

        private void BtnReset_Clicked(object sender, EventArgs e)
        {
            entConversione.Focus();
            entConversione.Text = "";
            lblRisultato.Text = "Pronto per convertire";
        }
    }

}
