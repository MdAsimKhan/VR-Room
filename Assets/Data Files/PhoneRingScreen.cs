using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneRingScreen : MonoBehaviour
{
    private AudioSource audioSource;
    private Material original_material;
    // private Renderer renderer;
    public Material calling_material;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        original_material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if(audioSource.isPlaying)
        {
            GetComponent<Renderer>().material = calling_material;
        }
        else
        {
            GetComponent<Renderer>().material = original_material;
        }
    }
}
