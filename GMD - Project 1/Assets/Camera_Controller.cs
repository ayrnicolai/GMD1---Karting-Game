using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject Player;
    public GameObject child;
    public GameObject cameraLookAt;

    public float speed;

    //We find our Player with a tag
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        child = Player.transform.Find("camera constraint").gameObject;
        cameraLookAt = Player.transform.Find("camera lookAt").gameObject;
    }

    private void FixedUpdate()
    {
        follow();
    }
    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime * speed);
        gameObject.transform.LookAt(Player.gameObject.transform);

    }

}
