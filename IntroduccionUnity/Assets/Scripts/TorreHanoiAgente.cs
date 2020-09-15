using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TorreHanoiAgente : MonoBehaviour
{
    public TorreHanoi entorno;
    public float ultimaEjecucion;
    private int noMovimiento = 0; 
    public Text noMovimientos;
    // Start is called before the first frame update
    void Start()
    {
        ultimaEjecucion = Time.realtimeSinceStartup;
       
    }

    // Update is called once per frame
    void Update()
    {
        // 1, 2, 3
       if(Time.realtimeSinceStartup - ultimaEjecucion > 1.0f)
        { 
            ultimaEjecucion = Time.realtimeSinceStartup;
            //MovimientoAleatorio();
            if(!entorno.ConfiguracionFinal()) 
            { 
                EstrategiaIzquierda();
                noMovimiento++;
            }
            noMovimientos.text = "Movimiento : " + noMovimiento;
        }
    }
   
    void MovimientoAleatorio() 
    { 
        ArrayList acciones = CalcularAcciones();
        
        int opt = UnityEngine.Random.Range(0, acciones.Count);
        Tuple<int, int> accion = (Tuple<int, int>)acciones[opt];
        
        int torreA = accion.Item1;
        int torreB = accion.Item2; 
        entorno.MoverPieza(torreA, torreB);
    }

    ArrayList CalcularAcciones() 
    { 
        ArrayList actions = new ArrayList(); 
        
        int [] torres = entorno.ObtenerEstadoTorres();
        for(int i = 0; i < torres.Length; i++)  
        { 
            for(int j = 0; j < torres.Length; j++)  
            { 
                if(i == j) 
                { 
                    // Mover la pieza al mismo lugar
                    continue;
                }
                
                // No se puede mover una pieza donde no hay
                if(torres[i] != 100 ) 
                {
                    if(torres[i] < torres[j] ) 
                    { 
                        actions.Add(new Tuple<int,int>(i+1,j+1));
                    }
                }
            }     
        }
        return actions;
    }


    void EstrategiaIzquierda() 
    { 
        int [] torres = entorno.ObtenerEstadoTorres();
        if(noMovimiento % 2 == 0) 
        { 
            int posicion = 0;

            for(int k = 0 ; k < torres.Length; k++) { 
                if(torres[k] == 0) { 
                    posicion = k;
                    break;
                } 
            }

            int siguiente = (posicion == 0)?3:posicion;
            Debug.Log(posicion +" "+siguiente);
            posicion++;
            entorno.MoverPieza(posicion, siguiente);
        } 
        else
        {  
            ArrayList acciones = CalcularAcciones();
            foreach (Tuple<int, int>  accion in acciones) 
            { 
                if(torres[accion.Item1-1] != 0) 
                { 
                    int torreA = accion.Item1;
                    int torreB = accion.Item2;
                    entorno.MoverPieza(torreA, torreB);
                    break;
                }
            } 
        }
    
    }



}
