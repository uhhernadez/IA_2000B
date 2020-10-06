using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class TicTacToeTree : MonoBehaviour
{
    public GameObject nodo;
    public GameObject raiz;
    public List<GameObject> arbol = new List<GameObject>();
    private Vector3 deltaz = new Vector3(0, 0, 1);
    private Vector3 deltax = new Vector3(2, 0, 0);
    bool once = true;
    void Start()
    {
        arbol.Add(nodo); 
        if(once)
        {
            int turno = 0;
            CrearArbolProfundidad(ref nodo, ref turno, 1);
            OrganizaArbol();
            once = false;
        }
    }

    void Update()
    {
    }

    void CrearArbolProfundidad(ref GameObject nodo, ref int turno, int profundidad) { 
        TicTacToeTablero tablero = nodo.GetComponent<TicTacToeTablero>(); 
        
        if(turno == profundidad) 
        { 
            Debug.Log("Se ha terminado la búsqueda");
            return;
        }
      
        if(tablero.TerminoJuego()) 
        { 
            Debug.Log("No se pueden crear más nodos, el juego se termino");
            return;
        }

        List<int> movs = tablero.Movimientos();

        for (int k = 0; k < movs.Count; k++) 
        { 
            GameObject siguiente = Instantiate<GameObject>(nodo); 
            //siguiente.GetComponent<TicTacToeTablero>().hijos = new List<GameObject>();
            siguiente.GetComponent<TicTacToeTablero>().Mover(movs[k]);
            //siguiente.SetActive(false);
            turno ++;
            CrearArbolProfundidad(ref siguiente, ref turno, profundidad);
            turno --; 
            siguiente.GetComponent<TicTacToeTablero>().padre = nodo;
            nodo.GetComponent<TicTacToeTablero>().hijos.Add(siguiente);
            arbol.Add(siguiente);
        }

    }

    void OrganizaArbol()
    { 
        int max = 0;
        for(int k = 0; k < arbol.Count; k++)
        { 
            if(max < arbol[k].GetComponent<TicTacToeTablero>().turno)
            { 
                max = arbol[k].GetComponent<TicTacToeTablero>().turno;    
            }
        }
        
        int count = 0;
                
        for(int k = 0; k < arbol.Count; k++)
        { 
            if(arbol[k].GetComponent<TicTacToeTablero>().turno == max)
            { 
                arbol[k].transform.position = (max + 1)*deltax + count*deltaz; 
                count++;    
            }
        } 
        
        for(int k = 0; k < max -1; k++)
        { 
            if(arbol[k].GetComponent<TicTacToeTablero>().turno == k)
            {
                Vector3 pos = new Vector3();
                if(arbol[k].GetComponent<TicTacToeTablero>().hijos == null)
                {
                    Debug.Log("Hijos es igual a null");
                    continue;
                }
                List<GameObject> hijos =arbol[k].GetComponent<TicTacToeTablero>().hijos;   
                for(int j = 0; j < hijos.Count; j++) 
                {
                    Vector3 position = hijos[j].transform.position;
                    Vector3 tpos = position; 
                    pos = tpos + pos;
                }
                
                //pos+=k*deltax;
                //arbol[k].transform.position = pos;
            } 
        } 

    }


}
