using UnityEngine;

public class RotateCover : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the speed of rotation
    public float targetAngle = 250f; // Adjust the target angle for rotation

    private bool isRotating = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0f, 0f, targetAngle);
    }

    private void Update()
    {
        if (isRotating)
        {
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the target rotation is reached
            if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.01f)
            {
                // Rotation complete
                isRotating = false;
            }
        }
    }

    public void StartRotation()
    {
        // Start the rotation
        isRotating = true;
    }
}