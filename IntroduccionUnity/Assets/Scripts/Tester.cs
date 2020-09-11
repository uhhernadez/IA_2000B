using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public TorreHanoi th;
    public GameObject thg;
    private bool resuelto = false;
    float ultimaEvaluacion;
    void Start()
    {
       th = thg.GetComponent<TorreHanoi>();
       ultimaEvaluacion = Time.realtimeSinceStartup;
    }

    void Update()
    {
       if((Time.realtimeSinceStartup - ultimaEvaluacion)> 1.0 && !resuelto) { 
            Debug.Log("Mover pieza");
            int a = Mathf.RoundToInt(Random.Range(1, 4));
            int b = Mathf.RoundToInt(Random.Range(1, 4));
            Debug.Log("Pieza a: " +  a + " Pieza b: " + b);
            th.MoverPieza(a,b);
            resuelto = th.ConfiguracionFinal();
            ultimaEvaluacion = Time.realtimeSinceStartup;
       } 
    }
}
