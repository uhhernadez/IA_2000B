using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using TMPro;

public class PenguinArea : MonoBehaviour
{
    public PenguinAgent penguinAgent;
    public GameObject penguinBaby;
    public TextMeshPro cumulativeRewardText;
    public Fish fishPrefab;
    private List<GameObject> fishes;

    EnvironmentParameters parameters;

    public void Start()
    {
        parameters = Academy.Instance.EnvironmentParameters;
        ResetArea();
    }

    private void Update()
    {
        cumulativeRewardText.text = penguinAgent.GetCumulativeReward().ToString("0.00"); 
    }
    public void RemoveFish(GameObject fish) 
    { 
        fishes.Remove(fish);
        Destroy(fish);
    }

    public int FishRemaining
    { 
        get { return fishes.Count;}
    }

    public static Vector3 ChooseRandomPosition(Vector3 center, float minAngle, float maxAngle, float minRadius, float maxRadius)
    { 
        float radius = minRadius;
        float angle = minAngle;

        if(maxRadius>minRadius)
        { 
            radius = UnityEngine.Random.Range(minRadius,maxRadius); 
        }

        if(maxAngle > minAngle)
        { 
            angle = UnityEngine.Random.Range(minAngle,maxAngle);
        }

        return center + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
    }
    
    private void RemoveFishes()
    { 
        if(fishes != null)
        { 
            for(int i=0; i < fishes.Count; i++)
            { 
                if(fishes[i] != null)
                { 
                    Destroy(fishes[i]);
                }
            }
        }
    
        fishes = new List<GameObject>();
    }

    private void PlacePenguin()
    { 
        Rigidbody rigidbody = penguinAgent.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        penguinAgent.transform.position = ChooseRandomPosition(transform.position, 0f, 360, 0f, 9f) + Vector3.up * .5f;
        penguinAgent.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f),0f);
    }

    private void PlaceBaby()
    {
        Rigidbody rigidbody = penguinBaby.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        penguinBaby.transform.position = ChooseRandomPosition(transform.position, -45f, 45f, 4f, 9f) + Vector3.up * .5f;
        penguinBaby.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    private void SpawnFish(int count, float fishSpeed)
    { 
        for(int k=0; k < count; k++)
        { 
            GameObject fishObject = Instantiate<GameObject>(fishPrefab.gameObject);
            fishObject.transform.position = ChooseRandomPosition(transform.position, 100f, 260f, 2f, 13f);
            fishObject.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f,360),0f);

            fishObject.transform.SetParent(transform);
            fishes.Add(fishObject);
            fishObject.GetComponent<Fish>().fishSpeed = fishSpeed;
        }
    }
    public void ResetArea() 
    { 
        RemoveFishes();
        PlacePenguin();
        PlaceBaby();
        SpawnFish(4, parameters.GetWithDefault("fish_speed",0.5f));
    }




}
