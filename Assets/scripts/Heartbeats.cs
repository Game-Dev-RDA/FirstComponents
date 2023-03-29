using UnityEngine;

public class Heartbeats : MonoBehaviour
{
    public float minScale = 1f; // The minimum scale of the object.
    public float maxScale = 1.5f; // The maximum scale of the object.
    public float heartbeatSpeed = 2f; // The speed at which the object will increase/decrease in size.
    private float targetScale; // The target scale that the object is currently moving towards.

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the target scale to the minimum scale.
        targetScale = minScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Use Lerp to smoothly transition the object's scale from its current scale to the target scale.
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime * heartbeatSpeed);

        // If the object has reached its target scale, switch to the other scale.
        if (Mathf.Approximately(transform.localScale.x, targetScale))
        {
            targetScale = targetScale == minScale ? maxScale : minScale;
        }
    }
}
