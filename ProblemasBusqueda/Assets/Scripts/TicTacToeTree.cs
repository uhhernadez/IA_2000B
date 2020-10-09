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
    private Vector3 deltax = new Vector3(4, 0, 0);
    bool once = true;
    public Material materialLinea;
    void Awake()
    {
        if (once)
        {
            int turno = 0;
            raiz = Instantiate(nodo);
            arbol.Add(raiz);
            CrearArbolProfundidad(ref raiz, ref turno, 4);
            OrganizaArbol();
            //once = false;
        }
    }

    void Update()
    {
    }

    void CrearArbolProfundidad(ref GameObject nodo, ref int turno, int profundidad)
    {
        TicTacToeTablero tablero = nodo.GetComponent<TicTacToeTablero>();

        if (turno == profundidad)
        {
            return;
        }

        if (tablero.TerminoJuego())
        {
            Debug.Log("No se pueden crear más nodos, el juego se termino");
            return;
        }

        List<int> movs = tablero.Movimientos();
        for (int k = 0; k < movs.Count; k++)
        {
            GameObject siguiente = Instantiate<GameObject>(nodo);
            siguiente.GetComponent<TicTacToeTablero>().hijos = new List<GameObject>();
            siguiente.GetComponent<TicTacToeTablero>().Mover(movs[k]);
            siguiente.SetActive(true);
            turno++;
            CrearArbolProfundidad(ref siguiente, ref turno, profundidad);
            turno--;

            siguiente.GetComponent<TicTacToeTablero>().padre = nodo;
            nodo.GetComponent<TicTacToeTablero>().hijos.Add(siguiente);
            arbol.Add(siguiente);
        }

    }

    void OrganizaArbol()
    {
        int max = 0;
        for (int k = 0; k < arbol.Count; k++)
        {
            if (max < arbol[k].GetComponent<TicTacToeTablero>().turno)
            {
                max = arbol[k].GetComponent<TicTacToeTablero>().turno;
            }
        }

        int count = 0;

        for (int k = 0; k < arbol.Count; k++)
        {
            if (arbol[k].GetComponent<TicTacToeTablero>().turno == max)
            {
                arbol[k].transform.position = max* deltax + count * deltaz;
                count++;
            }
        }

        for (int k = (max -1); k > -1; k--)
        {
            for (int i = 0; i < arbol.Count; i++)
            {
                if (arbol[i].GetComponent<TicTacToeTablero>().turno == k)
                {
                    if (arbol[i].GetComponent<TicTacToeTablero>().hijos == null ||
                       arbol[i].GetComponent<TicTacToeTablero>().hijos.Count == 0)
                    {
                        Debug.Log("Hijos es igual a null, turno" + k);
                        continue;
                    }
                    List<GameObject> hijos = arbol[i].GetComponent<TicTacToeTablero>().hijos;

                    Vector3 pos = new Vector3();
                    for (int j = 0; j < hijos.Count; j++)
                    {
                        Vector3 position = hijos[j].transform.position;
                        Vector3 tpos = position;
                        pos = tpos + pos;
                    }
                    pos = pos * (1.0f / hijos.Count) - deltax;
                    arbol[i].transform.position = pos;
                }
            }
        }

    }
    // To show the lines in the game window whne it is running
    
    void DibujarConexiones()
    {
        int max = 0;
        for (int k = 0; k < arbol.Count; k++)
        {
            if (max < arbol[k].GetComponent<TicTacToeTablero>().turno)
            {
                max = arbol[k].GetComponent<TicTacToeTablero>().turno;
            }
        }
    
        for (int k = 0; k < max; k++)
        {
            for (int i = 0; i < arbol.Count; i++)
            {
                if (arbol[i].GetComponent<TicTacToeTablero>().turno == k)
                {
                    if (arbol[i].GetComponent<TicTacToeTablero>().hijos == null ||
                       arbol[i].GetComponent<TicTacToeTablero>().hijos.Count == 0)
                    {
                        Debug.Log("Hijos es igual a null, turno" + k);
                        continue;
                    }
                    List<GameObject> hijos = arbol[i].GetComponent<TicTacToeTablero>().hijos;
                    Vector3 inicial = arbol[i].transform.position;
                    for (int j = 0; j < hijos.Count; j++)
                    {
                        Vector3 final = hijos[j].transform.position;
                        GL.Begin(GL.LINES);
                        materialLinea.SetPass(0);
                        //GL.Color(Color.red);
                        GL.Vertex3(inicial.x, inicial.y, inicial.z);
                        GL.Vertex3(final.x, final.y, final.z);
                        GL.End();
                    }
                }
            }
        }
    }
    public void OnPostRender()
    {
        DibujarConexiones();
    }



}
