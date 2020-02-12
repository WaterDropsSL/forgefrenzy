using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }
    private int score = 0;
    private int combo = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
        comboText.text = "COMBO: " + combo.ToString() + "x";
    }

    public int getScore() {
        return score;
    }

    public void addScore(int points) {
        combo += 1;
        print("Combo: " + combo.ToString());
        score += points * combo;
        //print("added " + points + " . Total score: " + score);
    }

    public void breakCombo() {
        combo = 0;
    }

}