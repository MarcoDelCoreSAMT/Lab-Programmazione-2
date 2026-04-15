using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAPP_Picker.Models
{
    internal class Zappi
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private float _prezzo;

        public float Prezzo
        {
            get { return _prezzo; }
            set { _prezzo = value; }
        }

        private String _image;

        public String Image
        {
            get { return _image; }
            set { _image = value; }
        }

        private String _ingredienti;

        public String Ingredienti
        {
            get { return _ingredienti; }
            set { _ingredienti = value; }
        }

        public Zappi(string nome, float prezzo, string image, string ingredienti)
        {
            Nome = nome;
            Prezzo = prezzo;
            Image = image;
            Ingredienti = ingredienti;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
