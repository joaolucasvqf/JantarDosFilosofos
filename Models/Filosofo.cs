using System.Threading;

namespace JantarDosFolósofos.Models
{
    class Filosofo
    {
        public bool EstaPensando { get; set; }
        public Garfo GarfoDireito { get; set; }
        public Garfo GarfoEsquerdo { get; set; }
        public int TempoComendo { get; set; }
        public int TempoPensando { get; set; }
        public Filosofo(Garfo garfoDireito, Garfo garfoEsquerdo, int _tempoComendo, int _tempoPensando)
        {
            EstaPensando = true;
            GarfoDireito = garfoDireito;
            GarfoEsquerdo = garfoEsquerdo;
            TempoComendo = _tempoComendo;
            TempoPensando = _tempoPensando;
        }
        public void Comer()
        {
            Thread.Sleep(TempoPensando);
            while (true) 
            {
                while (GarfoDireito.EstaEmUso || GarfoEsquerdo.EstaEmUso)
                {
                    EstaPensando = true;
                }

                GarfoDireito.EstaEmUso = true;
                GarfoEsquerdo.EstaEmUso = true;
                EstaPensando = false;
                Thread.Sleep(TempoComendo);
                EstaPensando = true;
                GarfoDireito.EstaEmUso = false;
                GarfoEsquerdo.EstaEmUso = false;
                Thread.Sleep(TempoPensando);
            }
        }
    }
}
