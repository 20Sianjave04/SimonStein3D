using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject gun;
    public GameObject muzzleFlash;
    public AudioSource gunFX;
    public AudioSource emptyFX;
    public bool isFiring = false;
    public float targetDistance;
    public int damageAmount = 5;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (GlobalAmmo.handgunAmmo < 1)
            {
                emptyFX.Play();
            } else {
                if (!isFiring)
                    StartCoroutine(FiringHandgun());
            }
        }
    }

    IEnumerator FiringHandgun()
    {

        RaycastHit theShot;
        isFiring = true;

        --GlobalAmmo.handgunAmmo;
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theShot))
        {
            targetDistance = theShot.distance;
            theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        

        gun.GetComponent<Animator>().Play("HandgunFire");
        muzzleFlash.SetActive(true);
        gunFX.Play();

        yield return new WaitForSeconds(0.05f);

        muzzleFlash.SetActive(false);

        yield return new WaitForSeconds(0.25f);
        gun.GetComponent<Animator>().Play("New State");

        isFiring = false;
    }
}
