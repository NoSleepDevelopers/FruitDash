using UnityEngine;
using System.Collections;
// This script is to move the camera with the player without changing the y coordinate or z coordinate of the camera
public class CameraController : MonoBehaviour {
	// Player object from the PlayerController script
	public PlayerController thePlayer;
	// This will be used to get the last position the player was in before the position transform
	private Vector3 lastPlayerPosition;
	// The distance of the x coordinate the camera will have to move by
	private float distanceToMove;
	// Use this for initialization
	void Start () {
		// Initialize thePlayer object
		thePlayer = FindObjectOfType<PlayerController>();
		// Initialize lastPlayerPosition coordinates of thePlayer
		lastPlayerPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	// Everytime the player position changes Update is used
	void Update () {
		// distanceToMove is how much the player travelled compared to the last frame
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		// transform.position is the position of the camera, only the x coordinate of the camera is changed
		transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		// update the lastPlayerPosition to current thePlayer position
		lastPlayerPosition = thePlayer.transform.position;
	}
}
