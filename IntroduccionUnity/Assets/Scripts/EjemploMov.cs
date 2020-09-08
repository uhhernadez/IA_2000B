using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploMov : MonoBehaviour
{
    public Vector3 goal = new Vector3(3,3,0);
    public GameObject target;
    public float speed = 0.1f;
    void Start()
    {
       this.transform.Translate(goal); 
       if(target == null) { 
            Debug.LogError("No se encontró ningún objeto");
       }
    }

    void Update()
    {
        Vector3 delta = target.transform.position - this.transform.position;

        float dist = Vector3.Distance(target.transform.position,this.transform.position);
        
        if(dist > 0.1f) { 
            this.transform.Translate(speed * delta.normalized);
        } 
    }
}
