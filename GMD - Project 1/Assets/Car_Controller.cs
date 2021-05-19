using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Controller : MonoBehaviour
{
    internal enum driveType
    {
        frontWheelDrive, rearWheelDrive, allWheelDrive
    }
    [SerializeField] private driveType drive;

    public InputManager IM;

    //We add wheelcolliders in arrays
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    private Rigidbody rigidbody;
    public GameObject centerOfMass;

    public float radius = 6;
    public int motorTorque = 1500;
    public float steeringMax = 20;
    public float addDownForceValue = 50;
    public bool carIsOnGround;
    public float brakePower;
    public float[] slip = new float[4];
    public float WheelsRPM;
    public float KPH;

    public float vertical;
    public float horizontal;
    public bool handbrake;

    private WheelFrictionCurve forwardFriction, sidewaysfriction;
    public float handBrakeFrictionMultiplier = 2;


    // Start is called before the first frame update
    void Start()
    {
        getObjects();

    }

    // Update is called onces per frame
    private void FixedUpdate()
    {
        animateWheels();
        moveVehicle();
        steerVehicle();
        addDownForce();
        getFriction();
        adjustTraction();
        keyboardDrive();

    }
    private void keyboardDrive()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        handbrake = (Input.GetAxis("Jump") != 0) ? true : false;
    }



    private void moveVehicle()
    {
        if (drive == driveType.allWheelDrive)
        {
            //We add torque to the wheels/wheelcolliders, it divides the torque in 4. and it delivers power to backwheels
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = vertical * (motorTorque / 4);
            }
        }
        else if (drive == driveType.rearWheelDrive)
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = vertical * (motorTorque / 2);
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].motorTorque = vertical * (motorTorque / 2);
            }
        }


        // if (IM.handbrake)
        //  {
        //      wheels[3].brakeTorque = wheels[2].brakeTorque = brakePower;
        // } else
        // {
        //    wheels[3].brakeTorque = wheels[2].brakeTorque = 0;

        //  }
        KPH = rigidbody.velocity.magnitude * 1f;




    }

    private void steerVehicle()
    {

        //Ackerman Turning, Turns one wheel more than the others, so it turns better

        if (horizontal > 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * horizontal;

        }
        else if (horizontal < 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius - (1.5f / 2))) * horizontal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (radius + (1.5f / 2))) * horizontal;

        }
        else
        {
            wheels[0].steerAngle = 0;
            wheels[1].steerAngle = 0;
        }


    }



    void animateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }

    private void getObjects()
    {
        IM = GetComponent<InputManager>();
        rigidbody = GetComponent<Rigidbody>();
        centerOfMass = GameObject.Find("mass");
        rigidbody.centerOfMass = centerOfMass.transform.localPosition;

    }

    private void addDownForce()
    {
        rigidbody.AddForce(-transform.up * addDownForceValue * rigidbody.velocity.magnitude);
    }

    private void getFriction()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            WheelHit wheelHit;
            wheels[i].GetGroundHit(out wheelHit);

            slip[i] = wheelHit.forwardSlip;
        }
    }


    public float handBrakeFriction = 0;

    void adjustTraction()
    {

        if (!handbrake)
        {
            forwardFriction = wheels[0].forwardFriction;
            sidewaysfriction = wheels[0].sidewaysFriction;

            forwardFriction.extremumValue = forwardFriction.asymptoteValue = ((KPH * handBrakeFrictionMultiplier) / 300) + 1;
            sidewaysfriction.extremumValue = sidewaysfriction.extremumValue = ((KPH * handBrakeFrictionMultiplier) / 300) + 1;

            for (int i = 0; i < 4; i++)
            {
                wheels[i].forwardFriction = forwardFriction;
                wheels[i].sidewaysFriction = sidewaysfriction;
            }
        }
        else if (handbrake)
        {
            sidewaysfriction = wheels[0].sidewaysFriction;
            forwardFriction = wheels[0].forwardFriction;

            float velocity = 0;
            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = Mathf.SmoothDamp(sidewaysfriction.asymptoteValue, handBrakeFriction, ref velocity, 0.05f * Time.deltaTime);
            forwardFriction.extremumValue = forwardFriction.asymptoteValue = Mathf.SmoothDamp(sidewaysfriction.asymptoteValue, handBrakeFriction, ref velocity, 0.05f * Time.deltaTime);

            for (int i = 2; i < 4; i++)
            {
                wheels[i].forwardFriction = forwardFriction;
                wheels[i].sidewaysFriction = sidewaysfriction;
            }
            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = 1.5f;
            forwardFriction.extremumValue = forwardFriction.asymptoteValue = 1.5f;

            for (int i = 0; i < 2; i++)
            {
                wheels[i].sidewaysFriction = sidewaysfriction;
                wheels[i].sidewaysFriction = sidewaysfriction;
            }
        }
    }
}

