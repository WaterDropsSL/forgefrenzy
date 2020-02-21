using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int level = 1;
    private int score = 0;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitGame() { 
        
    }

    public void handleGameOver() {
        print("Gameover!");
        int score = ScoreManager.instance.getScore();
        print("FINAL SCORE: " + score);
        PlayerPrefs.SetInt("finalScore", score);

        string username = PlayerPrefs.GetString("username");

        int bestScore = PlayerPrefs.GetInt("bestScore");
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        HighScoreManager.AddNewHighscore(username, score);
    }
}
