using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HalfHealthCollect : MonoBehaviour
{
   
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        GlobalHealth.healthValue += 50;
        if (GlobalHealth.healthValue > 100)
        {
            GlobalHealth.healthValue = 100;
        }
        collectSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        this.gameObject.SetActive(false);
    }
}

