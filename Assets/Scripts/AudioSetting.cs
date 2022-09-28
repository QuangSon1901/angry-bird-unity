using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] private Sprite[] btnSprites;
    [SerializeField] private Image targetBtn;

    public AudioClip m_sound;
	private AudioSource m_audio;


    void Start ()
	{
		m_audio = GetComponent<AudioSource>();
		m_audio.clip = m_sound;

        int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        
        if (musicPlay == 1) {
            targetBtn.sprite = btnSprites[0];
            m_audio.Play();
        } else if (musicPlay == 0) {
            targetBtn.sprite = btnSprites[1];
            m_audio.Stop();
        }

	}

    public void ChangeMusic() {
        int musicPlay = PlayerPrefs.GetInt ("GameMusic");
        if (musicPlay == 1) {
            PlayerPrefs.SetInt ("GameMusic", 0);
            targetBtn.sprite = btnSprites[1];
            m_audio.Pause();
            return;
        } 
        else if (musicPlay == 0) {
            PlayerPrefs.SetInt ("GameMusic", 1);
            targetBtn.sprite = btnSprites[0];
            m_audio.Play();
            return;
        }
    }
}
