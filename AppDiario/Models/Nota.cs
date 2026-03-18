using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiario.Models
{
    // La classe contiene un titolo e un testo
    internal class Nota
    {
		private string _titolo;

		public string Titolo
		{
			get { return _titolo; }
			set 
			{
				if (String.IsNullOrEmpty(value)) 
				{ 
					value = "sconosciuto";
                }
				_titolo = value;
			}
		}

        private string _testo;

        public string Testo
		{
			get { return _testo; }
			set { _testo = value; }
		}

        public string daOggettoARiga()
        {
            return this.Titolo + ";" + this.Testo;
        }

		// ritorna un oggetto Nota
		public static Nota daRigaAOggetto(string riga)
		{
			string[] parti = riga.Split(';');
			if (parti.Length < 2) { return null; }

			Nota nuovaNota = new Nota();
			nuovaNota.Titolo = parti[0]; // La prima parte è il titolo
			nuovaNota.Testo = parti[1]; // La seconda parte è il testo
			return nuovaNota;
		}
	}
}
