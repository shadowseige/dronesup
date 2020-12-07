using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holder;
    public GameObject Appear;
    public GameObject sourceMarker;
    public GameObject destinationMarker;
    public GameObject sourcePlatform;
    //if(Input.GetKey(KeyCode.P))
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            
            //this.transform.position = holder.position;
            //this.transform.parent = GameObject.Find("Holder").transform;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<MeshRenderer>().enabled = false;
            Appear = GameObject.FindGameObjectWithTag("PickUpObject");
            Appear.GetComponent<MeshRenderer>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;


            sourcePlatform = GameObject.FindGameObjectWithTag("SourcePlatform");
            sourcePlatform.GetComponent<MeshRenderer>().enabled = false;

            sourceMarker = GameObject.FindGameObjectWithTag("SourceMarker");
            sourceMarker.GetComponent<MeshRenderer>().enabled = false;

            destinationMarker = GameObject.FindGameObjectWithTag("DestinationMarker");
            destinationMarker.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    //void OnMouseDown()
    //{
    //    GetComponent<Rigidbody>().useGravity = false;

    //    this.transform.position = holder.position;
    //    this.transform.parent = GameObject.Find("Holder").transform;

    //}


    //void OnMouseUp()
    //{
    //    this.transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //    GetComponent<Rigidbody>().isKinematic = false;
    //}


}
