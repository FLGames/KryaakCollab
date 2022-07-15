using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioaleatorio : MonoBehaviour
{
    public AudioClip[] sounds;

    void OnTriggerStay()
    {
        AudioRandom();
    }

    void AudioRandom()
    {
        if (GetComponent<AudioSource>().isPlaying) return;
        GetComponent<AudioSource>().clip = sounds[Random.Range(0, sounds.Length)];
        GetComponent<AudioSource>().Play();
    }
}
