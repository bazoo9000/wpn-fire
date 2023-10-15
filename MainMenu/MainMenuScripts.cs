using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripts : MonoBehaviour
{
    public static int _choice;
    public AudioSource _audio;
    public AudioClip _hover;
    public AudioClip _press;

    public void PlayGame()
    {
        RoundSystem._round = 1;
        PressAudio();
        PauseMenuScripts._isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayTutorial()
    {
        PressAudio();
        PauseMenuScripts._isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Quit()
    {
        PressAudio();
        Application.Quit();
    }

    public void PressAudio()
    {
        _audio.PlayOneShot(_press);
    }

    public void HoverAudio()
    {
        _audio.PlayOneShot(_hover);
    }
}
