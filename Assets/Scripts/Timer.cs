using UnityEngine;

public class Timer : MonoBehaviour {
    private float originalTimer;
    private int currentProgress = 0;
    private float divideAmount = 0.125f;

    public float timer = 2.00f;
    public Sprite[] timerSprites;

    void Start() {
        originalTimer = timer;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        int progress = Mathf.FloorToInt((1 - timer / originalTimer) / divideAmount);

        if (timer <= 0)
        {
            GameManager.instance.handleGameOver();
        }

        if (progress > currentProgress) {
            print("[-] " + progress);
            updateTimerSprites(progress);
        }


    }

    private void updateTimerSprites(int progress)
    {
        // TODO: when progress is 8 array out of bounds --> but should never happen since the game should have ended before that
        gameObject.GetComponent<SpriteRenderer>().sprite = timerSprites[progress];
        currentProgress = progress;
    }

} 