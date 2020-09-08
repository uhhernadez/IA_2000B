using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploRigibody : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");    
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");    
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnColissionStay");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        var renderer = other.gameObject.GetComponent<Renderer>();
        renderer.material.color = Color.red;
        var trash = other.gameObject.GetComponent<Trash>();

        if(trash != null) { 
            Destroy(other.gameObject,2);
        }
//        Debug.DrawLine(this.transform.position,other.gameObject.transform.position,Color.red, 10);
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.DrawLine(this.transform.position,other.gameObject.transform.position,Color.red, 0.1f);
        //Debug.Log("OnTriggerStay");
    }

    private void OnTriggerExit(Collider other)
    {
        //var renderer = other.gameObject.GetComponent<Renderer>();
        //renderer.material.color = Color.white;
        //Debug.Log("OnTriggerExit");
    }
}
