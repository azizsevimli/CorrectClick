using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public string[] objectNames;
    
    private int score = 0;
    private int defaultTime = MenuManager.time;
    private string currentTarget;

    void Start()
    {
        ChooseRandomTarget();
        timeText.text = defaultTime.ToString();
        InvokeRepeating("TimeControl", 0f, 1f);
    }

    void TimeControl()
    {
        int activeTime = int.Parse(timeText.text);

        if (activeTime > 0)
        {
            activeTime--;
            timeText.text = activeTime.ToString();
        }
        else if (activeTime == 0)
        {
            timeText.text = defaultTime.ToString();
            score = 0;
            UpdateScoreText();
            ChooseRandomTarget();
        }
    }

    public void ChooseRandomTarget()
    {
        if (objectNames.Length == 0) return;

        int randomIndex = Random.Range(0, objectNames.Length);
        currentTarget = objectNames[randomIndex];
        targetText.text = currentTarget;
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void CheckObject(string objectName)
    {
        timeText.text = defaultTime.ToString();

        if (objectName == currentTarget)
        {
            score += MenuManager.point;
            UpdateScoreText();
        }
        else
        {
            score = 0;
            UpdateScoreText();
        }

        ChooseRandomTarget();
    }

    void OnDestroy()
    {
        CancelInvoke("TimeControl");
    }
}