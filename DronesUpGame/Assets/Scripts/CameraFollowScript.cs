using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    private Transform myDrone;

    private void Start()
    {
        myDrone = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private Vector3 velocityCameraFollow;
    public Vector3 behindPosition = new Vector3(0, 2, -10);
    public float angle;
    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, myDrone.transform.TransformPoint(behindPosition) + Vector3.up * Input.GetAxis("Vertical"), ref velocityCameraFollow, 0.1f);
        transform.rotation = Quaternion.Euler(new Vector3(angle, myDrone.GetComponent<DroneController>().currentYRotation, 0));
        
    }
}