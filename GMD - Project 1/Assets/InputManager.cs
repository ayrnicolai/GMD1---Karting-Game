using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    internal enum driver
    {
        AI,
        keyboard,

    }

    [SerializeField] driver driveController;


    public float vertical;
    public float horizontal;
    public bool handbrake;
    public bool pause;

    public trackWaypoints waypoints;
    public Transform currentWaypoint;
    public List<Transform> nodes = new List<Transform>();
    [Range(1, 10)] public int distanceOffset;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectWithTag("path").GetComponent<trackWaypoints>();
        nodes = waypoints.nodes;

    }


    private void FixedUpdate()
    {
        switch (driveController)
        {
            case driver.AI:
                break;
            case driver.keyboard: keyboardDrive();
                break;
        }

    }
    private void AIDrive()
    {

    }


    private void keyboardDrive()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") != 0)? true : false;
    }

    private void calculateDistanceofWaypoints()
    {
        Vector3 position = gameObject.transform.position;
        float distance = Mathf.Infinity;

        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 difference = nodes[i].transform.position - position;
            float currentDistance = difference.magnitude;
            if (currentDistance < distance)
            {
                currentWaypoint = nodes[i + distanceOffset];
                distance = currentDistance;

            }
        }
    }



}
