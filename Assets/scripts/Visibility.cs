using UnityEngine;

public class Visibility : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the MeshRenderer component attached to this object.
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the left mouse button has been clicked.
        if (Input.GetMouseButtonDown(0))
        {
            // Toggle the visibility of the object.
            meshRenderer.enabled = !meshRenderer.enabled;
        }
    }
}
