using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanels : MonoBehaviour
{
    [SerializeField] GameObject otherCanvas;

    public void changeCanvas()
    {
        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName"), PlayerPrefs.GetInt("Highscore"));
        }

        otherCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
}
