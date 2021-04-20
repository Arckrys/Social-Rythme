using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private AudioSource audio;

    public bool gamePaused = false;

    // Update is called once per frame
    private void Awake()
    {
        audio = BeatGenerator.Instance.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                Time.timeScale = 0f;
                Pause();
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

    void Pause()
    {
        audio.Pause();
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        audio.UnPause();
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
