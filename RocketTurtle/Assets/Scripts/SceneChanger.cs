using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] GameObject sceneTransition1;
    [SerializeField] AudioClip selectSound;

    public void mainMenu()
    {
        addHighScore();
        SceneManager.LoadScene(0);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.3f);
    }

    public void gameScene()
    {
        addHighScore();
        sceneTransition1.SetActive(true);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.3f);
        StartCoroutine(waitForTransition());       
    }

    IEnumerator waitForTransition()
    {
        yield return new WaitForSeconds(0.8f);
        ScoreManager.currentScore = 0;
        Currency.currentStars = 0;
        SceneManager.LoadScene(1);
    }

    void addHighScore()
    {
        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("Highscore"));
        }
    }
}
