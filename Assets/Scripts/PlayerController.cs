using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// Player move speed
	public float moveSpeed;
	// Player jump force
	public float jumpForce;

	private Rigidbody2D myRigidbody;
	// all related to jumping
	public Transform groundCheck;
	public float groundCheckRadius;
	private bool onGround;
	public LayerMask groundObjects;
	private bool canDoubleJump;
	public float jumpTime;
	private float jumpTimeCounter;

	// Every time this much distance is covered increase the speed
	public float speedIncreasePoints;
	// Speed multiplier
	public float speedMult;
	// The current place where the speed should increase
	private float speedIncreaseCounter;
	// Save the default move speed for when game resets
	private float moveSpeedSave;
	// Save the speed increase points for when game resets
	private float speedIncreasePointsSave;
	// Animator
	private Animator myAnimator;

	public ScreenManager myScreenManager; 
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		myAnimator = GetComponent<Animator> ();
		// Set the speed increase counter
		speedIncreaseCounter = speedIncreasePoints;
		// Time allowed for jumps
		jumpTimeCounter = jumpTime; 
		// Save points
		speedIncreasePointsSave = speedIncreasePoints;

		moveSpeedSave = moveSpeed;
	}
	void FixedUpdate(){
		// Check if on ground
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundObjects);
	}
	// Update is called once per frame
	void Update () {
		// Move the character along the x axis
		myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
		// If the player passed the speedIncreaseCounter point and the moveSpeed is less than capped amount
		if (transform.position.x > speedIncreaseCounter && moveSpeed < 5) {
			// Change the speedIncreaseCounter
			speedIncreaseCounter += speedIncreasePoints;
			// Increase the movespeed
			moveSpeed = moveSpeed * speedMult;
		}
		// If space or mouse key is pressed
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			// If the player is on the ground
			if(onGround){
				// Make the player jump
				myRigidbody.velocity = new Vector2(moveSpeed, jumpForce);
				// Set double jump to true
				canDoubleJump = true;
			}
			else{
				// Case of double jump
				if(canDoubleJump){
					myRigidbody.velocity = new Vector2(moveSpeed, jumpForce);
					canDoubleJump = false;
				}
			}
		}
		// This is to limit the player's jumping but also make it more versatile
		// If the jump key is held down the player can jump higher, compared to just tapping it
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)) {
			// Jump height using jumpTimeCounter
			if(jumpTimeCounter > 0){
				myRigidbody.velocity = new Vector2(moveSpeed, jumpForce);
				// Subtract using seconds time lapse
				jumpTimeCounter -= Time.deltaTime;
			}
		}
		// When the player lets go of the jump key, and they cannot double jump, make the jumpTimeCounter zero
		if ((Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0)) && !canDoubleJump) {
			jumpTimeCounter = 0;
		}

		if (onGround) {
			// Reset jump timer
			jumpTimeCounter = jumpTime;
		}
		// For animation
		// If the speed is greater than zero, running animation
		myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
		// If player is not on the ground, jump animation
		myAnimator.SetBool ("Grounded", onGround);
		// If the player can double jump, double jump animation
		myAnimator.SetBool ("doubleJump", canDoubleJump);
	}

	// If death, implement later
	void onCollisionEnter2D(Collision2D other){
		moveSpeed = moveSpeedSave;
		speedIncreasePoints = speedIncreasePointsSave;
	}
}
