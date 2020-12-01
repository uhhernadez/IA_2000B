using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class AgentBallBalancer : Agent 
{
    public GameObject ball;
    private Rigidbody rigidBall;
    private EnvironmentParameters parameters;

    public override void Initialize()
    {
        rigidBall = ball.GetComponent<Rigidbody>();
        parameters = Academy.Instance.EnvironmentParameters;
        SetResetParameters();
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Posición actual del agente
        sensor.AddObservation(gameObject.transform.rotation.x); 
        sensor.AddObservation(gameObject.transform.rotation.z);
        // Posición y velocidad de la esfera
        //sensor.AddObservation(ball.transform.position);
        sensor.AddObservation(ball.transform.position - gameObject.transform.position);
        sensor.AddObservation(rigidBall.velocity);
    }

    public override void OnActionReceived(float[] vectorAction)
    //public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        //gameObject.transform.rotation = Quaternion.Euler(30*vectorAction[0], 0, 30*vectorAction[1]);

        var actionZ = 2f * Mathf.Clamp(vectorAction[0], -1f, 1f);
        var actionX = 2f * Mathf.Clamp(vectorAction[1], -1f, 1f);

        if ((gameObject.transform.rotation.z < 0.25f && actionZ > 0f) ||
            (gameObject.transform.rotation.z > -0.25f && actionZ < 0f))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1), actionZ);
        }

        if ((gameObject.transform.rotation.x < 0.25f && actionX > 0f) ||
            (gameObject.transform.rotation.x > -0.25f && actionX < 0f))
        {
            gameObject.transform.Rotate(new Vector3(1, 0, 0), actionX);
        }

        // Politica 
        if ((ball.transform.position.y - gameObject.transform.position.y) < -2f ||
            Mathf.Abs(ball.transform.position.x - gameObject.transform.position.x) > 3f ||
            Mathf.Abs(ball.transform.position.z - gameObject.transform.position.z) > 3f)
        {
            // Penalización
            SetReward(-1f);
            EndEpisode();
        }
        else
        {
            // Recompensa
            SetReward(0.1f); // ¿Este valor que significa?
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 45*Input.GetAxis("Horizontal");
        actionsOut[1] = 45*Input.GetAxis("Vertical"); 
    }



    public override void OnEpisodeBegin()
    {
        gameObject.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        gameObject.transform.Rotate(new Vector3(1, 0, 0), Random.Range(-10f, 10f));
        gameObject.transform.Rotate(new Vector3(0, 0, 1), Random.Range(-10f, 10f));
        rigidBall.velocity = new Vector3(0f, 0f, 0f);
        ball.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), 4f, Random.Range(-1.5f, 1.5f))
            + gameObject.transform.position;
        //Reset the parameters when the Agent is reset.
        SetResetParameters();
    }

    public void SetBall()
    {
        //Set the attributes of the ball by fetching the information from the academy
        rigidBall.mass = parameters.GetWithDefault("mass", 1.0f);
        var scale = parameters.GetWithDefault("scale", 1.0f);
        ball.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void SetResetParameters()
    {
        SetBall();
    }


}
