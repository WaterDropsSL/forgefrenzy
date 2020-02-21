using UnityEngine;
using System.Collections;
using TMPro;

public class DisplayHighscores : MonoBehaviour {

    public TextMeshProUGUI[] usernameFields;
    public TextMeshProUGUI[] highscoreFields;
    HighScoreManager highscoreManager;

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i + 1 + ". Fetching...";
		}

				
		highscoreManager = FindObjectOfType<HighScoreManager>();
		StartCoroutine("RefreshHighscores");
	}
	    
	public void OnHighscoresDownloaded(Highscore[] highscoreList) {
		for (int i = 0; i < highscoreFields.Length; i ++) {
            usernameFields[i].text = i + 1 + ". ";
            if (i < highscoreList.Length)
            {
                highscoreFields[i].enabled = true;
                usernameFields[i].enabled = true;
                usernameFields[i].text += highscoreList[i].username;
                highscoreFields[i].text = " ----- " + highscoreList[i].score;
            }
            else {
                usernameFields[i].enabled = false;
                highscoreFields[i].enabled = false;
            }
		}
    }
	
	IEnumerator RefreshHighscores() {
		while (true) {
			highscoreManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}
