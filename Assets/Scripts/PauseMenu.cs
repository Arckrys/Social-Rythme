using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                Time.timeScale = 0f;
                pauseMenuUI.SetActive(true);
            }
            else
            {
                Resume();
            }
        }
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void ExitToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
