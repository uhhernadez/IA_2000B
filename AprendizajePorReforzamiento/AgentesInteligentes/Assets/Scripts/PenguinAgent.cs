using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class PenguinAgent : Agent
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    public GameObject heartPrefab;
    public GameObject regurgitatedFishPrefab;

    private PenguinArea penguinArea;
    new private Rigidbody rigidbody;
    private GameObject baby;
    private bool isFull;
    private float feedRadius = 0f;


    EnvironmentParameters parameters;

    public override void Initialize()
    {
        //base.Initialize();
        penguinArea = GetComponentInParent<PenguinArea>();
        baby = penguinArea.penguinBaby;
        rigidbody = GetComponent<Rigidbody>();
        parameters = Academy.Instance.EnvironmentParameters;
    }

    public override void OnActionReceived(float[] vectorAction)
    {
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

        if(MaxStep > 0) AddReward(-1f / MaxStep);
    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, baby.transform.position) < feedRadius)
        { 
            RegurgitatedFish();
        }
    }



    public override void Heuristic(float[] actionsOut)
    {
        //base.Heuristic(actionsOut);
        float forwardAction = 0f;
        float turnAction = 0f;

        if(Input.GetKey(KeyCode.W))
        { 
            forwardAction = 1f;
        }

        if(Input.GetKey(KeyCode.A))
        { 
            turnAction = 1f;
        }
        else if(Input.GetKey(KeyCode.D))
        { 
            turnAction = 2f; 
        }
        //actionsOut[0]
    }

    public override void CollectObservations(VectorSensor sensor)
    { 
       sensor.AddObservation(isFull);
       sensor.AddObservation(Vector3.Distance(baby.transform.position, transform.position));
       sensor.AddObservation((baby.transform.position-transform.position).normalized);
       sensor.AddObservation(transform.forward);
    }

    public override void OnEpisodeBegin()
    {
//        base.OnEpisodeBegin();
        isFull = false;
        penguinArea.ResetArea();
        //feedRadius = parameters.GetWithDefault("fish_radius",0f);
        feedRadius = Academy.Instance.EnvironmentParameters.GetWithDefault("feed_radius",0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("fish"))
        { 
            EatFish(collision.gameObject);
        }
        else if (collision.transform.CompareTag("baby"))
        { 
            RegurgitatedFish();
        }
    }

    private void EatFish(GameObject fish)
    { 
        if(isFull) return;
        isFull = true;
        penguinArea.RemoveFish(fish);
        AddReward(1);
    }

    private void RegurgitatedFish()
    { 
        if(!isFull) return;
        isFull = false;

        GameObject regurgitatedFish = Instantiate<GameObject>(regurgitatedFishPrefab);
        regurgitatedFish.transform.parent = transform.parent;
        regurgitatedFish.transform.position = baby.transform.position;
        Destroy(regurgitatedFish,4f);

        GameObject heart = Instantiate<GameObject>(heartPrefab);
        heart.transform.parent = transform.parent;
        heart.transform.position = baby.transform.position + Vector3.up;
        Destroy(heart, 4f);

        AddReward(1f);

        if(penguinArea.FishRemaining <= 0)
        { 
            EndEpisode();
        }
    }

}
