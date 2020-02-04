using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    private float originalTimer;
    private int currentProgress = 0;

    public float timer = 2.00f;
    public GameObject scoreManager;
    public Sprite[] timerSprites;

    void Start() {
        originalTimer = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        int progress = Mathf.FloorToInt((1 - timer / originalTimer) / 0.125f);

        if (timer <= 0)
        {
            handleGameOver();
        }

        if (progress > currentProgress) {
            print("[-] " + progress);
            updateTimerSprites(progress);
        }


    }

    void handleGameOver() {
        print("Gameover!");
        int score = scoreManager.GetComponent<ScoreManager>().getScore();
        print("FINAL SCORE: " + score);
        PlayerPrefs.SetInt("finalScore", score);

        int bestScore = PlayerPrefs.GetInt("bestScore");
        if (score > bestScore) {
            PlayerPrefs.SetInt("bestScore", score);
        }

        
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void updateTimerSprites(int progress)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = timerSprites[progress];
        currentProgress = progress;
    }

} 