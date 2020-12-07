using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGems : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectSound.Play();
            Collectible.collectScore += 50;
            Collectible.countCollect += 1;

            Destroy(gameObject);
        }
            

    }


    //void OnCollisionEnter(Collision collisionInfo)
    //{
    //    if(collisionInfo.collider.tag == "Player")
    //    {
    //        //collectSound.Play();
    //        //Collectible.collectScore += 50;
    //        //Collectible.countCollect += 1;

    //        //Destroy(gameObject);
    //        Debug.Log(collisionInfo.collider.tag);
    //    }


    //}
}
