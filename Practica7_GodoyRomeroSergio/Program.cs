using System;

namespace Practica7_GodoyRomeroSergio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tamañoMapa = 10; // Tamaño del mapa

            // Elementos del mapa
            char VACIO = ' ';
            char OBSTACULO = 'X';
            char MINA = 'M';
            char JUGADOR = 'P';

            char[,] mapa = new char[10, 10] // Mapa predefinido
            {
                { 'P', ' ', ' ', ' ', ' ', 'X', ' ', ' ', 'M', ' ' },
                { ' ', ' ', 'M', ' ', 'X', ' ', ' ', ' ', ' ', ' ' },
                { ' ', 'X', ' ', ' ', ' ', ' ', 'M', ' ', ' ', ' ' },
                { ' ', ' ', ' ', 'X', ' ', 'M', ' ', ' ', ' ', ' ' },
                { 'M', ' ', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ' },
                { ' ', 'M', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ' },
                { ' ', ' ', 'X', ' ', ' ', 'M', ' ', 'M', ' ', ' ' },
                { ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                { ' ', ' ', 'M', ' ', 'X', ' ', ' ', 'M', ' ', ' ' },
                { 'M', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ' }
            };

            int jugadorX = 0, jugadorY = 0; // Posición del jugador

            while (true) // Bucle del juego
            {
                Console.Clear(); // Mostrar el mapa
                for (int i = 0; i < tamañoMapa; i++)
                {
                    for (int j = 0; j < tamañoMapa; j++)
                    {
                        Console.Write(mapa[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                ConsoleKeyInfo tecla = Console.ReadKey(true); // Leer el movimiento del jugador

                mapa[jugadorX, jugadorY] = VACIO; // Para no ir dejando hueyas ("P")

                // Comprobar si el jugador se mueve
                if (tecla.Key == ConsoleKey.W) // Arriba
                {
                    if (jugadorX > 0) jugadorX--;
                }
                else if (tecla.Key == ConsoleKey.A) // Izquierda
                {
                    if (jugadorY > 0) jugadorY--;
                }
                else if (tecla.Key == ConsoleKey.S) // Abajo
                {
                    if (jugadorX < tamañoMapa - 1) jugadorX++;
                }
                else if (tecla.Key == ConsoleKey.D) // Derecha
                {
                    if (jugadorY < tamañoMapa - 1) jugadorY++;
                }
                else
                {
                    Console.WriteLine("Tecla inválida. El juego termina.");  // Si la tecla no es W, A, S, o D, el juego termina
                    break;
                }

                if (mapa[jugadorX, jugadorY] == MINA) // Verificar si el jugador pisó una mina
                {
                    Console.Clear();
                    Console.WriteLine("¡Has pisado una mina! El juego ha terminado.");
                    break;
                }

                if (mapa[jugadorX, jugadorY] == OBSTACULO) // Verificar si el jugador chocó con un obstáculo
                {
                    Console.Clear();
                    Console.WriteLine("¡Has chocado con un obstáculo! Vuelves al inicio.");
                    jugadorX = 0;
                    jugadorY = 0;
                    mapa[0, 0] = JUGADOR;
                }
                else
                {
                    mapa[jugadorX, jugadorY] = JUGADOR; // Actualizar la posición del jugador en el mapa
                }
            }
        }
    }
}