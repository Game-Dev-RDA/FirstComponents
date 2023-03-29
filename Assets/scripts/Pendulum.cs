// This script handles the behavior of a pendulum object in a 3D environment.

using UnityEngine;

public class Pendulum : MonoBehaviour
{
// Public variables that can be adjusted in the Inspector.
[SerializeField] private float swingForce = 5f; // The force applied to the pendulum to create the swinging motion.
[SerializeField] private float swingRate = 1f; // The speed at which the pendulum swings back and forth.
[SerializeField] private int swingFrequency = 2; // The frequency of the pendulum's swinging motion.
[SerializeField] private Vector3 swingAxis = Vector3.right; // The axis around which the pendulum swings.
[SerializeField] private float swingLimit = 15f; // The maximum distance the pendulum can swing from its starting position.

// Private variables for tracking the pendulum's movement.
private float swingSpeed;       // The current speed at which the pendulum is swinging.
private float swingTime;        // The current time in the pendulum's swinging motion.
private Vector3 startPos;       // The starting position of the pendulum.

// Start is called before the first frame update.
private void Start()
{
    // Record the starting position of the pendulum.
    startPos = transform.position;
}

// Update is called once per frame.
private void Update()
{
    // Calculate the time since the last frame.
    float delTime = Time.deltaTime;
    // Update the swing time.
    swingTime += delTime;

    // Check if the pendulum is moving towards the center.
    float distanceFromCenter = Vector3.Distance(startPos, transform.position);
    bool movingTowardsCenter = distanceFromCenter > 0f && Mathf.Sign(transform.position.x) != Mathf.Sign(startPos.x);

    // Check if the pendulum is moving away from the swing limit.
    bool movingAwayFromLimit = Mathf.Abs(transform.position.x) >= swingLimit;

    if (movingTowardsCenter)
    {
        // If the pendulum is moving towards the center, slow down the swing speed.
        swingSpeed = Mathf.Lerp(swingSpeed, Mathf.Sign(-transform.position.x) * Mathf.Abs((swingRate * delTime) - swingSpeed), delTime);
    }
    else if (movingAwayFromLimit)
    {
        // If the pendulum is moving away from the swing limit, slow down the swing speed.
        swingSpeed = Mathf.Lerp(swingSpeed, Mathf.Sign(transform.position.x) * Mathf.Abs((swingRate * delTime) - swingSpeed), delTime);
    }
    else
    {
        // If the pendulum is not moving towards the center or away from the limit, calculate its new swing speed.
        float location = swingForce * Mathf.Sin(swingFrequency * swingTime);
        swingSpeed = Mathf.Lerp(swingSpeed, Mathf.Sign(location) * Mathf.Abs(swingRate - swingSpeed), delTime);
    }

    // Calculate the new position of the pendulum.
    Vector3 new_position = startPos + (swingAxis * swingForce * Mathf.Sin(swingFrequency * swingTime));
    new_position += swingAxis * swingSpeed * delTime;

    // Update the position of the pendulum.
    transform.position = new_position;
}
}