using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanels : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject leaderboardCanvas;
    [SerializeField] GameObject infoBoardCanvas;
    [SerializeField] AudioClip selectSound;
    [SerializeField] GameObject leaderboardHelpText;
    [SerializeField] GameObject infoBoardHelpText;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstTime", 0) == 0)
            infoBoardHelpText.SetActive(true);

        if (PlayerPrefs.GetInt("hasName", 1) == 1 && PlayerPrefs.GetInt("Highscore", 0) > 0)
            leaderboardHelpText.SetActive(true);
    }

    public void switchToLB()
    {
        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("Highscore"));
        }

        leaderboardHelpText.SetActive(false);
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

        PlayerPrefs.SetInt("FirstTime", 1);
        infoBoardHelpText.SetActive(false);
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
