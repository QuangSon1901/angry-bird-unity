using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject[] enemies;

    public AudioClip mWin;
	private AudioSource mAudio;

    void Update()
    {
        mAudio  = GetComponent<AudioSource>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
        if (enemies.Length == 0)
        {
            int musicPlay = PlayerPrefs.GetInt ("GameMusic");
            if (musicPlay == 1) {
                mAudio.clip = mWin;
                mAudio.Play();
            }  
            enabled = false;
        }
    }
}
