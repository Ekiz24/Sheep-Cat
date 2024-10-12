using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject pauseScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
                pauseScreen.SetActive(true);
            }
            else
            {
                PauseGameMethod();
                pauseScreen.SetActive(false);
            }
        }
    }

    void PauseGameMethod()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
