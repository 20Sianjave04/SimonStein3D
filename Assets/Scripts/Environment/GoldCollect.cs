using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCollect : MonoBehaviour
{
    
    public GameObject goldIngots;
    public GameObject pickUpDisplay;
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        GlobalScore.scoreValue += 500;
        GlobalComplete.treasureCount += 1;
        goldIngots.SetActive(false);
        collectSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "Gold Pyrmid";
        pickUpDisplay.SetActive(true);
        
    }
}
