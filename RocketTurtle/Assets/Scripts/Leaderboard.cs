using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    const string privateCode = "OhYEwfb-gUaRGq2u2GYkAwIdPrnEfJpEGmzhzeqsEoTg";
    const string publicCode = "5f2bfbe5eb371809c4b0c1b5";
    const string webCode = "http://dreamlo.com/lb/";

    public highscore[] highscoresList;
    DisplayHighscores highscoresDisplay;
    static Leaderboard instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        highscoresDisplay = GetComponent<DisplayHighscores>();
    }

    public static void addNewHighscore(string username, int score)
    {
        if(instance != null)
        {
            instance.StartCoroutine(instance.uploadNewHighscore(username, score));
        }      
    }

    IEnumerator uploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webCode + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if(string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Successful");
            downloadHighscores();
        }

        else
        {
            Debug.LogError("Error Uploading" + www.error);
        }
    }

    public void downloadHighscores()
    {
        StartCoroutine("downloadHighscoresFromDatabase");
    }

    IEnumerator downloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webCode + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            formatHighscores(www.text);
            highscoresDisplay.onHighscoresDownloaded(highscoresList);
        }

        else
        {
            Debug.LogError("Error Downloading" + www.error);
        }
    }

    void formatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }

    }

    public struct highscore
    {
        public string username;
        public int score;
        public highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }

    public static void checkNameAvailability(string input)
    {
        for(int i = 0; i < instance.highscoresList.Length; i++)
        { 
            if(input == instance.highscoresList[i].username)
            {
                PlayerPrefs.SetInt("Available", 1); //1 = false, 0 = true
                return;
            }
        }

        PlayerPrefs.SetInt("Available", 0);

    }
}
