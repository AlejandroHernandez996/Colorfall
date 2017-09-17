using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int maxEnemy;
	public Transform enemy;
	public float moveSpeed;
	public Text scoreText, highscoreText, menuScoreText;
    public Sprite yellowSprite, greenSprite, blueSprite, redSprite, whiteSprite, rainbowSprite, slowSprite;
	public float leftX;
	public float enemyXScale;
	public Rigidbody2D playerRb;
	private List<Sprite> spriteList = new List<Sprite> ();
	private int score,highscore;
	private List<Transform> enemyList = new List<Transform>();
	private List<float> grid = new List<float>();
	private List<int> activeEnemyList = new List<int> ();
	private bool isRespawn;
    public GameObject panel;


    // Use this for initialization
    void Start () {

        // Unpause game
        Time.timeScale = 1;
		//Starting level
		score = 0;
		// From -2.75 to 2.75 by increments of .25
		float gridNumber = leftX;
		// Sets the grid for the enemy blocks
		for (int x = 0; x < maxEnemy; x++) {
			grid.Add (gridNumber);
			gridNumber += -2*leftX/(maxEnemy-1);
		}
		// Adds sprites to list
		spriteList.Add (yellowSprite);
		spriteList.Add (blueSprite);
		spriteList.Add (redSprite);
		spriteList.Add (greenSprite);
		spriteList.Add (whiteSprite);
		InstantiateList ();
        highscoreText.text = "High: " + PlayerPrefs.GetInt("highscore").ToString();
        panel.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		// If out of bounds respawn
		if (CheckBounds ()) {
			Respawn ();
			Time.timeScale = 1;
		} 

	}
	// Instiantes list onto game scene
	void InstantiateList(){
		
		setActiveEnemyList ();

		// Instantiates all enemy blocks 
		for (int x = 0; x < maxEnemy; x++) {
			Transform enemyTemp = (Transform)Instantiate (enemy,new Vector2(grid[x],5.0f),Quaternion.identity);
			enemyTemp.localScale = new Vector3 (enemyXScale, 2.0f, 0.0f);
			// Add enemies to enemyList
			enemyList.Add (enemyTemp);

			//Set which ones will be active
			if (activeEnemyList.Contains (x))
				enemyList [x].gameObject.SetActive (true);
			else
				enemyList [x].gameObject.SetActive (false);

			// Sets the color of the enemies
			enemyList [x].gameObject.GetComponent<SpriteRenderer> ().sprite = spriteList [Random.Range (0, spriteList.Count)];
	}
		// Sets one of the enemies to the same color as the player
		playerRb.gameObject.GetComponent<SpriteRenderer> ().sprite = enemyList [Random.Range (0, maxEnemy)].gameObject.GetComponent<SpriteRenderer> ().sprite;
	}
	// Sets active enemies
	void setActiveEnemyList(){
			
		// Gives a number 0-22
		int tempInt = Random.Range (0, maxEnemy);
		for (int x = 0; x < maxEnemy; x++) {
			// If tempInt is in activeEnemyList try another number
			while (activeEnemyList.Contains (tempInt)) {
				tempInt = Random.Range (0, maxEnemy);
			}

			//Add number to the list
			activeEnemyList.Add (tempInt);
		}
	}
	bool CheckBounds(){
		bool isOut = false;
		for (int x = 0; x < activeEnemyList.Count; x++) {
			//If any of the enemies are out of bounds set isOut true
			if (enemyList [activeEnemyList [x]].position.y < -5.0f) {
				isOut = true;
				//Clearlist to make a new list
				activeEnemyList.Clear ();
				break;
			}
		}

		return isOut;
	}
	//Sets the enemies back at the top
	void Respawn(){
		setActiveEnemyList ();
		//Sets all enemies not active and puts them at the top
		for (int x = 0; x < maxEnemy; x++) {
			//Set all of them inactive to symch them
			enemyList [x].gameObject.SetActive (false);
			// Set them at their original position
			enemyList [x].position = new Vector2 (grid [x], 5.0f);
			// Set the colors of the enemies
			enemyList [x].gameObject.GetComponent<SpriteRenderer> ().sprite = spriteList [Random.Range (0, spriteList.Count)];
            // Increase the speed of enemy after every spawn
            if (!playerRb.gameObject.GetComponent<CollisionManager>().isSlow)
            {
                enemyList[x].gameObject.GetComponent<Enemy_Movement>().IncreaseSpeed();
            }
            else
            {
                enemyList[x].gameObject.GetComponent<Enemy_Movement>().DecreaseSpeed();
            }
           

        }
        Debug.Log(enemyList[0].gameObject.GetComponent<Enemy_Movement>().moveSpeed);
        // Activates all "active" enemies
        for (int x = 0; x < maxEnemy; x++) {
			if (activeEnemyList.Contains (x)) {
				enemyList [x].gameObject.SetActive (true);

			}

		}
		// Set color of at least one enemy to player
		playerRb.gameObject.GetComponent<SpriteRenderer> ().sprite = enemyList [Random.Range (0, maxEnemy)].gameObject.GetComponent<SpriteRenderer> ().sprite;
        if(Random.Range(0,10) == 1)
        {
            enemyList[Random.Range(0, maxEnemy)].gameObject.GetComponent<SpriteRenderer>().sprite = rainbowSprite;
        } else if(Random.Range(0,10) == 1)
        {
            enemyList[Random.Range(0, maxEnemy)].gameObject.GetComponent<SpriteRenderer>().sprite = slowSprite;
        }
        // If current score is higher than highscore set highscore to score
        if (score > PlayerPrefs.GetInt ("highscore")) {
			PlayerPrefs.SetInt ("highscore", score);
		}
		// Set game text
		scoreText.text = score.ToString ();
		highscoreText.text = "Best: " + PlayerPrefs.GetInt("highscore").ToString ();
        // Rainbow Effect
        if (playerRb.gameObject.GetComponent<CollisionManager>().isRainbow)
        {
           for(int x = 0; x < maxEnemy; x++) {
                if (activeEnemyList.Contains(x))
                {
                    enemyList[x].gameObject.GetComponent<SpriteRenderer>().sprite = playerRb.gameObject.GetComponent<SpriteRenderer>().sprite;

                }

            }
            playerRb.gameObject.GetComponent<CollisionManager>().isRainbow = false;
        }
        // Slow Effect
        if (playerRb.gameObject.GetComponent<CollisionManager>().isSlow)
        {
            playerRb.gameObject.GetComponent<CollisionManager>().isSlow = false;
        }
    }
	// increases score
	public void IncreaseScore(int s){
		score += s;
	}
}
