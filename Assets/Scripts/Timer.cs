using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public float timer = 2.00f;
        
    void Update()
    {
        timer -= Time.deltaTime;
        if ( timer <= 0)
        {
            print("Gameover!");
            SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
        }
    }
} 