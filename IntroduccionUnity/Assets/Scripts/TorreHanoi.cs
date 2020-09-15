using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// Entorno: Las Torres de Hanói
public class TorreHanoi : MonoBehaviour
{
    public GameObject [] piezas;

    public GameObject posicionTorre1;
    public GameObject posicionTorre2;
    public GameObject posicionTorre3;

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
       }
    }

    void Update()
    {
        
    }
    // a <- Torre de donde vamos a tomar la pieza
    // b <- Torre a donde vamos a mover la pieza 
    public bool MoverPieza(int a, int b) 
    {
        if (a == b) 
        { 
            Debug.LogWarning("La pieza ya está en su lugar");
            return false;
        } 

        if(a < 1 || a > 3) 
        {
            Debug.LogWarning("El valor de 'a' está fuera del rango");
            return false;
        }

        if(b < 1 || b > 3)
        { 
            Debug.LogWarning("El valor de 'b' está fuera del rango");
            return false;
        }

        Stack<GameObject> torreA = ObtenerTorre(a);

        if(torreA.Count == 0) { 
            Debug.LogWarning("La torre 'A' no tiene piezas"); 
            return false;
        }

        Stack<GameObject> torreB = ObtenerTorre(b);
        
        if(torreB.Count != 0) 
        { 
            int piezaIndiceA = Convert.ToInt32(torreA.Peek().name);
            int piezaIndiceB = Convert.ToInt32(torreB.Peek().name);

            if(piezaIndiceA > piezaIndiceB) 
            { 
                Debug.LogWarning("La pieza A es más grande que la pieza B");
                return false;
            }
        }
        Vector3 posicionTorre = ObtenerPosicionTorre(b);
        
        TrasladarPieza(torreA,torreB,posicionTorre);

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

    private Vector3 ObtenerPosicionTorre(int a) 
    { 
        Vector3 posicionTorre;
        
        switch(a)
        { 
            case 1: posicionTorre = posicionTorre1.transform.position; break; 
            case 2: posicionTorre = posicionTorre2.transform.position; break; 
            case 3: posicionTorre = posicionTorre3.transform.position; break; 
            default: posicionTorre = posicionTorre1.transform.position; break;  
        }
        
        return posicionTorre;
    }

    void TrasladarPieza(Stack<GameObject> ta, Stack<GameObject> tb, Vector3 pf) 
    { 
        tb.Push(ta.Pop());
        tb.Peek().transform.position = pf;
    }

    public int [] ObtenerConfiguracionTorres() 
    { 
        int [] torres = new int[3];
        // Peek nos da el valor de la pieza que está hasta arriba de nuestra
        if(torre1.Count != 0) 
        { 
            torres[0] = Convert.ToInt32(torre1.Peek().name);
        } 
        else 
        { 
            torres[0] = -1; 
        }
       
        // torres[0] = (torre1.Count != 0 )? Convert.ToInt32(torre3.Peek().name) : -1;
       
        if(torre2.Count != 0) 
        { 
            torres[1] = Convert.ToInt32(torre2.Peek().name);
        }
        else
        { 
            torres[1] = -1;
        }

        if (torre3.Count != 0) 
        { 
            torres[2] = Convert.ToInt32(torre3.Peek().name);
        }
        else 
        { 
            torres[2] = -1; 
        }
        return torres;
    }
}
