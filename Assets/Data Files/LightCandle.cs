using UnityEngine;

public class LightCandle : MonoBehaviour
{
    public ParticleSystem flames;
    private Rigidbody rigidbody;
    public float velocityThreshold = 0.5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(rigidbody.velocity.magnitude >= velocityThreshold)
        {
            flames.Stop();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            flames.Play();
        }
    }
}
