using JantarDosFolósofos.Models;
using System;
using System.Threading;

namespace JantarDosFolósofos
{
    class Program
    {
        //Declaração das variáveis "filósofos"
        static Filosofo filosofo1;
        static Filosofo filosofo2;
        static Filosofo filosofo3;
        static Filosofo filosofo4;
        static Filosofo filosofo5;
        static void Main(string[] args)
        {
            //Inicialização dos semáforos
            Semaphore Semaforo1 = new Semaphore(1, 1);
            Semaphore Semaforo2 = new Semaphore(1, 1);
            Semaphore Semaforo3 = new Semaphore(1, 1);
            Semaphore Semaforo4 = new Semaphore(1, 1);
            Semaphore Semaforo5 = new Semaphore(1, 1);
            Console.WriteLine("Bem vindo ao Jantar dos filósofos, aperte qualquer tecla para iniciar a simulação!");
            Console.ReadLine();
            //Inicialização dos Garfos que serão utilizados pelos filósofos
            Garfo garfo1 = new Garfo();
            Garfo garfo2 = new Garfo();
            Garfo garfo3 = new Garfo();
            Garfo garfo4 = new Garfo();
            Garfo garfo5 = new Garfo();
            //Inicialização dos filósofos
            Random r = new Random();
            filosofo1 = new Filosofo(garfo1, garfo2, r.Next(2000, 5000), Semaforo1, Semaforo2);
            filosofo2 = new Filosofo(garfo2, garfo3, r.Next(2000, 5000), Semaforo3, Semaforo2);
            filosofo3 = new Filosofo(garfo3, garfo4, r.Next(2000, 5000), Semaforo3, Semaforo4);
            filosofo4 = new Filosofo(garfo4, garfo5, r.Next(2000, 5000), Semaforo5, Semaforo4);
            filosofo5 = new Filosofo(garfo5, garfo1, r.Next(2000, 5000), Semaforo5, Semaforo1);

            Start();          
        }
        static void Start()
        {
            //Criação das Threads
            Thread threadFilosofo1 = new Thread(new ThreadStart(filosofo1.Comer));
            Thread threadFilosofo2 = new Thread(new ThreadStart(filosofo2.Comer));
            Thread threadFilosofo3 = new Thread(new ThreadStart(filosofo3.Comer));
            Thread threadFilosofo4 = new Thread(new ThreadStart(filosofo4.Comer));
            Thread threadFilosofo5 = new Thread(new ThreadStart(filosofo5.Comer));
            //Inicialização da simulação
            while (true)
            {
                if (!threadFilosofo1.IsAlive)
                {
                    threadFilosofo1 = new Thread(new ThreadStart(filosofo1.Comer));
                    threadFilosofo1.Start();
                }
                if (!threadFilosofo2.IsAlive)
                {
                    threadFilosofo2 = new Thread(new ThreadStart(filosofo2.Comer));
                    threadFilosofo2.Start();

                }
                if (!threadFilosofo3.IsAlive)
                {
                    threadFilosofo3 = new Thread(new ThreadStart(filosofo3.Comer));
                    threadFilosofo3.Start();
                }
                if (!threadFilosofo4.IsAlive)
                {
                    threadFilosofo4 = new Thread(new ThreadStart(filosofo4.Comer));
                    threadFilosofo4.Start();
                }
                if (!threadFilosofo5.IsAlive)
                {
                    threadFilosofo5 = new Thread(new ThreadStart(filosofo5.Comer));
                    threadFilosofo5.Start();
                }
                    SituacaoDaMesa();
            }
        }
        static void SituacaoDaMesa()
        {
            Console.WriteLine("Situação atual da mesa: ");
            Console.WriteLine("Filósofo 1 está " + (filosofo1.EstaPensando ? "pensando" : "comendo"));
            Console.WriteLine("Filósofo 2 está " + (filosofo2.EstaPensando ? "pensando" : "comendo"));
            Console.WriteLine("Filósofo 3 está " + (filosofo3.EstaPensando ? "pensando" : "comendo"));
            Console.WriteLine("Filósofo 4 está " + (filosofo4.EstaPensando ? "pensando" : "comendo"));
            Console.WriteLine("Filósofo 5 está " + (filosofo5.EstaPensando ? "pensando" : "comendo"));
            Console.WriteLine("------------------------------");
            Thread.Sleep(3000);
        }
    }
}
