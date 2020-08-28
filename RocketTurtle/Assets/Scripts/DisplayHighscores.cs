using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighscores : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI[] highscoreText;
    Leaderboard leaderboardManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        for(int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ", Fetching,,,";
        }

        leaderboardManager = GetComponent<Leaderboard>();

        StartCoroutine(refreshHighscores());
    }

    public void onHighscoresDownloaded(Leaderboard.highscore[] highscoreList)
    {
        if(gameObject != null)
        {
            if (PlayerPrefs.GetInt("isInLeaderboard", 1) == 0) //0 = true, 1 = false
            {
                for (int i = 0; i < highscoreText.Length; i++)
                {
                    highscoreText[i].text = i + 1 + ",";
                    if (highscoreList.Length > i)
                    {
                        highscoreText[i].text += highscoreList[i].username + ":" + highscoreList[i].score;
                        if (highscoreList[i].username == PlayerPrefs.GetString("playerName"))
                        {
                            highscoreText[i].color = Color.green;
                        }

                        else
                            highscoreText[i].color = Color.white;
                    }
                }
            }
        }            
    }


    IEnumerator refreshHighscores()
    {
        while(true)
        {
            leaderboardManager.downloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }

}
