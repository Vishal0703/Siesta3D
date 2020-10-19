using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlaySound()
    {
        AudioSource[] audios = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource aud in audios)
            aud.Stop();

        AudioSource _audio = GetComponent<AudioSource>();
        _audio.Play();   
    }
}
