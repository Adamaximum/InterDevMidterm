using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code was borrowed from the Unity forums.
public class MusicControl : MonoBehaviour
{
    public AudioClip[] soundtrack;

    public AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();

        if (!source.playOnAwake)
        {
            source.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            source.Play();
            Debug.Log("Now Playing: " + source.clip.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            source.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            source.Play();
            Debug.Log("Now Playing: " + source.clip.name);
        }
    }
}
