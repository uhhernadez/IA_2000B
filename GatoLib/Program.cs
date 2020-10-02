using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace GatoLib
{
    class Movimiento
    { 
        public int index;
        public char jugador;

        public Movimiento(int index, char jugador) 
        { 
            this.index = index;
            this.jugador = jugador;
        }
    }

    class TableroGato 
    { 
        char [] tablero;

        public TableroGato() 
        { 
            tablero = Enumerable.Repeat('_', 9).ToArray();
        }
        
        public TableroGato(TableroGato tableroGato) 
        {   
            tablero = new char[9];
            tableroGato.tablero.CopyTo(tablero,0);    
        }

        public void Mostrar()
        { 
            Console.WriteLine(tablero[0]+"|" + tablero[1] + "|" + tablero[2]);
            Console.WriteLine("-----");
            Console.WriteLine(tablero[3]+"|" + tablero[4] + "|" + tablero[5]);
            Console.WriteLine("-----");
            Console.WriteLine(tablero[6]+"|" + tablero[7] + "|" + tablero[8]);
        }

        public bool TerminoElJuego() {  
            int[] indices = tablero.Select((c,i) => c == '_' ? i : -1).Where(i => i!=-1).ToArray();
            
            if(indices == null) { 
                return true;
            }
           
            if(indices.Length == 0) 
            { 
                return true;
            }

            // Alguien ya ganó
            if(TresEnLinea('O') || TresEnLinea('X'))
            { 
                return true; 
            }

            return false;
        }

        public bool TresEnLinea(char jugador) 
        { 
            // Vertical y horizontal
            for(int k = 0; k < 3; k++) {
                int indRenglones = 3*k;
                if(tablero[indRenglones] == jugador && tablero[indRenglones+1] == jugador && tablero[indRenglones+2] == jugador)
                { 
                    return true;
                }

                if(tablero[k] == jugador && tablero[k+3] == jugador && tablero[k+6] == jugador)
                { 
                    return true;
                }
            }
            
            // Diagonales 
            if(tablero[0] == jugador && tablero[4] == jugador && tablero[8] == jugador)
            { 
                return true;
            }

            if(tablero[2] == jugador && tablero[4] == jugador && tablero[6] == jugador)
            { 
                return true;
            }

            return false;
        }

        public char Turno() 
        { 
            char [] jugador_x = Array.FindAll<char>(tablero, x => x == 'X');
            char [] jugador_o = Array.FindAll<char>(tablero, x => x == 'O');

            if(jugador_x.Length == 0)
                return 'X';
            if(jugador_o.Length == 0)
                return 'O';
           if(jugador_o.Length == jugador_x.Length) { 
                return 'X';
           } 
           return 'O';
        }

        public Movimiento [] CalcularMovimientos() 
        {
            // No hay más lugares para jugar
            if(TerminoElJuego()) 
            { 
                return null;
            }

            char jugador = Turno();
            int[] indices = tablero.Select((c,i) => c == '_' ? i : -1).Where(i => i!=-1).ToArray();
            Movimiento [] movimientos = new Movimiento[indices.Length];

            for(int k = 0; k < movimientos.Length; k++) 
            { 
                movimientos[k] = new Movimiento(indices[k], jugador);
            }
            return movimientos;
        }

        public void Mover(Movimiento mov) 
        { 
            tablero[mov.index] = mov.jugador;
        }

    }

    class Program
    {
        static public void JugarRecursivamente(ref TableroGato tablero) 
        { 
            Movimiento [] movimientos = tablero.CalcularMovimientos();

            if(movimientos == null) 
            { 
               //Console.WriteLine("El juego se terminó");
               return;
            }

            for (int k = 0; k < movimientos.Length; k++) 
            {
               TableroGato siguiente = new TableroGato(tablero);
               siguiente.Mover(movimientos[k]);
               JugarRecursivamente(ref siguiente);
            }

            return;
        }
        static void Main(string[] args)
        {
            TableroGato tablero = new TableroGato();
            tablero.Mostrar();
            JugarRecursivamente(ref tablero); 
        }

    }
}
