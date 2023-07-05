using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Play from a list of sounds using next, previous, and random
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PlaySoundsFromList : MonoBehaviour
{
    [Tooltip("Loop the currently playing sound")]
    public bool shouldLoop = false;
    private bool playing = false;

    [Tooltip("The list of audio clips to play from")]
    public List<AudioClip> audioClips = new List<AudioClip>();

    private AudioSource audioSource = null;
    private int index = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPause()
    {
        if(playing)
        {
            playing = false;
            PauseClip();
        }
        else
        {
            playing = true;
            PlayClip();
        }
    }
    public void NextClip()
    {
        index = ++index % audioClips.Count;
        PlayClip();
    }

    public void PreviousClip()
    {
        index = --index % audioClips.Count;
        PlayClip();
    }

    public void RandomClip()
    {
        index = Random.Range(0, audioClips.Count);
        PlayClip();
    }

    public void PlayAtIndex(int value)
    {
        index = Mathf.Clamp(value, 0, audioClips.Count);
        PlayClip();
    }

    public void PauseClip()
    {
        playing = false;
        audioSource.Pause();
    }

    public void StopClip()
    {
        playing = false;
        audioSource.Stop();
    }

    public void PlayCurrentClip()
    {
        playing = true;
        PlayClip();
    }

    private void PlayClip()
    {
        playing = true;
        audioSource.clip = audioClips[Mathf.Abs(index)];
        audioSource.Play();
    }

    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.loop = shouldLoop;
    }
}
