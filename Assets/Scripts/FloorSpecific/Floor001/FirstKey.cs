using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKey : MonoBehaviour
{
    public GameObject keyUI;
    public GameObject lockTrigger;
    public GameObject theKey;
    public AudioSource keyFX;

    void OnTriggerEnter(Collider other)
    {
        keyUI.SetActive(true);
        lockTrigger.SetActive(true);
        keyFX.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        theKey.SetActive(false);

    }

}
