﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float fishSpeed;

    private float randomizedSpeed = 0f;
    private float nextActionTime = -1;
    private Vector3 targetPosition;

    private void FixedUpdate()
    {
        if(fishSpeed > 0f)
        { 
            Swin();
        }
    }

    private void Swin()
    { 
        if(Time.fixedTime >= nextActionTime)
        { 
            randomizedSpeed = fishSpeed * UnityEngine.Random.Range(.5f, 1.5f);
            targetPosition = PenguinArea.ChooseRandomPosition(transform.parent.position, 100f, 260f, 2f, 13f);
            transform.rotation = Quaternion.LookRotation(targetPosition - transform.position,Vector3.up);

            float timeToGetThere = Vector3.Distance(transform.position, targetPosition) / randomizedSpeed;
            nextActionTime = Time.fixedTime + timeToGetThere;
        }
        else
        {
            Vector3 moveVector = randomizedSpeed * transform.forward * Time.fixedDeltaTime;
            if (moveVector.magnitude <= Vector3.Distance(transform.position, targetPosition))
            {
                transform.position += moveVector;
            }
            else
            {
                transform.position = targetPosition;
                nextActionTime = Time.fixedTime;
            }

        }
    }

}
