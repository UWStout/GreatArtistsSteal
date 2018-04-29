using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

	public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuClick");
        Time.timeScale = 1;
        
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuClick");
        Application.Quit();
    }


    public AudioMixer audioMixer;
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
