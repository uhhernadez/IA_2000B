using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoverAMeta : MonoBehaviour
{
    public Transform meta;
    public NavMeshAgent agente;

    private void Update()
    {
           agente.SetDestination(meta.position);
    }



}
