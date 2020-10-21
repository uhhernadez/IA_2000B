using System;
using System.Collections.Generic;

namespace Puzzle4
{
    class Puzzle4 { 
        int [] tablero;
        
        public Puzzle4() { 
            tablero = new int[4];
            tablero[0] = 3;
            tablero[1] = 1;
            tablero[2] = 0;
            tablero[3] = 2;
        }
  
        public Puzzle4(Puzzle4 p) { 
            tablero = new int[4];
            
            tablero[0] = p.tablero[0];
            tablero[1] = p.tablero[1];
            tablero[2] = p.tablero[2];
            tablero[3] = p.tablero[3];
        }
        public void Show() { 
            Console.WriteLine(tablero[0]+ " "+ tablero[1]);
            Console.WriteLine(tablero[2]+ " "+ tablero[3]);
        }

        public int [] Movimientos() { 
            int [] movs = new int[2];
            
            int ind = -1;
            for(int k = 0; k < 4; k++) { 
                if(tablero[k]==0) { 
                    ind = k;
                }
            }

            switch(ind) { 
                case 0: movs[0] = 1; movs[1] = 2; break;
                case 1: movs[0] = 0; movs[1] = 3; break;
                case 2: movs[0] = 0; movs[1] = 3; break;
                case 3: movs[0] = 1; movs[1] = 2; break;
            }
            return movs;
        }

        public void Mover(int k) { 
            int ind = -1;
            for(int i = 0; i < 4; i++) { 
                if(tablero[i]==0) { 
                    ind = i;
                }
            }
           tablero[ind] = tablero[k];
           tablero[k] = 0;
        }

        public bool Correcto() { 
            return tablero[0] == 1 && tablero[1] == 2 && tablero[2] == 3;  
        }
    }

    class Program
    {

        static public void Busqueda() { 
            Puzzle4 puzzle = new Puzzle4();

            Stack<Puzzle4> pila = new Stack<Puzzle4>();
            pila.Push(puzzle);

            while(pila.Count != 0) { 
                Puzzle4 p = pila.Pop();
                int [] movs = p.Movimientos();
                Console.WriteLine("------");
                for(int k =0 ; k < 2; k++) {
                    Console.WriteLine("Siguiente configuración");
                    Puzzle4 siguiente = new Puzzle4(puzzle);
                    siguiente.Mover(movs[k]);
                    siguiente.Show();
                    pila.Push(siguiente);
                } 
                
                if(p.Correcto()) { 
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            Puzzle4 puzzle = new Puzzle4();
            puzzle.Show();
            int [] movs = puzzle.Movimientos();
            Console.WriteLine("------");
            for(int k =0 ; k < 2; k++) {
                Console.WriteLine("Genera movientos");
                Puzzle4 p = new Puzzle4(puzzle);
                p.Mover(movs[k]);
                p.Show();
            }

            Busqueda(); 
        }
    }
}
