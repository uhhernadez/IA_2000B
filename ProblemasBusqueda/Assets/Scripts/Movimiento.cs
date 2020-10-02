using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movimiento : MonoBehaviour, IPointerClickHandler
{
    public TicTacToeBoard tablero;
    public int posicion;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
         tablero.MoverPieza(posicion);
    }
}
