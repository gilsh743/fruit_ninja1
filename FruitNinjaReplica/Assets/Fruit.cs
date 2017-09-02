using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {
	
	public GameObject slicedFruitPrefab;
	public float startForce = 5f;
	Rigidbody2D rb;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}
	
	void OnTriggerEnter2D(Collider2D collider2D){
		if(collider2D.tag == "Blade"){
			Debug.Log("HIT");
			Vector3 direction = (collider2D.transform.position - transform.position).normalized;
			Quaternion rotation = Quaternion.LookRotation(direction);
			GameObject slicedFruit = Instantiate(slicedFruitPrefab, transform.position, rotation);
			Destroy(gameObject);
			Destroy(slicedFruit, 5f);
		}
	}
	
}
