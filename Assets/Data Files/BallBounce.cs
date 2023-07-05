using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound; // Sound clip for ball collision

    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play the collision sound if a collision occurs
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
