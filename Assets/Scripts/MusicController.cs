using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioClip[] musicClips;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.clip = musicClips[Random.Range(0, musicClips.Length - 1)];
        audioSource.Play();
    }

    private void Update()
    {
        if (audioSource.clip != null)
        {
            if (audioSource.time >= audioSource.clip.length)
            {
                audioSource.clip = musicClips[Random.Range(0, musicClips.Length - 1)];
                audioSource.Play();
            }
        }

        audioSource.pitch = 1 + Time.timeScale / 10;
    }
}