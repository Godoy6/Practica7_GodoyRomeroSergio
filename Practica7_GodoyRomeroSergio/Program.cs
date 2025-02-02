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
                { 'P', ' ', ' ', 'X', ' ', 'X', ' ', 'X', 'M', ' ' },
                { ' ', ' ', 'M', ' ', 'X', ' ', ' ', ' ', ' ', 'X' },
                { ' ', 'X', ' ', ' ', ' ', ' ', 'M', ' ', ' ', ' ' },
                { ' ', ' ', ' ', 'X', ' ', 'M', ' ', 'M', ' ', ' ' },
                { 'M', ' ', 'M', ' ', 'X', ' ', 'X', ' ', ' ', 'M' },
                { ' ', 'M', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ' },
                { ' ', ' ', ' ', 'X', ' ', 'M', ' ', 'M', ' ', 'X' },
                { 'X', 'X', ' ', 'X', ' ', ' ', 'M', ' ', ' ', ' ' },
                { ' ', ' ', 'M', ' ', 'X', ' ', ' ', 'M', ' ', 'X' },
                { 'M', ' ', ' ', ' ', ' ', 'X', ' ', ' ', ' ', 'X' }
            };

            int jugadorX = 0, jugadorY = 0; // Posición inicial del jugador

            while (true) // Bucle de juego
            {
                Console.Clear(); // Limpia la pantalla y muestra el mapa actualizado
                for (int i = 0; i < tamañoMapa; i++)
                {
                    for (int j = 0; j < tamañoMapa; j++)
                    {
                        Console.Write(mapa[i, j] + " "); // Imprime cada celda del mapa
                    }
                    Console.WriteLine(); // Nueva línea después de cada fila del mapa
                }

                ConsoleKeyInfo tecla = Console.ReadKey(true); // Lee la tecla pulsada por el jugador
                                                              // - La variable llamada "tecla" de tipo "ConsoleKeyInfo" almacenará
                                                              //   la informacion de la tecla que el usuario presione

                mapa[jugadorX, jugadorY] = VACIO; // Borra la posición anterior del jugador

                // Si el jugador se mueve hacia arriba
                if (tecla.Key == ConsoleKey.W) // Arriba
                {
                    if (jugadorX > 0) jugadorX--; // Moverse hacia arriba solo si no está en el límite superior
                }

                // Si el jugador se mueve hacia la izquierda
                else if (tecla.Key == ConsoleKey.A) // Izquierda
                {
                    if (jugadorY > 0) jugadorY--; // Moverse hacia la izquierda solo si no está en el límite izquierdo
                }

                // Si el jugador se mueve hacia abajo
                else if (tecla.Key == ConsoleKey.S) // Abajo
                {
                    if (jugadorX < tamañoMapa - 1) jugadorX++; // Moverse hacia abajo solo si no está en el límite inferior
                }

                // Si el jugador se mueve hacia la derecha
                else if (tecla.Key == ConsoleKey.D) // Derecha
                {
                    if (jugadorY < tamañoMapa - 1) jugadorY++; // Moverse hacia la derecha solo si no está en el límite derecho
                }
                else
                {
                    Console.WriteLine("¿Seguro que has presionado la tecla que era? (W/A/S/D)");  // Si la tecla no es W, A, S, o D, el juego termina
                    break;
                }

                if (mapa[jugadorX, jugadorY] == MINA) // Verifica si el jugador ha pisado una mina
                {
                    Console.Clear(); // Limpia la pantalla y muestra el mapa actualizado
                    Console.WriteLine("Has pisado una mina, te toca empezar de nuevo macho"); // Termina el juego si el jugador pisa una mina
                    break;
                }

                if (mapa[jugadorX, jugadorY] == OBSTACULO) // Verifica si el jugador ha chocado con un obstáculo
                {
                    Console.Clear();

                    // Vuelve al inicio (0, 0)
                    jugadorX = 0; 
                    jugadorY = 0;
                    mapa[0, 0] = JUGADOR; // Coloca al jugador en la posición inicial
                }
                else
                {
                    mapa[jugadorX, jugadorY] = JUGADOR; // Actualiza la posición del jugador en el mapa
                }
            }
        }
    }
}