using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play clicked");
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }
}