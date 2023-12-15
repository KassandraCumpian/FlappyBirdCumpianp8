using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public static SoundManager instance;

    public void Awake ()
    {
        audioSource = GetComponent<AudioSource> ();
        if (instance == null )
        {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else
        {
            Destroy (gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot (clip);
    }
}
