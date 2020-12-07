using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;


    private Rigidbody myDrone;

    private void Start()
    {
        myDrone = GetComponent<Rigidbody>();
        droneSound = gameObject.transform.Find("drone_sound").GetComponent<AudioSource>();
    }



    private void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        ClampingSpeedValues();
        Swerve();
        DroneSound();

        myDrone.AddRelativeForce(Vector3.up * upForce);
        myDrone.rotation = Quaternion.Euler(
                new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways)
            );

        if(myDrone.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }


    public float upForce;

    private void MovementUpDown()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            if (Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.K))
            {
                myDrone.velocity = myDrone.velocity;
            }

            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
            {
                myDrone.velocity = new Vector3(myDrone.velocity.x, Mathf.Lerp(myDrone.velocity.y, 0, Time.deltaTime * 5), myDrone.velocity.z);
                upForce = 20;
            }

            if (!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K) && (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.J)))
            {
                myDrone.velocity = new Vector3(myDrone.velocity.x, Mathf.Lerp(myDrone.velocity.y, 0, Time.deltaTime * 5), myDrone.velocity.z);
                upForce = 20;
            }

            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
            {
                upForce = 50;
            }
        }


        if (Input.GetKey(KeyCode.I))
        {
            upForce = 200;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
            {
                upForce = 20;
            }
        }

        else if (Input.GetKey(KeyCode.K))
        {
            upForce = -5;
        }

        else if (!Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.K) && (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f))
        {
            upForce = 98.1f;
        }


    }


    private float movementForwardSpeed = 25.0f;
    private float tiltAmountForward = 0;
    private float tiltVelocityForward;

    private void MovementForward()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            myDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);
        }
    }


    private float wantedYRotation;
    [HideInInspector] public float currentYRotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYRotation -= rotateAmountByKeys;
        }

        if (Input.GetKey(KeyCode.L))
        {
            wantedYRotation += rotateAmountByKeys;
        }

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }


    private Vector3 velocityToSmoothDampZero;
    private void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            myDrone.velocity = Vector3.ClampMagnitude(myDrone.velocity, Mathf.Lerp(myDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            myDrone.velocity = Vector3.ClampMagnitude(myDrone.velocity, Mathf.Lerp(myDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            myDrone.velocity = Vector3.ClampMagnitude(myDrone.velocity, Mathf.Lerp(myDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            myDrone.velocity = Vector3.SmoothDamp(myDrone.velocity, Vector3.zero, ref velocityToSmoothDampZero, 0.95f);
        }
    }


    private float sideMovementAmount = 300.0f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;

    private void Swerve()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            myDrone.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20 * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }

        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }

    private AudioSource droneSound;
    void DroneSound()
    {
        droneSound.pitch = 1 + (myDrone.velocity.magnitude / 10);
    }



}