using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeBoard : MonoBehaviour
{
    public enum Jugador { X, O };
    public GameObject[] tablero = new GameObject[9];
    public GameObject[] posiciones = new GameObject[9];
    public GameObject piezaO;
    public GameObject piezaX;

    public bool MoverPieza(int posicion)
    {
        if (EstaLleno())
        {
            Debug.LogWarning("Está lleno el tablero");
            return false;
        }

        if (tablero[posicion] != null)
        {
            Debug.LogWarning("La posición ya está ocupada");
            return false;
        }
        Jugador turno = Turno();
        if (turno == Jugador.O)
        {
            tablero[posicion] = Instantiate(piezaO);
            tablero[posicion].transform.position = posiciones[posicion].transform.position;
            tablero[posicion].transform.parent = this.transform;
        }
        else
        {
            tablero[posicion] = Instantiate(piezaX);
            tablero[posicion].transform.position = posiciones[posicion].transform.position;
            tablero[posicion].transform.parent = this.transform;
        }

        return true;
    }

    public Jugador Turno()
    {
        int count = 0;
        foreach (GameObject item in tablero)
        {
            if (item == null)
            {
                count++;
            }
        }
        // En turnos pares los juega el X
        // En turnos impares juega el O
        Debug.Log("Contador: " + count);
        return (count % 2 != 0) ? Jugador.X : Jugador.O;
    }

    public bool EstaLleno()
    {
        foreach (GameObject item in tablero)
        {
            if (item == null)
            {
                return false;
            }
        }
        return true;
    }
}
