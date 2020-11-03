using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoverAMeta : MonoBehaviour
{
    public Transform meta;
    public NavMeshAgent agente;
    public Text tDistancia;

    private void Update()
    {
        NavMeshPathStatus status = agente.pathStatus;
       
        //tDistancia.text = "Distancia a la meta: " + agente.remainingDistance;
        tDistancia.text = "Distancia a la meta: " +Vector3.Distance(agente.pathEndPosition, transform.position);
        //Debug.Log("Estatus ruta: " +status.ToString());
        agente.SetDestination(meta.position);
    }

    public void Stop(bool comando)
    {
        agente.isStopped = comando;
    }

}
