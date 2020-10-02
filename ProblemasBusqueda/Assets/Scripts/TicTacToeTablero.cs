using UnityEngine;

public class TicTacToeTablero : MonoBehaviour
{
    // Arreglo para almacenar las piezas de los jugadores.
    public GameObject [] piezas = new GameObject[9];

    // Arreglo para almacenar las posiciones de las piezas
    public GameObject [] posiciones = new GameObject[9];

    public bool Mover(int posicion)
    { 
    
        return false;
    }

    public bool ExisteUnGanador()
    { 
    
        return false;
    }


    void dummy() 
    { 
        for(int k = 0; k < piezas.Length; k++) 
        { 
            if(piezas[k] == null) 
            { 
                
            }
        }
    
    }

}
