using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public static int healthValue;
    public int internalHealth;
    public GameObject hP100;
    public GameObject hP75;
    public GameObject hP50;
    public GameObject hP25;

    private void Start()
    {
        healthValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthValue <= 0)
        {
            SceneManager.LoadScene(1);              
        }



        internalHealth = healthValue;
        healthDisplay.GetComponent<Text>().text = "" + healthValue + "%";

        if (healthValue > 75)
        {
            hP100.SetActive(true);
            hP75.SetActive(false);
            hP50.SetActive(false);
            hP25.SetActive(false);

        }
        if (healthValue < 25)
        {
            hP100.SetActive(false);
            hP75.SetActive(false);
            hP50.SetActive(false);
            hP25.SetActive(true);

        }
        if (healthValue >= 25 && healthValue < 50)
        {
            hP100.SetActive(false);
            hP75.SetActive(false);
            hP50.SetActive(true);
            hP25.SetActive(false);

        }
        if (healthValue >= 50 && healthValue < 75)
        {
            hP100.SetActive(false);
            hP75.SetActive(true);
            hP50.SetActive(false);
            hP25.SetActive(false);

        }

    }
}
