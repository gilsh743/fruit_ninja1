using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {
	
	public GameObject[] fruitPrefabs;
	public Transform[] spawnPoints;
	private float minDelay = 0.1f;
	private float maxDelay = 1f;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFruits());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator SpawnFruits(){
		while(true){
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);
			int spawnIdx = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIdx];
			int fruitPrefabIdx = Random.Range(0,fruitPrefabs.Length);
			GameObject fruitPrefab = fruitPrefabs[fruitPrefabIdx];
			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}
}
