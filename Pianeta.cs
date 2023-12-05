using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pianeti
{
    internal class Pianeta
    {
        public double Massa { get; set; }

        public System.Drawing.Color Colore { get; set; }

        public Vettore Posizione { get; set; }

        public string Nome { get; set; }
        public Vettore Velocita { get; set; }

        public Vettore Accelerazione { get; set; }

        public Pianeta(string nome, double massa, Vettore posizione, Vettore velocita)
        {
            Nome = nome;
            Massa = massa;
            Posizione = posizione;
            Velocita = velocita;
        }

        public Pianeta() { }
    }
}
