using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreHanoi : MonoBehaviour
{
    public GameObject [] piezas;
    
    public GameObject ptorre1;
    public GameObject ptorre2;
    public GameObject ptorre3;

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
        if(a == b) { 
            Debug.Log("NOP");
            return false;
        }

        if(a < 1 && a > 3) 
        { 
            return false;
        }

        if(b < 1 && b > 3)
        { 
            return false;
        }
        
        Stack<GameObject> ta = ObtenerTorre(a);
        Stack<GameObject> tb = ObtenerTorre(b);
        
        Vector3 pta = ObtenerPosicionTorre(a);
        Vector3 ptb = ObtenerPosicionTorre(b);
        
        Debug.Log("Size a: " + ta.Count + " Size b: " + tb.Count); 
        return TrasladarPieza(ta, tb, pta, ptb);
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


    bool TrasladarPieza(Stack<GameObject> ta, Stack<GameObject> tb, Vector3 pta, Vector3 ptb) { 
        // Si la pieza que se va a poner es más grande que la pieza que está
        // Llego al limite de piezas
        if(tb.Count == 7) 
        { 
            Debug.Log("La torre B está llena");
            return false;
        }

        if(ta.Count == 0) 
        { 
            Debug.Log("La torre A no tiene piezas");
            return false;
        }

        if(tb.Count > 0) 
        { 
            int pas = Convert.ToInt32(ta.Peek().name);
            int pbs = Convert.ToInt32(tb.Peek().name);

            if( pas > pbs) { 
                Debug.Log("La pieza que es más grande");
                return false;
            }
        }

        tb.Push(ta.Pop());
        Vector3 d = ptb -pta;
        tb.Peek().transform.position = ptb;
        return true;
    }

    private Vector3 ObtenerPosicionTorre(int a) 
    { 
        Vector3 t;
        switch(a) { 
            case 1: t = ptorre1.transform.position; break;
            case 2: t = ptorre2.transform.position; break;
            case 3: t = ptorre3.transform.position; break;
            default: t = ptorre1.transform.position; break;
        } 
        return t;
    }


    public bool ConfiguracionFinal() {
        var  torre = torre1.ToArray();
        if (torre1.Count == 0 || torre1.Count != 7)  
        { 
          return false;
        } 

        for(int k = 0; k < torre1.Count; k++) { 
           int id = Convert.ToInt32(torre[k].name);
           Debug.Log("El identificador es: "+ id);
        }

        return true;
    }
}
