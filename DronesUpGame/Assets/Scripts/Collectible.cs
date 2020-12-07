using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class Collectible : MonoBehaviour
//{
//    //Collectibles
//    public GameObject collectibleScoreText;
//    public float collectScore = 0;
//    public float countCollect = 0;
//    public AudioSource collectSound;



//    void OnTriggerEnter(Collider other)
//    {
//        collectSound.Play();
//        collectScore += 50;
//        countCollect += 1;
//        collectibleScoreText.GetComponent<Text>().text = "Collect Score:" + collectScore;
//        Destroy(gameObject);

//    }
//}

public class Collectible : MonoBehaviour
{
    //Collectibles
    public GameObject collectibleScoreText;
    public  static float collectScore = 0;
    public static float countCollect = 0;
    public static float totalCollectibles = 0;
    public float totalCollectiblesInput;


    void Update()
    {
        totalCollectibles = totalCollectiblesInput;
       
        collectibleScoreText.GetComponent<Text>().text = "Cells Collected: " + countCollect + "/" + totalCollectibles;
        //Debug.Log(countCollect);

    }
}
