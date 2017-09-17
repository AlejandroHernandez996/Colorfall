using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour {

	public float moveSpeed;
	public float absRangeY;
	public float absRangeX;
	public float increaseSpeed;
	private float xSpawn;
	private float ySpawn;
	private int colorIndex;

	// Moves enemy downwards
	void FixedUpdate () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.down * moveSpeed;
	}
	// Increases speed of enemy
	public void IncreaseSpeed(){
		if(moveSpeed < 15.0f)
			moveSpeed += increaseSpeed;
	}
    public void DecreaseSpeed()
    {
        if (moveSpeed > 3.0f)
            moveSpeed -= 10*increaseSpeed;
    }
}
