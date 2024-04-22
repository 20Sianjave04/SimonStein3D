using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecycleLevel : MonoBehaviour
{
    public GameObject gameOver;
    void Start()
    {
        GlobalLife.lifeValue -= 1;
        if (GlobalLife.lifeValue == 0)
        {
            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            StartCoroutine(GoToMenu());
            StartCoroutine(GoToMenu());

        }
        else
        {
            if (GlobalComplete.nextFloor == 3)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                SceneManager.LoadScene(GlobalComplete.nextFloor);
            }
            
        }     

    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }

   
}
