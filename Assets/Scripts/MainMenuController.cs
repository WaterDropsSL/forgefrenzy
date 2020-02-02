using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public AudioClip playAudio;

    public Text countText;
    public void Start()
    {
        int score = PlayerPrefs.GetInt("finalScore");
        int played = PlayerPrefs.GetInt("hasPlayed");
        if (played > 0)
        {
            this.countText.text = "Last score: " + score.ToString();
        }
        
    }
    public void playGame()
    {
        print("play sound");
        bool hasPlayed=true;
        //AudioSource.PlayClipAtPoint(playAudio, transform.position);
        PlayerPrefs.SetInt("hasPlayed", (hasPlayed ? 1 : 0));
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
