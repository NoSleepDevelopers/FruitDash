using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour {
	// How much score a gold coin gives
	public int goldScore;

	private ScoreManager myScoreManager;
	// Use this for initialization
	void Start () {
		// Get the ScoreManager object
		myScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		// If coin collides with Player
		if (other.gameObject.name == "Player") {
			// Increase the score with goldScore amount
			myScoreManager.IncreaseScore(goldScore);
			gameObject.SetActive(false);
		}
	}
}
