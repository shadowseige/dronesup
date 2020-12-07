using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public DroneController controller;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            controller.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            

        }
    }
}
