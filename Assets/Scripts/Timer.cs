using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float timer = 2.00f;
    public GameObject scoreManager;
    void Update()
    {
        timer -= Time.deltaTime;
        if ( timer <= 0)
        {
            handleGameOver();
        }
    }

    void handleGameOver() {
        print("Gameover!");
        int score = scoreManager.GetComponent<ScoreManager>().getScore();
        print("FINAL SCORE: " + score);
        PlayerPrefs.SetInt("finalScore", score);
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }
} 