using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA220103
{
    internal class JatekosLovese
    {
        private static (float X, float Y) _celtabla;
        private static bool _isCeltablaSet = false;
        public static (float X, float Y) Celtabla
        {
            set
            {
                if (_isCeltablaSet) throw new Exception("futás közben ne baszogasd!");
                _celtabla = value;
                _isCeltablaSet = true;
            }
            get => _celtabla;
        }
        public int Sorszam { get; set; }
        public string Nev { get; set; }
        public (float X, float Y) Loves { get; set; }

        public float Tavolsag => (float)Math.Sqrt(
            Math.Pow(Celtabla.X - Loves.X, 2) +
            Math.Pow(Celtabla.Y - Loves.Y, 2));

        public float Pontszam =>
            (10 - Tavolsag) > 0 ? (float)Math.Round(10 - Tavolsag, 2) : 0F;

        public JatekosLovese(int sorszam, string fileSora)
        {
            Sorszam = sorszam;
            var v = fileSora.Split(';');
            Nev = v[0];
            Loves = (
                X: float.Parse(v[1]),
                Y: float.Parse(v[2]));
        }
    }
}
