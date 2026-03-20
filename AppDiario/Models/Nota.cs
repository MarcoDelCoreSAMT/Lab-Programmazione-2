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
				// Rimuovi controllo qua se si vuole che si mostri l'alert dell'errore
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
			set 
			{
				if (String.IsNullOrEmpty(value)) 
				{
					value = " - ";
				}
				_testo = value; 
			}
		}

        // Converte un oggetto Nota in una stringa CSV da scrivere sul file
        public string daOggettoARiga()
        {
            return this.Titolo + ";" + this.Testo;
        }

        // Converte una stringa CSV in un oggetto Nota
        // static: si chiama sulla classe, NON su un'istanza ==> Nota.DaRigaAOggetto(riga)
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
