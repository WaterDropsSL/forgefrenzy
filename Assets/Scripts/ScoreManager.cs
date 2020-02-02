using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getScore() {
        return score;
    }

    public void addScore(int points) {
        score += points;
        print("added " + points + " . Total score: " + score);
    }
}
