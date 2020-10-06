using UnityEngine;

public class TicTacToeTablero : MonoBehaviour
{
    enum Rejilla {Vacia, X, O};
    Rejilla [] estadoEnum = new Rejilla[9];

    char [] estado = new char[9];

    // Arreglo para almacenar las piezas de los jugadores.
    public GameObject [] piezas = new GameObject[9];

    // Arreglo para almacenar las posiciones de las piezas
    public GameObject [] posiciones = new GameObject[9];

    public GameObject piezaX;
    public GameObject piezaO;

    private int turno = 0;

    public bool Mover(int posicion)
    {
        if(ExisteUnGanador()) 
        { 
            Debug.Log("Ya hay tres en línea");
            return false;
        }

        if(piezas[posicion] != null ) 
        { 
            Debug.LogWarning("El espacio ya está ocupado");
            return false;
        }
    
        if(turno%2 == 0) 
        {   
            piezas[posicion] = Instantiate(piezaX);
            estado[posicion] = 'X';
        } 
        else
        { 
            piezas[posicion] = Instantiate(piezaO);
            estado[posicion] = 'O';
        }

        piezas[posicion].transform.position = posiciones[posicion].transform.position;
        piezas[posicion].transform.parent = this.transform;
        turno++;
        return true;
    }

    public bool ExisteUnGanador()
    { 
        if(TresEnLinea('X'))
        { 
            return true;
        } 
        
        if(TresEnLinea('O'))
        { 
            return true;
        } 
        return false;
    }

    public bool TresEnLinea(char pieza) 
    {
        // Líneas horizontales
        if(estado[0] == pieza && estado[1] == pieza && estado[2] == pieza) return true; 
        if(estado[3] == pieza && estado[4] == pieza && estado[5] == pieza) return true; 
        if(estado[6] == pieza && estado[7] == pieza && estado[8] == pieza) return true; 

        // Líneas verticales
        if(estado[0] == pieza && estado[3] == pieza && estado[6] == pieza) return true; 
        if(estado[1] == pieza && estado[4] == pieza && estado[7] == pieza) return true; 
        if(estado[2] == pieza && estado[5] == pieza && estado[8] == pieza) return true; 
      
        // Diagonal
        if(estado[0] == pieza && estado[4] == pieza && estado[8] == pieza) return true; 
        if(estado[2] == pieza && estado[4] == pieza && estado[6] == pieza) return true; 
        
        return false;
    }

}
