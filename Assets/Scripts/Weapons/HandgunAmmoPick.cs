using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunAmmoPick : MonoBehaviour
{
    public GameObject ammoClip;
    public AudioSource ammoPickupSound;
    public GameObject pickUpDisplay;

    void OnTriggerEnter(Collider other)
    {
        ammoClip.SetActive(false);
        ammoPickupSound.Play();
        GlobalAmmo.handgunAmmo += 10;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "CLIP OF BULLETS";
        pickUpDisplay.SetActive(true);
    }
}
