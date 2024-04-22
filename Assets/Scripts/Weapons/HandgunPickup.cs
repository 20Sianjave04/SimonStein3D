using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun;
    public GameObject fakeHandgun;
    public GameObject pickUpDisplay;
    public AudioSource handgunPickupSound;
    public GameObject pistolImage;
    public bool isArmed = false;

    void OnTriggerEnter(Collider other)
    {
        if(isArmed == true)
        {
            if (realHandgun.name == "RealHandGun")
            {
                string toDeactivate = "RealLegendaryGun";
                GameObject objectToDeactivate = GameObject.Find(toDeactivate);
                objectToDeactivate.SetActive(false);

            }
            else
            {
                string toDeactivate = "RealHandGun";
                GameObject objectToDeactivate = GameObject.Find(toDeactivate);
                objectToDeactivate.SetActive(false);
            }

        }
        isArmed = true;
        realHandgun.SetActive(true);
        fakeHandgun.SetActive(false);
        handgunPickupSound.Play();
        GetComponent<BoxCollider>().enabled = false;
        pickUpDisplay.SetActive(false);
        pickUpDisplay.GetComponent<Text>().text = "M9";
        pickUpDisplay.SetActive(true);
        pistolImage.SetActive(true);

    }
}
