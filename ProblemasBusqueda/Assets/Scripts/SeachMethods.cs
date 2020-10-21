using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeachMethods : MonoBehaviour
{
    public GameObject camara;
    public TicTacToeTree arbol;
    private List<Vector3> profundidad = new List<Vector3>();
    private List<Vector3> anchura = new List<Vector3>();
    int pos = 0;
    float ultima_evaluacion;
    public float traslado = 1.5f;
    public float distancia = 2.0f;

    private void Start()
    {
        if (arbol.arbol[0] != null)
        {
            camara.transform.position = arbol.arbol[0].transform.position + Vector3.up;
            BusquedaEnProfundidad();
            BusquedaEnAnchura();
            
            if(arbol.arbol[0].GetComponent<TicTacToeTablero>().turno % 2 == 0)
            { 
               CalculaCosto("X");
            }
            else
            { 
               CalculaCosto("O"); 
            }

            for(int k =0; k < arbol.arbol.Count; k++)
            {
                TicTacToeTablero tablero = arbol.arbol[k].GetComponent<TicTacToeTablero>(); 
                if(tablero.costo == 0.0f)
                { 
                arbol.arbol[k].transform.localScale = Vector3.zero;
                }
                else
                { 
                arbol.arbol[k].transform.localScale = Vector3.one * (1 + tablero.costo/500.0f);
                }
            }   
        }
        ultima_evaluacion = Time.realtimeSinceStartup;
    }

    void Update()
    {
        //AnimacionProfundidad();
        //AnimacionAnchura();

    }

    void AnimacionProfundidad()
    {
        if (pos < profundidad.Count)
        {
            float t = (Time.realtimeSinceStartup - ultima_evaluacion) / traslado;
            Vector3 nuevaPosicion = Vector3.Lerp(camara.transform.position, profundidad[pos] + distancia * Vector3.up, t);
            camara.transform.position = nuevaPosicion;
            if (t >= 1.0f)
            {
                pos++;
                ultima_evaluacion = Time.realtimeSinceStartup;
            }
        }

    }

    void AnimacionAnchura()
    {
        if (pos < anchura.Count)
        {
            float t = (Time.realtimeSinceStartup - ultima_evaluacion) / traslado;

            Vector3 nuevaPosicion = Vector3.Lerp(camara.transform.position, anchura[pos] + distancia * Vector3.up, t);
            camara.transform.position = nuevaPosicion;
            if (t >= 1.0f)
            {
                pos++;
                ultima_evaluacion = Time.realtimeSinceStartup;
            }
        }

    }


    void BusquedaEnProfundidad()
    {
        Stack<GameObject> pila = new Stack<GameObject>();
        pila.Push(arbol.arbol[0]);
        while (pila.Count != 0)
        {
            GameObject actual = pila.Pop();
            profundidad.Add(actual.transform.position);
            for (int k = 0; k < actual.GetComponent<TicTacToeTablero>().hijos.Count; k++)
            {
                pila.Push(actual.GetComponent<TicTacToeTablero>().hijos[k]);
            }
        }
    }
    void BusquedaEnAnchura()
    {
        Queue<GameObject> pila = new Queue<GameObject>();
        pila.Enqueue(arbol.arbol[0]);
        while (pila.Count != 0)
        {
            GameObject actual = pila.Dequeue();
            anchura.Add(actual.transform.position);
            for (int k = 0; k < actual.GetComponent<TicTacToeTablero>().hijos.Count; k++)
            {
                pila.Enqueue(actual.GetComponent<TicTacToeTablero>().hijos[k]);
            }
        }
    }

    void CalculaCosto(string jugador)
    { 
         string contrincante = (jugador == "X")? "O":"X";
         
         for(int k =0; k < arbol.arbol.Count; k++)
         {
            TicTacToeTablero tablero = arbol.arbol[k].GetComponent<TicTacToeTablero>();
            int profundidad = tablero.turno-arbol.arbol[0].GetComponent<TicTacToeTablero>().turno ; 
            int costo;
            // Gana el jugador actual
            if(tablero.TresEnLinea(jugador))
            {
                GameObject go = arbol.arbol[k];    
                costo = 10 - profundidad;
                while(go != null)
                {  
                    if(go == go.GetComponent<TicTacToeTablero>().padre) { 
                        break;
                    } 
                    if(go.GetComponent<TicTacToeTablero>().padre == null) { 
                        break;
                    } 
                    //if(costo < go.GetComponent<TicTacToeTablero>().costo) { 
                    //    go.GetComponent<TicTacToeTablero>().costo = costo;
                    //}
                    go.GetComponent<TicTacToeTablero>().costo += costo;
                    go = go.GetComponent<TicTacToeTablero>().padre; 
                }
            } 
            // Empate
            if(tablero.Empate())
            { 
                GameObject go = arbol.arbol[k];    
                while(go != null)
                {  
                    if(go == go.GetComponent<TicTacToeTablero>().padre) { 
                        break;
                    } 
                    if(go.GetComponent<TicTacToeTablero>().padre == null) { 
                        break;
                    } 
                    go.GetComponent<TicTacToeTablero>().costo += 0;
                    go = go.GetComponent<TicTacToeTablero>().padre; 
                }

            }
            
            // Gana el contrincante
            if(tablero.TresEnLinea(contrincante))
            {
                GameObject go = arbol.arbol[k];   
                costo = profundidad - 10;
                while(go != null)
                {  
                    if(go == go.GetComponent<TicTacToeTablero>().padre) { 
                        break;
                    } 
                    
                    if(go.GetComponent<TicTacToeTablero>().padre == null) { 
                        break;
                    } 
                    
                    //if(costo < go.GetComponent<TicTacToeTablero>().costo) { 
                    //    go.GetComponent<TicTacToeTablero>().costo = costo;
                    //}
                    go.GetComponent<TicTacToeTablero>().costo += costo;
                    go = go.GetComponent<TicTacToeTablero>().padre; 
                }
            } 
         }
    }
}
