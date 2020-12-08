using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using TMPro;


public class SimpleGoal : Agent
{
    public GameObject goal;
    public GameObject plane;
    new private Rigidbody rigidbody;
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    public float squareLength = 5f;

    public TextMeshPro cumulativeRewardText;
    public override void Initialize()
    {
        rigidbody = GetComponent<Rigidbody>();
        ResetPositions();
    }

    public override void OnEpisodeBegin()
    {
        ResetPositions();
    }

    void ResetPositions() 
    {  
        //Penguin 
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        float x = UnityEngine.Random.Range(-10, 0); 
        float z = UnityEngine.Random.Range(-10, 10); 
        transform.position = new Vector3(x, 0.30f, z) + plane.transform.position;
        transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f),0f);
        // Ball
        goal.transform.position = new Vector3(UnityEngine.Random.Range(0, 10), 1.0f, UnityEngine.Random.Range(-10, 10)) + plane.transform.position;

    }


    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Vector3.Distance(goal.transform.position, transform.position));
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        cumulativeRewardText.text = GetCumulativeReward().ToString("0.00"); 
        float forwardAmount = vectorAction[0];
        float turnAmount = 0f;

        if(vectorAction[1] == 1f)
        { 
            turnAmount = -1f;
        }
        else if(vectorAction[1] == 2f)
        { 
            turnAmount = 1f;
        }

        rigidbody.MovePosition(transform.position + transform.forward * forwardAmount * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(transform.up * turnAmount * turnSpeed * Time.fixedDeltaTime);

        if(Mathf.Abs(transform.localPosition.x) > squareLength ||  Mathf.Abs(transform.localPosition.z) > squareLength) 
        { 
            SetReward(-1f);
            EndEpisode();
        }

        if(MaxStep > 0) AddReward(-1f / MaxStep);
    }

    public override void Heuristic(float[] actionsOut)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("goal"))
        { 
            AddReward(1f);
            EndEpisode();
        }
    }

}
