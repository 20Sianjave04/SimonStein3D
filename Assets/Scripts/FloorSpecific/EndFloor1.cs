using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFloor1 : MonoBehaviour
{
    public static bool isDone = false;
    public GameObject fadeOut;
    public GameObject completePanel;
    public GameObject thePlayer;
    public GameObject floorTimer;
    public GameObject soldierOne;
    public GameObject soldierTwo;
    public GameObject soldierThree;

    void OnTriggerEnter(Collider other)
    {
        isDone = true;
        StartCoroutine(CompletedFloor());
        thePlayer.GetComponent<FirstPersonController>().enabled = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator CompletedFloor()
    {
        fadeOut.SetActive(true);
        GlobalComplete.nextFloor += 1;
        PlayerPrefs.SetInt("SceneToLoad", GlobalComplete.nextFloor);
        PlayerPrefs.SetInt("Lives", GlobalLife.lifeValue);
        PlayerPrefs.SetInt("Score", GlobalScore.scoreValue);
        PlayerPrefs.SetInt("Ammo", GlobalAmmo.handgunAmmo);
        soldierOne.SetActive(false);
        soldierTwo.SetActive(false);
        soldierThree.SetActive(false);


        yield return new WaitForSeconds(2);
        completePanel.SetActive(true);
        yield return new WaitForSeconds(5);
        GlobalScore.scoreValue = 0; 
        GlobalComplete.enemyCount = 0;  
        GlobalComplete.treasureCount = 0;
        
        if (GlobalComplete.nextFloor >= 5)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(3);
        }
        SceneManager.LoadScene(GlobalComplete.nextFloor);
        
        isDone = false;
    }
}
