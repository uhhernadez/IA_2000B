using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreHanoi : MonoBehaviour
{
    public GameObject [] piezas;

    private Stack<GameObject> torre1 = new Stack<GameObject>();
    private Stack<GameObject> torre2 = new Stack<GameObject>();
    private Stack<GameObject> torre3 = new Stack<GameObject>();

    void Start()
    {
       if(piezas!=null) 
       { 
            // Operación de rango
            foreach(GameObject d in piezas) 
            { 
               torre3.Push(d);
            }

            // Ciclo For
            /*
            for(int k = 0; k < piezas.Length; k++) 
            { 
                torre3.Push(piezas[k]);
            }
            */
       }
       Debug.LogWarning("La torre 3 tiene: " +torre3.Count);
    }

    void Update()
    {
        
    }
    // a <- Torre de donde vamos a tomar la pieza
    // b <- Torre a donde vamos a mover la pieza 
    public bool MoverPieza(int a, int b) 
    { 
        if(a < 1 && a > 3) 
        { 
            return false;
        }

        if(b < 1 && b > 3)
        { 
            return false;
        }

        //TrasladarPieza(,);

        return true;
    }

    private Stack<GameObject> ObtenerTorre(int a) 
    { 
        Stack<GameObject> torre;
        switch(a) { 
            case 1: torre = torre1; break;
            case 2: torre = torre2; break;
            case 3: torre = torre3; break;
            default: torre = torre1; break;
        } 

        return torre;
    }

}
