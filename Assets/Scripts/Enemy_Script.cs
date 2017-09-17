using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Enemy_Script : MonoBehaviour {

	public float moveSpeed;
	public float startX;
	public float startY;
	public float endY;
	// START FUCNTION
	void Start(){
		GetComponent<SpriteRenderer>().material.SetColor("_Color",new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1f));
		transform.position = new Vector2 (startX, startY);
	}
	// Update is called once per frame
	void Update () {
		Fall ();
		CheckBottom ();
			
	}
	// FALLING MODE
	void Fall(){		
		GetComponent<Rigidbody2D>().velocity = Vector2.down *moveSpeed;
	}
	// RESPAWN 
	void Respawn(float y){
		GetComponent<SpriteRenderer>().material.SetColor("_Color",new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1f));
		transform.position = new Vector2 (Random.Range(-2.5f, 2.5f),Random.Range(0.0f,7.0f));
	}
	// IS MOUSE ON OBJECT
	void OnMouseOver(){
		if (Input.GetMouseButtonDown(0) ){
			Scene scene = SceneManager.GetActiveScene ();
			SceneManager.LoadScene (scene.name);
		}
	}
	// CHECK BOTTOM
	void CheckBottom(){
		if (GetComponent<Rigidbody2D> ().position.y <= endY) {
			Respawn (startY);
		}
	}
}
