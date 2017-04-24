using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {
	// ObjectPooler for coins
	public ObjectPooler coinPool;

	// Set coin placements for PlatformJumper
	public void spawnCoins(Vector3 startPosition){
		// Get the GameObject that's false
 		GameObject coin1 = coinPool.getPooledObject ();
		// Set the position
		coin1.transform.position = startPosition;
		// Set as active
		coin1.SetActive (true);

		GameObject coin2 = coinPool.getPooledObject ();
		coin2.transform.position = new Vector3(startPosition.x, startPosition.y + 2f, startPosition.z);
		coin2.SetActive (true);

		GameObject coin3 = coinPool.getPooledObject ();
		coin3.transform.position = new Vector3(startPosition.x - 1f, startPosition.y + 2f, startPosition.z);
		coin3.SetActive (true);

		GameObject coin4 = coinPool.getPooledObject ();
		coin4.transform.position = new Vector3(startPosition.x - 2f, startPosition.y + 2f, startPosition.z);
		coin4.SetActive (true);

		GameObject coin5 = coinPool.getPooledObject ();
		coin5.transform.position = new Vector3(startPosition.x + 3f, startPosition.y + 3f, startPosition.z);
		coin5.SetActive (true);
	}
}
