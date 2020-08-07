using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameTransfer : MonoBehaviour
{
    string playerName;
    [SerializeField] GameObject inputField;
    [SerializeField] GameObject leaderBoard;
    [SerializeField] GameObject registerPage;
    [SerializeField] GameObject nameExistText;
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip failSound;
    [SerializeField] int nameCharLimit;



    private void Start()
    {
        PlayerPrefs.SetInt("isInLeaderboard", 0);

        if (PlayerPrefs.GetInt("hasName", 1) == 0)
        {
            switchToLeaderboard();
        }
    }

    private void Update()
    {
        inputField.GetComponent<TMP_InputField>().characterLimit = nameCharLimit;
    }

    public void storeName()
    {
        playerName = inputField.GetComponent<TMP_InputField>().text;
        Leaderboard.checkNameAvailability(playerName);

        if(PlayerPrefs.GetInt("Available") == 0 && playerName != "")
        {                   
            PlayerPrefs.SetString("playerName", playerName);
            PlayerPrefs.SetInt("hasName", 0);
            
            Leaderboard.addNewHighscore(PlayerPrefs.GetString("playerName", playerName), PlayerPrefs.GetInt("Highscore", 0));
            AudioSource.PlayClipAtPoint(successSound, Camera.main.transform.position, 0.7f);
            switchToLeaderboard();
        }

        else
        {
            nameExistText.SetActive(true);
            AudioSource.PlayClipAtPoint(failSound, Camera.main.transform.position, 0.7f);
            return;
        }
            
     
    }

    void switchToLeaderboard()
    {
        leaderBoard.SetActive(true);
        nameExistText.SetActive(false);
        inputField.SetActive(false);
        registerPage.SetActive(false);
    }
}
