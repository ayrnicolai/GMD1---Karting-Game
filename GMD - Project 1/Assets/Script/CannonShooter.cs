using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject CannonBall;
    public float FirePower;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void FixedUpdate () {
        if(Input.GetMouseButtonDown(0)) {
            Instantiate(CannonBall, transform.position, transform.rotation);
            CannonBall.GetComponent<Rigidbody>().AddForce(0, 0, FirePower);
            transform.position = new Vector3(20, transform.position.y, transform.position.z);
        }
    }
}
