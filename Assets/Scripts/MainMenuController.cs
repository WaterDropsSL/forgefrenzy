using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public AudioClip playAudio;
    public void Start()
    {
    }
    public void playGame()
    {
        print("play sound");
        //AudioSource.PlayClipAtPoint(playAudio, transform.position);
        SceneManager.LoadScene("MainScene");
    }

    public void options()
    {

    }

    public void exitGame()
    {
        Application.Quit();
    }
}
