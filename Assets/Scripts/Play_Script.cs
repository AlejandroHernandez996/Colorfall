using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play_Script : MonoBehaviour {

	public string scene;
	// Use this for initialization
	void Start () {
		// When button clicked go to TaskOnClick
		GetComponent<Button> ().onClick.AddListener (TaskOnClick);
	}
	void TaskOnClick(){
		// Load scene
		SceneManager.LoadScene (scene);
	}

}
