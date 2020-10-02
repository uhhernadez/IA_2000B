using UnityEngine;

public class TicTacToeTablero : MonoBehaviour
{
    // Arreglo para almacenar las piezas de los jugadores.
    public GameObject [] piezas = new GameObject[9];

    // Arreglo para almacenar las posiciones de las piezas
    public GameObject [] posiciones = new GameObject[9];

    public GameObject piezaX;
    public GameObject piezaO;

    private int turno = 0;

    public bool Mover(int posicion)
    { 
        if(piezas[posicion] != null ) 
        { 
            Debug.LogWarning("El espacio ya está ocupado");
            return false;
        }
    
        if(turno%2 == 0) 
        {   
            piezas[posicion] = Instantiate(piezaX);
        } 
        else
        { 
            piezas[posicion] = Instantiate(piezaO);
        }

        piezas[posicion].transform.position = posiciones[posicion].transform.position;
        piezas[posicion].transform.parent = this.transform;
        turno++;
        return true;
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
