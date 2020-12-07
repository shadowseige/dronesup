using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Appear;

    private void OnTriggerEnter()
    {
        Appear = GameObject.FindGameObjectWithTag("PickUpObject");
        //
        if (Appear.GetComponent<MeshRenderer>().enabled && (Collectible.countCollect == Collectible.totalCollectibles))
        {
            gameManager.CompleteLevel();
        }
        else
        {
            gameManager.EndGame();
        }
        
    }
}
