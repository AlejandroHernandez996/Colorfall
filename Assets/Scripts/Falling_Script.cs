using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Falling_Script : MonoBehaviour {
	
	public float moveSpeed;
	public float deltaMove;
	public float startX;
	public float startY;
	public float endY;
	public int offset;
	public Text comboText;
	public Text scoreText;
	private int score,combo;
	private int random;
	private bool isOver;
	private float direction;
	// START FUCNTION
	void Start(){
		random = 0;
		score = 0;
		combo = 0;
		direction = 1.0f;
		isOver = false;
		transform.position = new Vector2 (startX, startY);
	}
	// Update is called once per frame
	void Update () {

		// CYCLE THROUGH MODES
		if (random == 0) {
			ZigZag ();
			CheckBottom ();
		} else if (random == 1) {
			Fall ();
			CheckBottom ();
		} else if(random == 2){
			Rise ();
			CheckTop ();
		}

		if (Input.GetMouseButtonDown (0) && !isOver && moveSpeed > 1.0f) {
			moveSpeed -= deltaMove;
			combo = 0;
			score--;
			SetText ();
		}
		print (moveSpeed);
	}
	// FALLING MODE
	void Fall(){		
		GetComponent<Rigidbody2D>().velocity = Vector2.down *moveSpeed;
	}
	// ZIG ZAG MODE
	void ZigZag(){
		if (GetComponent<Rigidbody2D> ().position.x >= 2.5f)
			direction *= -1;
		else if (GetComponent<Rigidbody2D> ().position.x <= -2.5f)
			direction *= -1;
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed * direction, -moveSpeed);
	}
	// RISE MODE
	void Rise(){
		GetComponent<Rigidbody2D>().velocity = Vector2.up *moveSpeed;
	}
	// RESPAWN 
	void Respawn(float y){
		transform.position = new Vector2 (Random.Range(-2.5f, 2.5f),y);
		random = Random.Range (0, 3);
	}
	// CHECK BOTTOM
	void CheckBottom(){
		if (GetComponent<Rigidbody2D> ().position.y <= endY) {
			Respawn (startY);
		}
	}
	// CHECK TOP
	void CheckTop(){
		if (GetComponent<Rigidbody2D> ().position.y >= startY) {
			Respawn (endY);
		}
	}
	// IS MOUSE ON OBJECT
	void OnMouseOver(){
		isOver = true;
		if (Input.GetMouseButtonDown(0) ){
			moveSpeed += deltaMove;
			score++;
			combo++;
			SetText ();
			Respawn (endY);
		}
	}
	// IS MOUSE EXIT
	void OnMouseExit(){
		isOver = false;
	}
	// SET TEXT
	void SetText(){
		scoreText.text = "Score: " + score.ToString ();
		comboText.text = "Combo: " + combo.ToString ();
	}
}
