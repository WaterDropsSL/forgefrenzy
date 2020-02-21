using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class HighScoreManager : MonoBehaviour {

	const string privateCode = "uHZBpz5_wkq4WfbAcgMhIgpHJnEodAMkmiH7UJkAOh4w";
	const string publicCode = "5e482a0afe232612b832238e";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;  
	static HighScoreManager instance;
	
	void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
	}

	public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
        UnityWebRequest request = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

		if (string.IsNullOrEmpty(request.error)) {
			print ("Upload Successful");
			DownloadHighscores();
		}
		else {
			print ("Error uploading: " + request.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
        UnityWebRequest request = new UnityWebRequest(webURL + publicCode + "/pipe/");
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
		
		if (string.IsNullOrEmpty (request.error)) {
            print(request.downloadHandler.text);
            this.FormatHighscores(request.downloadHandler.text);
            //ºplay = GetComponent<DisplayHighscores>();
            DisplayHighscores dH = FindObjectOfType<DisplayHighscores>();
            dH.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print("Error Downloading: " + request.error);
		}
	}

	private void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
			print (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}
