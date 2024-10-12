using UnityEngine;
using TMPro;

public class TimerAndScoreController : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isTiming = false;
    private bool isPaused = false;

    public int score = 9999;
    public int maxScore = 9999;
    public int minScore = 0;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;

    private float scoreDecreaseTimer = 0f;
    public float scoreDecreaseInterval = 1f; // 每隔一秒减少一次分数

    private void Start()
    {
        StartTimer();
    }

    void Update()
    {
        if (isTiming && !isPaused)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimeDisplay();
            scoreDecreaseTimer += Time.deltaTime;
            if (scoreDecreaseTimer >= scoreDecreaseInterval && score > minScore)
            {
                score--;
                scoreDecreaseTimer = 0f;
                UpdateScoreDisplay();
            }
        }
    }

    public void StartTimer()
    {
        isTiming = true;
        isPaused = false;
    }

    public void StopTimer()
    {
        isTiming = false;
        isPaused = false;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
    }


    private void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f); // 获取分钟
        int seconds = Mathf.FloorToInt(elapsedTime % 60f); // 获取秒数
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // 显示为MM:SS格式
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = score.ToString();
    }

    public void ResetTimerAndScore()
    {
        elapsedTime = 0f;
        score = maxScore;
        isPaused = false;
        UpdateTimeDisplay();
        UpdateScoreDisplay();
    }
}
