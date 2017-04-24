using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour {
	// platformGenerator object
	public Transform platformGenerator;
	// Starting point of platformGenerator
	private Vector3 platformStartingPoint;

	// PlayerController script
	public PlayerController myPlayer;
	// Starting point of player script
	private Vector3 playerStartPoint;

	// List of platforms with PlatformDeleter attached to them
	private PlatformDeleter[] platformList;

	private ScoreManager myScoreManager;
	// Use this for initialization
	void Start () {
		// Initialize starting points
		platformStartingPoint = platformGenerator.position;
		playerStartPoint = myPlayer.transform.position;

		myScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restartGame(){
		StartCoroutine("RestartGameCo");
	}

	public IEnumerator RestartGameCo(){
		// We don't want the score to increase after death
		myScoreManager.scoreInc = false;
		// Set player to false
		myPlayer.gameObject.SetActive (false);
		// Wait 0.5 seconds before resetting, so the platforms get destroyed at the same time the player gets reset
		yield return new WaitForSeconds (0.5f);
		// Find objects with PlatformDeleter
		platformList = FindObjectsOfType<PlatformDeleter> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList[i].gameObject.SetActive(false);
		}
		// Change the starting points of Player and platformGenerator
		myPlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartingPoint;
		myPlayer.gameObject.SetActive (true);
		// We want to change the score back to 0 after the player goes back to the start, not right after death
		myScoreManager.scoreCount = 0;
		myScoreManager.scoreInc = true;
	}
}
