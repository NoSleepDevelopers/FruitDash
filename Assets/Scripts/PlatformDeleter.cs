using UnityEngine;
using System.Collections;

public class PlatformDeleter : MonoBehaviour {
	public GameObject deletionPoint;
	void Start () {
		// Find the deletion point
		deletionPoint = GameObject.Find("PlatformDeletionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		// If the deletionPoint goes beyond the current platform postion the platform is deleted
		if (transform.position.x < deletionPoint.transform.position.x) {
			// Deactivate that platform
			gameObject.SetActive(false);
		}
	}
}
