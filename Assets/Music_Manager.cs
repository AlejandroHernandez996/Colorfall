using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour {

    public AudioClip matchSound;
    static bool AudioBegin = false;

    void Awake()
    {
            AudioSource.PlayClipAtPoint(matchSound, Vector3.zero);
            DontDestroyOnLoad(gameObject);
    }
   
}
