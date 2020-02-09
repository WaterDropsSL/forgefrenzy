using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public AudioClip playAudio;
    //public AudioClip menuMusic;
    public Text countText;
    public Text bestScoreText;
    public LevelChanger levelChanger;

    public void Start()
    {
        int score = PlayerPrefs.GetInt("finalScore");
        int bestScore = PlayerPrefs.GetInt("bestScore");
        int played = PlayerPrefs.GetInt("hasPlayed");
        

        if (played > 0)
        {
            this.countText.text = "Last score: " + score.ToString();
            this.bestScoreText.text = "Best score: " + bestScore.ToString();
        }

    }
    public void playGame()
    {
        print("play sound");
        bool hasPlayed=true;
        //AudioSource.PlayClipAtPoint(playAudio, transform.position);
        PlayerPrefs.SetInt("hasPlayed", (hasPlayed ? 1 : 0));
        levelChanger.fadeToLevel(1);   
    }

    public void options()
    {

    }

    public void exitGame()
    {
        Application.Quit();
    }
}
