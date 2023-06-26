using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScore : MonoBehaviour
{
    public Image imgNewRecord;
    public Text textScore;
    [Space]
    public Image imgGratuliation;
    public Text textknockedPine;
    private bool onResetUI = false;
    private int currentScore;
    private int sumScore;
    private bool firstIntent = true;
    private int countIntent = 0;
    private float time;

    private int highScore;
    private string hightScoreKey;

    void Start()
    {

        if (PlayerPrefs.HasKey(hightScoreKey))
        {
            highScore = PlayerPrefs.GetInt(hightScoreKey);
        }

        imgNewRecord.gameObject.SetActive(false);
        imgGratuliation.gameObject.SetActive(false);

        ManagerScene.OnEventRestart += CountScoreAndUpdateText;
        Pine.OnEventPine += AddScore;
    }


    void Update()
    {
        if (onResetUI)
        {
            time += Time.deltaTime;

            if (time > 3)
            {
                imgNewRecord.gameObject.SetActive(false);
                imgGratuliation.gameObject.SetActive(false);
                time = 0;
                onResetUI = false;
            }
        }
    }

    public void CountScoreAndUpdateText()
    {
        countIntent++;

        if (currentScore == 5)
        {
            sumScore += currentScore * 2;

            if (firstIntent) imgGratuliation.gameObject.SetActive(true);

        }
        else
        {
            sumScore += currentScore;
            firstIntent = false;
        }

        textScore.text = $"{sumScore}";
        currentScore = 0;

        if (highScore < sumScore && countIntent == 2)
        {
            highScore = sumScore;
            PlayerPrefs.SetInt(hightScoreKey, highScore);
            PlayerPrefs.Save();
            imgNewRecord.gameObject.SetActive(true);
        }

        onResetUI = true;

    }


    public void AddScore(int score)
    {
        currentScore += score;
    }




}
