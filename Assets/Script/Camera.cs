using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmoothCameraFollow2D : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    private readonly Vector3 offset = new Vector3(0f, 0f, -10f);
    public GameObject player;

    // Define the boundaries where the camera must stop
    [Header("Boundary Limits")]
    public float minX = -6f; // Leftmost camera position
    public float maxX = 0f;  // Rightmost camera position
    public float minY = -5f;  // Bottommost camera position
    public float maxY = 5f;   // Topmost camera position

    void LateUpdate()
    {
        if (NewBehaviourScript.Entrace == true)
        {
            minX = -131f;
            maxX = -97f;
            minY = -5f;
            maxY = 5;
        }
        else if (NewBehaviourScript.Temple == true)
        {
            minX = -74f;
            maxX = -34f;
            minY = -5;
            maxY = 5;
        }
        else if (NewBehaviourScript.Village == true)
        {
            minX = -9f;
            maxX = 21f;
            minY =-5;
            maxY =5;
        }
        else if (NewBehaviourScript.House == true)
        {
            minX = 35f;
            maxX = 65f;
            minY = -5;
            maxY = 5;
        }
        else if (NewBehaviourScript.Village_2 == true)
        {
            minX = 77f;
            maxX = 114f;
            minY = -5;
            maxY = 5;
        }

        else if (NewBehaviourScript.Grave == true)
        {
            minX = 125f;
            maxX = 178f;
            minY = -5;
            maxY = 5;
        }
        else if (NewBehaviourScript.Final == true)
        {
            minX = 197;
            maxX = 252;
            minY = -5;
            maxY = 5;
        }



        if (target == null) return;

        // 1. Calculate the raw desired position based on the player
        Vector3 desiredPosition = target.position + offset;

        // 2. Clamp the desired position to the defined boundaries
        float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // Create a new clamped position with the fixed Z offset
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, offset.z);

        // 3. Smoothly move the camera to the clamped position
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            clampedPosition, // Use the clamped position here!
            smoothSpeed * Time.deltaTime
        );

        // 4. Apply the final smoothed position
        transform.position = smoothedPosition;
    }
}