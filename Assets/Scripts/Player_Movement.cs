using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour {
	
	public float moveSpeed; //movespeed
		
	private Vector3 mouseVector = new Vector3 ();

	// Update is called once per frame
	void FixedUpdate () {
		
		float inputHorizontal = Input.GetAxisRaw ("Horizontal");
		float inputVertical = Input.GetAxisRaw ("Vertical");


		if (Input.GetMouseButton (0)) {
			/*if (mouseVector.x - .1f > GetComponent<Rigidbody2D> ().position.x) {
				inputHorizontal = 1;
			} else if (mouseVector.x + .1f < GetComponent<Rigidbody2D> ().position.x) {
				inputHorizontal = -1;
			}*/
			// Move player to mouse position
			GetComponent<Rigidbody2D> ().position = new Vector2 (mouseVector.x, GetComponent<Rigidbody2D> ().position.y);
		}	
			//GetComponent<Rigidbody2D> ().velocity = new Vector2 (inputHorizontal, inputVertical) * moveSpeed;
	}
	//Sets mouse coords to screen coords
	void OnGUI(){
		Vector2 mousePos = new Vector2 ();
		Camera c = Camera.main;
		Event e = Event.current;


		mousePos.x = e.mousePosition.x;
		mousePos.y = c.pixelHeight - e.mousePosition.y;

		mouseVector = c.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, c.nearClipPlane));
	}
}
