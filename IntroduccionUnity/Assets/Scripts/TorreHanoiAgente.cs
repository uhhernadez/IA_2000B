using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;

public class TorreHanoiAgente : MonoBehaviour
{
    public TorreHanoi entorno;
    public float ultimaEjecucion;

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
            //int torreA = Random.Range(1, 4);
            //int torreB = Random.Range(1, 4);
            //Debug.Log("Torrea A: "+ torreA + " Torre B: " + torreB);
            //entorno.MoverPieza(torreA, torreB);
            
            // Generando las acciones válidas y luego escogiendo una acción de forma aleatoria
            ArrayList acciones = GenerarAcciones();
            
            foreach(Tuple<int, int> a in acciones) 
            { 
                Debug.Log("Mover pieza de la torre " + a.Item1 + " a la torre " + a.Item2);
            }
            int opt = UnityEngine.Random.Range(0, acciones.Count);
            Tuple<int, int> accion = (Tuple<int, int>)acciones[opt];
            entorno.MoverPieza(accion.Item1, accion.Item2);
        }
    }

    // Generar acciones
    ArrayList GenerarAcciones() 
    { 
        ArrayList acciones = new ArrayList();
        
        int [] torres = entorno.ObtenerConfiguracionTorres();

        for(int i = 0; i < 3; i++) 
        { 
            if(torres[i] == -1)
            { 
                // Ignoramos este caso
                continue; 
            }
        
            for(int j = 0; j < 3; j++) 
            { 
                if( i == j)
                { 
                    // Ignoramos este caso
                    continue;
                }

                if(torres[j] == -1 ) 
                { 
                    acciones.Add(new Tuple<int, int>(i+1 ,j+1)); 
                } else if (torres[i] < torres[j]) 
                { 
                    acciones.Add(new Tuple<int, int>(i+1 ,j+1)); 
                }
            }
        }

        return acciones;
    }


}
