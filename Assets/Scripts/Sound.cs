using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Sound : MonoBehaviour
{
    public AudioClip m_sound;
	private AudioSource m_audio;

    void Start ()
	{
		m_audio = GetComponent<AudioSource>();
		m_audio.clip = m_sound;

        int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        
        if (musicPlay == 1) {
            m_audio.Play();
        } else if (musicPlay == 0) {
            m_audio.Stop();
        }

	}
}
