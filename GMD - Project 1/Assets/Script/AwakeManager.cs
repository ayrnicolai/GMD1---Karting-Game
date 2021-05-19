using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeManager : MonoBehaviour
{
    public GameObject player;
    public GameObject toRotate;
    public float rotatoSpeed;

    public void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        toRotate.transform.Rotate(Vector3.up * rotatoSpeed * Time.deltaTime);
        player.transform.Rotate(Vector3.up * rotatoSpeed * Time.deltaTime);
    }

}
