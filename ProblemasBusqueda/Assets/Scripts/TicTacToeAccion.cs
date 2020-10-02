using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TicTacToeAccion : MonoBehaviour, IPointerClickHandler
{
    public TicTacToeTablero tablero;
    public int posicion;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        tablero.Mover(posicion);
        Debug.Log("Click en la posición: " + posicion);
    }
}
