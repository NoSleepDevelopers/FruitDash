using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	// Text for scores
	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float scorePerSecond;

	// This boolean is for when score should stop increase in the case where player has died
	public bool scoreInc;
	// Use this for initialization
	void Start () {
		// This is to save highscore even if the game is exited
		if(PlayerPrefs.GetFloat("HighScore") != 0){
			highScoreCount = PlayerPrefs.GetFloat("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreInc) {
			// Adds score, Time.deltaTime is per second action
			scoreCount += scorePerSecond + (Time.deltaTime * 5);
		}
		// Display score
		scoreText.text = "Score : " + Mathf.Round(scoreCount);
		// Set highscore
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
			// Save highscore even if game is exited
			PlayerPrefs.SetFloat("HighScore", highScoreCount);
		}
		highScoreText.text = "High Score : " + Mathf.Round(highScoreCount);
	}
	// For other score increases, like collecting coins
	public void IncreaseScore(int score){
		scoreCount += score;
	}
}
