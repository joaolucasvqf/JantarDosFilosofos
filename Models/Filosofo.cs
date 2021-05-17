using System.Threading;

namespace JantarDosFolósofos.Models
{
    class Filosofo
    {
        public bool EstaPensando { get; set; }
        public Garfo Garfo1 { get; set; }
        public Garfo Garfo2 { get; set; }
        public int TempoComendo { get; set; }
        private static Semaphore Semaforo1;
        private static Semaphore Semaforo2;
        public Filosofo(Garfo _garfo1, Garfo _garfo2, int _tempoComendo, Semaphore s1, Semaphore s2)
        {
            EstaPensando = true;
            Garfo1 = _garfo1;
            Garfo2 = _garfo2;
            TempoComendo = _tempoComendo;
            Semaforo1 = s1;
            Semaforo2 = s2;
        }
        public void Comer()
        {
            Semaforo1.WaitOne();
            Semaforo2.WaitOne();

            if (Garfo1.EstaEmUso || Garfo2.EstaEmUso)
            {
                Semaforo1.Release();
                Semaforo2.Release();
                return;
            }

            Garfo1.EstaEmUso = true;
            Garfo2.EstaEmUso = true;
            this.EstaPensando = false;
            Thread.Sleep(TempoComendo);
            this.EstaPensando = true;
            Garfo1.EstaEmUso = false;
            Garfo2.EstaEmUso = false;
            Semaforo1.Release();
            Semaforo2.Release();
        }
    }
}
