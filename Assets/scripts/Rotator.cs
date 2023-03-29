using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

     public float rotationSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update the rotation
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
