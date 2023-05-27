using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public static bool winBool = false;
    public static bool loseBool = false;

    public GameObject pauseMenu;
    public GameObject winUI;
    public GameObject loseUI;

    public static bool watchFish = false;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject scoreText;
    public GameObject timerText;
    public GameObject tankCamera;

    public void Start()
    {
        gameIsPaused = false;
        winBool = false;
        loseBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(winBool)
        {
            winUI.SetActive(true);
        }

        if (loseBool)
        {
            loseUI.SetActive(true);
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Retry()
    {
        ScoreText.score = 0;
        SceneManager.LoadScene("FishTank");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void WatchFishButton()
    {
        if (!watchFish)
        {
            player.SetActive(false);
            playerCamera.SetActive(false);
            scoreText.SetActive(false);
            timerText.SetActive(false);
            tankCamera.SetActive(true);
            watchFish = true;
            Resume();
        }
        else
        {
            player.SetActive(true);
            playerCamera.SetActive(true);
            scoreText.SetActive(true);
            timerText.SetActive(true);
            tankCamera.SetActive(false);
            watchFish = false;
            Resume();
        }
    }

}
