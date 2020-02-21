using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public AudioClip playAudio;
    //public AudioClip menuMusic;
    public TextMeshProUGUI lastScore;
    public TextMeshProUGUI bestScoreText;
    public LevelChanger levelChanger;

    public TextMeshProUGUI usernameText;
    public TextMeshProUGUI placeHolderUsernameText;

    public void Start()
    {
        int score = PlayerPrefs.GetInt("finalScore");
        int bestScore = PlayerPrefs.GetInt("bestScore");
        int played = PlayerPrefs.GetInt("hasPlayed");

        string username = PlayerPrefs.GetString("username");

        if (played > 0)
        {
            this.lastScore.text = "Last score: " + score.ToString();
            this.bestScoreText.text = "Best score: " + bestScore.ToString();
        }

        if (!string.IsNullOrEmpty(username))
        {
            placeHolderUsernameText.enabled = false;
            usernameText.text = username;
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

    public void setUsername(string newUsername)
    {
        if (!string.IsNullOrEmpty(newUsername)) {
            print("Setting username: " + newUsername);
            PlayerPrefs.SetString("username", newUsername);
        }
    }
}
