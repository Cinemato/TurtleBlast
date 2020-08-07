using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI starsText;
    [SerializeField] GameObject newScoreText;

    public void showLoseMenu(bool newScore)
    {       
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        starsText.text = Currency.currentStars.ToString();
        scoreText.text = ScoreManager.currentScore.ToString();

        if (newScore)
            newScoreText.SetActive(true);

        gameObject.SetActive(true);
    }
}
