using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
