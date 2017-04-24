using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	// The point on which the new platforms should be generated
	public Transform generationPoint;
	// The pooled platforms
	public ObjectPooler[] objectPools;
	// Width of the pooled platforms
	private float[] platformWidths;
	// Integer to select which platform to generate 
	private int platformSelector;

	private CoinGenerator myCoinGenerator;
	// Use this for initialization
	void Start () {
		myCoinGenerator = FindObjectOfType<CoinGenerator> ();
		platformWidths = new float [objectPools.Length];
		// Get the widths of every platform
		for(int i = 0; i < objectPools.Length; i++){
			platformWidths[i] = objectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// If the generationPoint goes beyond the current platform postion another platform is needed
		if (transform.position.x < generationPoint.position.x) {
			platformSelector = Random.Range(0, objectPools.Length);
			// Add the platform width of each platform to position x
			transform.position = new Vector3(transform.position.x + platformWidths[platformSelector], 
			                                 transform.position.y, transform.position.z);
			// create platform
			GameObject newPlatform = objectPools[platformSelector].getPooledObject();

			newPlatform.transform.position = transform.position;

			newPlatform.transform.rotation = transform.rotation;

			// If the selected platform is PlatformJumper, spawn coins specifically
			if(platformSelector == 3){
				myCoinGenerator.spawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
			}
			// The generated platform pooled is active
			newPlatform.SetActive(true);
		}
	}
}