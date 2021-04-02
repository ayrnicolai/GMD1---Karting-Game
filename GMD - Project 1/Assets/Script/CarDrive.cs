using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
    private Rigidbody rb;

    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;
    public bool carIsOnGround = true;

    public float maxSpeed = 20f;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
        Fall();
        Jump();
        MaxSpeed();
        rb.AddForce(-transform.up * rb.velocity.magnitude);
    }

    void Move()
    {
        if (carIsOnGround) {

            if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(0, 0, Vector3.forward.z) * speed * 10);
    
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(new Vector3(0, 0, Vector3.forward.z) * -speed * 10);

        }
            else if(!carIsOnGround)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    rb.AddRelativeForce(new Vector3(0, 0, 0) * speed * 10);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    rb.AddRelativeForce(new Vector3(0, 0, 0) * -speed * 10);

                }
            }

        }

        
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
        }


    void Turn()
    {

        if (carIsOnGround)
        {
            if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * speed * 10);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * speed * 10);
        }
            else if (!carIsOnGround)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rb.AddTorque(Vector3.up * speed * 0);
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    rb.AddTorque(-Vector3.up * speed * 0);
                }
            }

        }

       
    }
    
    void Fall()
        {
           rb.AddRelativeForce(Vector3.down * gravityMultiplier * 20f);




    }

    void Jump()
    {
        if (carIsOnGround)
        {
            if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            MaxSpeed();
            carIsOnGround = false;
        }
        else if (!carIsOnGround)
            {
                rb.AddForce(new Vector3(0, 0, 0), ForceMode.Impulse);

            }
        }
        
        
    }
    void MaxSpeed()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") {
            carIsOnGround = true;
        }
    }

}
    


