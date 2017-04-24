using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {
	// The platform objects
	public GameObject pooledObject;
	// How many platforms to pool
	public int pooledAmount;
	// List of pooled platforms
	List<GameObject> pooledObjects;
	// Use this for initialization
	void Start () {
		// Initialize pooledObjects
		pooledObjects = new List<GameObject>();
		// Set all 5 platforms' active as false and add it to the list
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}
	// For the PlatformGenerator script to use
	public GameObject getPooledObject(){
		// Check the first item in the list that is not active and return it
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}
		// If all of them are active, make another one and add it to the list
		GameObject obj = (GameObject)Instantiate(pooledObject);
		obj.SetActive(false);
		pooledObjects.Add(obj);
		return obj;
	}
}
