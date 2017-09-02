using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	
	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = 0.001f;
	
	Vector2 previousPosition;
	GameObject currBladeTrail;
	bool isCutting = false;
	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D cc;
	
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		cam = Camera.main;
		cc = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			StartCutting();
		}
		else if(Input.GetMouseButtonUp(0)){
			StopCutting();
		}
		
		if(isCutting){
			UpdateCut();
		}
	}
	
	void StartCutting(){
		isCutting = true;
		currBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		cc.enabled = false;
	}
	
	void StopCutting(){
		isCutting = false;
		cc.enabled = false;
		currBladeTrail.transform.SetParent(null);
		Destroy(currBladeTrail, 2.0f);
	}
	
	void UpdateCut(){
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		rb.position = newPosition;
		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if(velocity > minCuttingVelocity){
			cc.enabled = true;
		}
		else{
			cc.enabled = false;
		}
		previousPosition = newPosition;
	}
}










