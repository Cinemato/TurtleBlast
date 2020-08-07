using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] GameObject sceneTransition1;

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void gameScene()
    {
        sceneTransition1.SetActive(true);
        StartCoroutine(waitForTransition());
    }

    IEnumerator waitForTransition()
    {
        yield return new WaitForSeconds(0.8f);
        ScoreManager.currentScore = 0;
        Currency.currentStars = 0;
        SceneManager.LoadScene(1);
    }
}
