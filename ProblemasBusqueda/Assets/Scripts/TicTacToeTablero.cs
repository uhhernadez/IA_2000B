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
        if(ExisteUnGanador()) { 
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

        Debug.Log("La pieza tiene el TAG:" + piezas[posicion].tag);
        piezas[posicion].transform.position = posiciones[posicion].transform.position;
        piezas[posicion].transform.parent = this.transform;
        turno++;
        return true;
    }
    
    public bool ExisteUnGanador()
    {
        if (TresEnLinea("O"))
        {
            return true;
        }

        if (TresEnLinea("X"))
        {
            return true;
        }

        return false;
    }

    public bool TresEnLinea(string pieza)
    { 
        for(int k = 0; k < 3; k++) 
        { 
            int ind = 3*k;
            if(piezas[ind]!= null && piezas[ind+1]!= null && piezas[ind+2]!= null )
            { 
                if(piezas[ind].CompareTag(pieza) && piezas[ind+1].CompareTag(pieza) && piezas[ind+2].CompareTag(pieza) )
                { 
                    return true; 
                }
            }
            
            if(piezas[k]!= null && piezas[k+3]!= null && piezas[k+6]!= null )
            { 
                if(piezas[k].CompareTag(pieza) && piezas[k+3].CompareTag(pieza) && piezas[k+6].CompareTag(pieza) )
                { 
                    return true; 
                }
            }
        
        } 

        if(piezas[0]!= null && piezas[4]!= null && piezas[8]!= null )
        { 
            if(piezas[0].CompareTag(pieza) && piezas[4].CompareTag(pieza) && piezas[8].CompareTag(pieza) )
            { 
                return true; 
            }
        }

        if(piezas[2]!= null && piezas[4]!= null && piezas[6]!= null )
        { 
            if(piezas[2].CompareTag(pieza) && piezas[4].CompareTag(pieza) && piezas[6].CompareTag(pieza) )
            { 
                return true; 
            }
        }
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
