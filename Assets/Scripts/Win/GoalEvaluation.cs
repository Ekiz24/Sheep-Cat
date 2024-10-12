using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GoalEvaluation : MonoBehaviour
{
    GameObject[] sheepTag;
    int sheepNumber;
    int goalSheepNumber;

    [SerializeField] GameObject goalPanel;
    [SerializeField] GameObject timerLimit;
    TimerAndScoreController timerScoreController;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        sheepTag = GameObject.FindGameObjectsWithTag("Sheep");
        sheepNumber = sheepTag.Length;
        //Debug.Log("The total number of sheep is " + sheepNumber);
        timerScoreController = timerLimit.GetComponent<TimerAndScoreController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SheepCounter")
        {
            goalSheepNumber ++;
            TellTheNumber();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "SheepCounter")
        {
            goalSheepNumber --;
            TellTheNumber();
        }
    }

    void TellTheNumber()
    {
        //Debug.Log("There are " + goalSheepNumber + " sheep inside");
        if (sheepNumber == goalSheepNumber)
        {
            //Debug.Log("All sheep are inside");
            goalPanel.SetActive(true);
            
            timerScoreController.StopTimer();
            timeText.text = timerScoreController.timeText.text;
            scoreText.text = timerScoreController.score.ToString();
        }
    }
}
