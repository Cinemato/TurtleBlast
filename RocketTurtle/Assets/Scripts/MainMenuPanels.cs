using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanels : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject leaderboardCanvas;
    [SerializeField] GameObject infoBoardCanvas;
    [SerializeField] AudioClip selectSound;

    public void switchToLB()
    {
        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("Highscore"));
        }

        leaderboardCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.3f);
    }

    public void switchToIN()
    {
        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("Highscore"));
        }

        infoBoardCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.3f);
    }

    public void switchToMM()
    {
        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("Highscore"));
        }

        mainMenuCanvas.SetActive(true);
        leaderboardCanvas.SetActive(false);
        infoBoardCanvas.SetActive(false);
        AudioSource.PlayClipAtPoint(selectSound, Camera.main.transform.position, 0.3f);
    }
}
