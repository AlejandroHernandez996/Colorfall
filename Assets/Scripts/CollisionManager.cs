using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour {

	public Sprite whiteSprite;
	public AudioClip matchSound;
    public GameObject panel;
	public GameObject gameManager;
    public Sprite rainbow;
    public Sprite slow;
    public bool isRainbow;
    public bool isSlow;
    void Start()
    {
        isRainbow = false;
        isSlow = false;
        panel.gameObject.SetActive(false);
    }
	void OnCollisionEnter2D(Collision2D coll){

        if (coll.gameObject.GetComponent<SpriteRenderer>().sprite == GetComponent<SpriteRenderer>().sprite && coll.gameObject.GetComponent<SpriteRenderer>().sprite != rainbow && coll.gameObject.GetComponent<SpriteRenderer>().sprite != slow) {
			// On collision set the enemy active off
			coll.gameObject.SetActive (false);
			//Play sound
			AudioSource.PlayClipAtPoint(matchSound, Vector3.zero);
			//Increase score
			gameManager.GetComponent<GameManager> ().IncreaseScore (1);

		}else if(coll.gameObject.GetComponent<SpriteRenderer>().sprite == rainbow)
        {
            // On collision set the enemy active off
            coll.gameObject.SetActive(false);
            //Play sound
            AudioSource.PlayClipAtPoint(matchSound, Vector3.zero);
            //Increase score
            gameManager.GetComponent<GameManager>().IncreaseScore(1);
            isRainbow = true;
        }
        else if (coll.gameObject.GetComponent<SpriteRenderer>().sprite == slow)
        {
            // On collision set the enemy active off
            coll.gameObject.SetActive(false);
            //Play sound
            AudioSource.PlayClipAtPoint(matchSound, Vector3.zero);
            //Increase score
            gameManager.GetComponent<GameManager>().IncreaseScore(1);
            isSlow = true;
        }
        else {

            // If lose then set the menu up
            panel.gameObject.SetActive(true);
			// Pause game
			Time.timeScale = 0;

		}
	}
}
