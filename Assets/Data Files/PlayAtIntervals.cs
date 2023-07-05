using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAtIntervals : MonoBehaviour
{
    public float interval = 5.0f;
    private float timer = 0.0f;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        interval += source.clip.length; // duration of audio
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval && !source.isPlaying)
        {
            source.Play();
            timer = 0.0f;
        }
    }
}
