using Pianeti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pianeti_moto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Planetario p;

        List<Color> colori;

        const double G = 6.674;

        const double t = 0.02;

        private void Form1_Load(object sender, EventArgs e)
        {
            p = new Planetario();
            p.Pianeti = new List<Pianeta>();

            colori = new List<Color> { Color.Red, Color.Yellow, Color.Green, Color.Orange, Color.Purple };

            this.BackgroundImageLayout = ImageLayout.Stretch;

            Pianeta a = new Pianeta("a",5000, new Vettore(300, 300), new Vettore(12,0));
            a.Accelerazione = new Vettore(0,0);

            Pianeta b = new Pianeta("b", 5000, new Vettore(300, 400), new Vettore(-12,0));
            b.Accelerazione = new Vettore(0, 0);

            Pianeta c = new Pianeta("c", 1000, new Vettore(1100,400), new Vettore(-15,0));
            c.Accelerazione = new Vettore(0, 0);

            p.Pianeti.Add(a);
            p.Pianeti.Add(b);
            p.Pianeti.Add(c);

            Random random= new Random();

            for (int i = 0; i < p.Pianeti.Count; i++)
            {
                p.Pianeti[i].Colore = colori[random.Next(4)];
            }
        }

        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < p.Pianeti.Count; i++)
            {
                for (int j = 0; j < p.Pianeti.Count; j++)
                {
                    if (i != j)
                    {
                        double acc = (G * p.Pianeti[j].Massa) / ((p.Pianeti[i].Posizione - p.Pianeti[j].Posizione).Modulo() * (p.Pianeti[i].Posizione - p.Pianeti[j].Posizione).Modulo());

                        Vettore v = (p.Pianeti[j].Posizione - p.Pianeti[i].Posizione) / (p.Pianeti[j].Posizione - p.Pianeti[i].Posizione).Modulo();

                        p.Pianeti[i].Accelerazione += v * acc;
                    }
                }
            }

            for (int i = 0; i < p.Pianeti.Count; i++)
            {
                p.Pianeti[i].Posizione = p.Pianeti[i].Posizione + p.Pianeti[i].Velocita * t + p.Pianeti[i].Accelerazione * t * t * 0.5;

                p.Pianeti[i].Velocita = p.Pianeti[i].Velocita + p.Pianeti[i].Accelerazione * t;

                p.Pianeti[i].Accelerazione.X = 0;
                p.Pianeti[i].Accelerazione.Y = 0;
            }

            cont++;

            if (cont == 30)
            {
                Graphics a = this.CreateGraphics();
                p.StampaPlanetario(a);
                cont = 0;
            }
        }
    }
}
