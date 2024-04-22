using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource clickSound;
    public GameObject fadeOut;

    public int loadScene = 3;
    public int loadLives;
    public int loadScore;
    public int loadAmmo;
    public void NewGame()
    {

        StartCoroutine(NewGameRoutine());
    }

    IEnumerator NewGameRoutine()
    {
        GlobalComplete.nextFloor = 3;
        GlobalLife.lifeValue = 3;
        GlobalScore.scoreValue = 0;
        GlobalAmmo.handgunAmmo = 0;
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
    
    public void  QuitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        GlobalComplete.nextFloor += 1;
        PlayerPrefs.SetInt("SceneToLoad", 3);
        PlayerPrefs.SetInt("Lives", 0);
        PlayerPrefs.SetInt("Score", 3);
        PlayerPrefs.SetInt("Ammo", 0);
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {

        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine()
    {
        loadScene = PlayerPrefs.GetInt("SceneToLoad");
        loadLives = PlayerPrefs.GetInt("Lives");
        loadScore = PlayerPrefs.GetInt("Score");
        loadAmmo =  PlayerPrefs.GetInt("Ammo");
        clickSound.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        GlobalComplete.nextFloor = loadScene;
        GlobalLife.lifeValue = loadLives;
        GlobalScore.scoreValue = loadScore;
        GlobalAmmo.handgunAmmo = loadAmmo;
        SceneManager.LoadScene(loadScene);
    }
}
