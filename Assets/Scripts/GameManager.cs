using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public string[] objectNames;
    
    private int score = 0;
    private string currentTarget;

    void Start()
    {
        ChooseRandomTarget();
        InvokeRepeating("TimeControl", 0f, 1f);
    }

    void TimeControl()
    {
        int time = int.Parse(timeText.text);

        if (time > 0)
        {
            time--;
            timeText.text = time.ToString();
        }
        else if (time == 0)
        {
            timeText.text = "5";
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
        if (objectName == currentTarget)
        {
            score++;
            timeText.text = "5";
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