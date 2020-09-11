using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       //if(Time.realtimeSinceStartup - ultimaEjecucion > 1.0f)
        { 
            ultimaEjecucion = Time.realtimeSinceStartup;
            int torreA = Random.Range(1, 4);
            int torreB = Random.Range(1, 4);
            Debug.Log("Torrea A: "+ torreA + " Torre B: " + torreB);
            entorno.MoverPieza(torreA, torreB);
        }
    }
}
