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
        if(ExisteUnGanador()) 
        { 
            Debug.Log("Ya hubo un ganador");
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
        } 
        else
        { 
            piezas[posicion] = Instantiate(piezaO);
        }

        Debug.Log("Tipo de pieza " + piezas[posicion].GetComponent<Pieza>().estado);
        piezas[posicion].transform.position = posiciones[posicion].transform.position;
        piezas[posicion].transform.parent = this.transform;
        turno++;
        return true;
    }

    public bool ExisteUnGanador()
    { 
        if(TresEnLinea("O")) 
        {
            return true;
        }

        if(TresEnLinea("X"))
        { 
            return true;
        }

        return false;
    }

    public bool TresEnLinea(string pieza) 
    { 
        if(piezas[0] != null && piezas[1] != null && piezas[2] != null) 
        {  
            if(piezas[0].GetComponent<Pieza>().estado == pieza && 
               piezas[1].GetComponent<Pieza>().estado == pieza && 
               piezas[2].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }

        if(piezas[3] != null && piezas[4] != null && piezas[5] != null) 
        {  
            if(piezas[3].GetComponent<Pieza>().estado == pieza && 
               piezas[4].GetComponent<Pieza>().estado == pieza && 
               piezas[5].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }
        if(piezas[6] != null && piezas[7] != null && piezas[8] != null) 
        {  
            if(piezas[6].GetComponent<Pieza>().estado == pieza && 
               piezas[7].GetComponent<Pieza>().estado == pieza && 
               piezas[8].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }

        // Verticales
        if(piezas[0] != null && piezas[3] != null && piezas[6] != null) 
        {  
            if(piezas[0].GetComponent<Pieza>().estado == pieza && 
               piezas[3].GetComponent<Pieza>().estado == pieza && 
               piezas[6].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }
        if(piezas[1] != null && piezas[4] != null && piezas[7] != null) 
        {  
            if(piezas[1].GetComponent<Pieza>().estado == pieza && 
               piezas[4].GetComponent<Pieza>().estado == pieza && 
               piezas[7].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }
        if(piezas[2] != null && piezas[5] != null && piezas[8] != null) 
        {  
            if(piezas[2].GetComponent<Pieza>().estado == pieza && 
               piezas[5].GetComponent<Pieza>().estado == pieza && 
               piezas[8].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }
        
        // Diagonales
        if(piezas[0] != null && piezas[4] != null && piezas[8] != null) 
        {  
            if(piezas[0].GetComponent<Pieza>().estado == pieza && 
               piezas[4].GetComponent<Pieza>().estado == pieza && 
               piezas[8].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }
        if(piezas[2] != null && piezas[4] != null && piezas[6] != null) 
        {  
            if(piezas[2].GetComponent<Pieza>().estado == pieza && 
               piezas[4].GetComponent<Pieza>().estado == pieza && 
               piezas[6].GetComponent<Pieza>().estado == pieza)
            { 
                return true;
            }
        }
        return false;
    }

        /*
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
        */

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
