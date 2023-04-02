using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Click;
    public AudioClip startWave;
    public AudioClip dead;
    public AudioClip victory;

    private void Awake()
    {
        audioSource= GetComponent<AudioSource>();
        
    }
    public void ClickSound()
    {
        audioSource.clip = Click;
        audioSource.Play();
    } 
    public void StartWaveSound()
    {
        audioSource.clip = startWave;
        audioSource.Play();
    }

    public void DeadSound()
    {
        audioSource.clip = dead;
        audioSource.Play();
    }
    public void VictorySound()
    {
        audioSource.clip = victory;
        audioSource.Play();
    }

    public void Builded(AudioClip clip)
    {

        audioSource.clip = clip;
        audioSource.PlayDelayed(5f);
    }
}
