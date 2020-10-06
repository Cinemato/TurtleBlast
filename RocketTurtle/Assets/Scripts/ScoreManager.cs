using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText = null;
    [SerializeField] GameObject newScoreVFX = null;
    [SerializeField] AudioClip newScoreSFX = null;
    [SerializeField] GameObject AdditionAnimation = null;
    [SerializeField] GameObject numberOfWeaponsText = null;
    [SerializeField] PlayerStats ps = null;
    public static int currentScore = 0;
    bool vfxStarted = false;
    TextMeshProUGUI weaponText = null;

    public static ScoreManager instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        weaponText = numberOfWeaponsText.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(ps.getNumberOfWeapons() > 1)
        {
            numberOfWeaponsText.SetActive(true);
            weaponText.text = "x" + ps.getNumberOfWeapons();
        }

        scoreText.text = currentScore.ToString();
        if (currentScore > PlayerPrefs.GetInt("Highscore", 0) && PlayerPrefs.GetInt("Highscore", 0) != 0 && !vfxStarted)
        {
            AudioSource.PlayClipAtPoint(newScoreSFX, Camera.main.transform.position, 0.7f);
            GameObject vfx = Instantiate(newScoreVFX, scoreText.transform.position, Quaternion.identity);
            GameObject vfx2 = Instantiate(newScoreVFX, scoreText.transform.position, Quaternion.identity);
            Destroy(vfx, 3f);
            Destroy(vfx2, 3f);

            vfxStarted = true;
        }
    }

    public static void addToScore(int amount)
    {
        currentScore += amount;           
    }

    public static bool compareScore()
    {
        if (currentScore > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            return true;
        }

        return false;           
    }

    public void additionScore(int score)
    {
        AdditionAnimation.GetComponent<TextMeshProUGUI>().text = "+" + score;
        AdditionAnimation.SetActive(true);
        StartCoroutine(waitOneSecond());
    }

    IEnumerator waitOneSecond()
    {
        yield return new WaitForSeconds(1);
        AdditionAnimation.SetActive(false);
    }
}
