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
            Console.WriteLine("Bem vindo ao Jantar dos filósofos!");
            //Inicialização dos Garfos que serão utilizados pelos filósofos
            Garfo garfo1 = new Garfo();
            Garfo garfo2 = new Garfo();
            Garfo garfo3 = new Garfo();
            Garfo garfo4 = new Garfo();
            Garfo garfo5 = new Garfo();
            //Inicialização dos filósofos
            Random r = new Random();
            filosofo1 = new Filosofo(garfo1, garfo2, 1,1);
            filosofo2 = new Filosofo(garfo2, garfo3, 1,1);
            filosofo3 = new Filosofo(garfo3, garfo4, 1,1);
            filosofo4 = new Filosofo(garfo4, garfo5, 1,1);
            filosofo5 = new Filosofo(garfo5, garfo1, 1,1);

            IniciarJantar();          
        }
        static void IniciarJantar()
        {
            //Criação das Threads
            Thread threadFilosofo1 = new Thread(new ThreadStart(filosofo1.Comer));
            Thread threadFilosofo2 = new Thread(new ThreadStart(filosofo2.Comer));
            Thread threadFilosofo3 = new Thread(new ThreadStart(filosofo3.Comer));
            Thread threadFilosofo4 = new Thread(new ThreadStart(filosofo4.Comer));
            Thread threadFilosofo5 = new Thread(new ThreadStart(filosofo5.Comer));
            //Inicialização da simulação
            threadFilosofo1.Start();
            threadFilosofo2.Start();
            threadFilosofo3.Start();
            threadFilosofo4.Start();
            threadFilosofo5.Start();
            while (true)
            {
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
            Thread.Sleep(1000);
        }
    }
}
