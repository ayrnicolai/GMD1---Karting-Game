using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSmokeStopOnMovement : MonoBehaviour
{

    public ParticleSystem firstSystem;
    private Vector3 lastPosition;

    private void Awake()
    {
        firstSystem = GetComponent<ParticleSystem>();
    }
    private void LateUpdate()
    {
        var stationary = transform.position == lastPosition;
        if (stationary)
        {
            if (!firstSystem.isEmitting) firstSystem.Play();
        }
        else
        {
            if (firstSystem.isEmitting) firstSystem.Stop();
        }
        lastPosition = transform.position;
    }
}

