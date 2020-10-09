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
    float traslado = 2.0f;

    private void Start()
    {
        if (arbol.arbol[0] != null)
        {
            camara.transform.position = arbol.arbol[0].transform.position + Vector3.up;
            BusquedaEnProfundidad();
        }
        ultima_evaluacion = Time.realtimeSinceStartup;
    }

    void Update()
    {
        if (pos < profundidad.Count)
        {
            float t = (Time.realtimeSinceStartup - ultima_evaluacion) / traslado;

            Vector3 nuevaPosicion = Vector3.Lerp(camara.transform.position, profundidad[pos], t);
            camara.transform.position = nuevaPosicion + Vector3.up;
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
}
