using ProyectoSistemasOperativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjemploHilos
{
    internal class OsoYAbejas
    {
        int capacidadTarro = 25; // Acepta hasta 25 unidades de miel
        public int capacidadActualTarro = 0; // Es lo que tiene actualmente de unidades de miel
        object sinc = new object(); // object para sincronizar el acceso al tarro
        bool tarroLleno = false; // Indica si el tarro está lleno
        bool tarroVacio = true; // Indica si el tarro está vacío
        public Buffer<int> bufferMiel;
        Form1 form1 = new Form1();
        private ManualResetEvent finalizacionEvento = new ManualResetEvent(false);
        public OsoYAbejas()
        {
            bufferMiel = new Buffer<int>();

            Thread abejas, oso;

            abejas = new Thread(ProductorAbejas);
            oso = new Thread(ConsumidorOso);

            abejas.Start();
            oso.Start();
        }



        public void ProductorAbejas()
        {
            int numAbejas = 9; //Número de abejas
            List<int> miel = new List<int>(); //Lista de enteros que cada abeja producirá de miel
            Random r = new Random();
            Formulario.imprimeTamTarro("Tamaño del tarro: " + capacidadTarro.ToString());
            Formulario.imprimeCantidadDeAbejas("Num de abejas: " + numAbejas.ToString());


            for (int i = 0; i < numAbejas; i++)
            {
                miel.Add(r.Next(1, 6)); // Genera una cantidad aleatoria de miel entre 1 y 5 para cada abeja
            }

            int abeja = 0;
            while (!finalizacionEvento.WaitOne(0)) // Bucle infinito para simular el trabajo continuo de las abejas
            {
                lock (sinc) // Bloquea el acceso al tarro de miel para evitar condiciones de carrera
                {
                    capacidadActualTarro += miel[abeja]; // Añade la cantidad de miel producida por la abeja actual al tarro
                    Formulario.actualizarCapacidadTarro("Capacidad actual del tarro " + capacidadActualTarro.ToString());
                    Formulario.determinaCapacidadTarro(capacidadActualTarro);

                    if (capacidadActualTarro >= capacidadTarro) // Verifica si el tarro está lleno
                    {
                        tarroLleno = true; // Marca el tarro como lleno
                        tarroVacio = false;
                        Formulario.actualizarEstadoAbejas("Tarro lleno, abejas dejan de trabajar");
                        Monitor.Pulse(sinc); // Notificar al oso que el tarro está lleno
                        Monitor.Wait(sinc); // Esperar a que el oso consuma la miel
                        Formulario.actualizarEstadoAbejas("Abejas continúan con su trabajo");
                        tarroLleno = false; // Marca el tarro como no lleno
                        Thread.Sleep(1500);
                    }
                }
                Thread.Sleep(1000);
                abeja++;
                if (abeja >= numAbejas)
                    abeja = 0; // Reinicia el índice de abejas si se alcanza el final de la lista
            }
        }

        public Form1 Formulario { get; set; }

        public void ConsumidorOso()
        {
            while (!finalizacionEvento.WaitOne(0)) // Bucle infinito para que el oso siempre esté activo
            {
                lock (sinc) // Bloquea el acceso al tarro de miel para evitar condiciones de carrera
                {
                    while (!tarroLleno) // Espera a que el tarro esté lleno
                        Monitor.Wait(sinc);

                    Formulario.actualizarEstadoOso("Oso se despierta");
                    //Console.WriteLine("Oso se despierta");
                    Thread.Sleep(1500);
                    capacidadActualTarro = 0; // Reinicia la capacidad actual del tarro a cero
                    //Console.WriteLine("Oso se come| la miel");
                    Formulario.actualizarEstadoOso("Oso se come la miel");
                    Thread.Sleep(1500);
                    tarroVacio = true; // Marca el tarro como vacío
                    Monitor.Pulse(sinc); // Notificar a una abeja que el tarro está vacío
                }
            }
        }

    }
}

public class Buffer<T>
{
    private Queue<T> cola;
    private int cont;
    public Buffer()
    {
        cola = new Queue<T>();
        cont = 0;
    }

    public void Send(T item)
    {
        // SI EL BUFFER ESTÁ LLENO, ESPERAR A QUE EXISTA UN ESPACIO LIBRE
        // IMPRIMIR UN MENSAJE DICIENDO QUE EL BUFFER ESTÁ LLENO
        cola.Enqueue(item);
        cont++;
    }

    public int Size()
    {
        return cont;
    }

    public T Receive()
    {
        if (cola.Count == 0)
        {
            // SI EL BUFFER ESTÁ VACÍO, ESPERAR A QUE EXISTA UN DATO
            // IMPRIMIR UN MENSAJE DICIENDO QUE EL BUFFER ESTÁ VACÍO
            return default(T);
        }

        T item = cola.Dequeue();
        cont--;
        return item;
    }
}