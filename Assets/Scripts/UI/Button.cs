using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private AudioSource buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        buttonClick = GameObject.Find("ClickButton").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void HandleClickOnMusic()
    {
        int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        
        if (musicPlay == 1) {
        buttonClick.Play();
        }
    }
}
