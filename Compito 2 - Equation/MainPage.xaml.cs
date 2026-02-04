namespace Compito_2___Equation
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCalcolaCliked(object sender, EventArgs e)
        {
            string valoreA = EntA.Text;
            string valoreB = EntB.Text;
            string valoreC = EntC.Text;

            if (string.IsNullOrWhiteSpace(valoreA))
            {
                return;
            }
            else if (string.IsNullOrWhiteSpace(valoreB))
            {
                return;
            }
            else if (string.IsNullOrWhiteSpace(valoreC))
            {
                return;
            }
            try
            {
                double valA = Convert.ToDouble(valoreA);
                double valB = Convert.ToDouble(valoreB);
                double valC = Convert.ToDouble(valoreC);

                double delta = Math.Pow(valB, 2) - (4 * valA * valC);

                if (delta > 0)
                {
                    double x_1 = (-valB + Math.Sqrt(delta)) / (2 * valA);
                    double x_2 = (-valB - Math.Sqrt(delta)) / (2 * valA);
                    lblRisultato.Text = "Il delta è maggiore di 0.\n\nDi conseguenza:\nx1 = " + x_1 + "\nx2 = " + x_2;
                    lblRisultato.TextColor = Colors.Green;
                }
                else if (delta == 0) {
                    double x = -valB / 2 * valA;
                    lblRisultato.Text = "Il delta è uguale a zero.\n\nDi Conseguenza:\nx = " + x;
                    lblRisultato.TextColor = Colors.Blue;
                }
                else
                {
                    lblRisultato.Text = "Il delta è minore di 0.\nDi conseguenza non esistono soluzioni reali.";
                    lblRisultato.TextColor = Colors.Red;
                }
            } catch (Exception exc) {
                mostraErrore();
            }
        }

        public void mostraErrore()
        {
            lblRisultato.Text = "Errore...\nInserire dei valori numerici.";
            lblRisultato.TextColor = Colors.Red;
        }
    }

}
