using System.Collections.Generic;
using UnityEngine;

public class TicTacToeTablero : MonoBehaviour
{
    public GameObject padre;
    public List<GameObject> hijos;
    public List<int> costo = new List<int>();
    // Arreglo para almacenar las piezas de los jugadores.
    public GameObject [] piezas = new GameObject[9];

    // Arreglo para almacenar las posiciones de las piezas
    public GameObject [] posiciones = new GameObject[9];

    public GameObject piezaX;
    public GameObject piezaO;

    public int turno;
    public bool bloquear = false;

    public bool Mover(int posicion)
    {
        if(bloquear) { 
            return false;
        }
        if(piezas[posicion] != null ) 
        { 
            Debug.LogWarning("El espacio ya está ocupado");
            return false;
        }
   
        string tag;
        if(turno%2 == 0) 
        {   
            piezas[posicion] = Instantiate(piezaX);
            tag = "X";
        } 
        else
        { 
            piezas[posicion] = Instantiate(piezaO);
            tag = "O";
        }
        piezas[posicion].transform.position = posiciones[posicion].transform.position;
        piezas[posicion].transform.parent = this.transform;
        turno++;
        bloquear = TresEnLinea(tag);
        return true;
    }

    public bool TerminoJuego()
    { 
        if(TresEnLinea("O"))
        { 
            return true;
        }

        if(TresEnLinea("X"))
        { 
            return true;
        }

        for(int k = 0; k < piezas.Length; k++) 
        { 
            if(piezas[k] == null)
            { 
                return false; 
            }
        }

        return true;
    }

    public bool TresEnLinea(string marca) { 
       
        for(int k=0; k< 3; k++) 
        {
            int m = 3*k;
            if(piezas[m] != null && piezas[m+1] != null && piezas[m+2]!= null) 
            { 
                if(piezas[m].CompareTag(marca) && piezas[m+1].CompareTag(marca) && piezas[m+2].CompareTag(marca)) 
                { 
                    return true; 
                }
            }

            if(piezas[k] != null && piezas[k+3] != null && piezas[k+6]!= null) 
            { 
                if(piezas[k].CompareTag(marca) && piezas[k+3].CompareTag(marca) && piezas[k+6].CompareTag(marca)) 
                { 
                    return true; 
                }
            }
        }
        
        
        if(piezas[0] != null && piezas[4] != null && piezas[8]!= null) 
        { 
            if(piezas[0].CompareTag(marca) && piezas[4].CompareTag(marca) && piezas[8].CompareTag(marca)) 
            { 
                return true; 
            }
        }
    
        if(piezas[2] != null && piezas[4] != null && piezas[6]!= null) 
        { 
            if(piezas[2].CompareTag(marca) && piezas[4].CompareTag(marca) && piezas[6].CompareTag(marca)) 
            { 
                return true; 
            }
        }
        return false;
    }
    
    public List<int> Movimientos() { 
        List<int> movimientos = new List<int>();
        
        if(TerminoJuego())
        { 
            return movimientos;
        }
        
        for(int k = 0; k < piezas.Length; k++ ) 
        { 
            if(piezas[k] == null) 
            { 
                movimientos.Add(k);
            }
        }
        return movimientos;
    }
}
