using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SoundManager : MonoBehaviour
{
    public static _SoundManager singleton { get; private set; }

    public AudioSource audioSource;
    public List<AudioClip> sounds = new List<AudioClip>();

    private void Awake()
    {
        singleton = this;
    }

    public void PlaySound(int soundNumber)
    {
        audioSource.clip = sounds[soundNumber];
        audioSource.Play();
    }
}
