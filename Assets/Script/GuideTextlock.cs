using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTextlock : MonoBehaviour
{
    public GameObject player;
    private Vector3 originalLocalScale;

    void Awake()
    {
        // Store the original local scale of the child object (usually 1, 1, 1)
        originalLocalScale = transform.localScale;
    }

    // LateUpdate runs after the parent's movement/flipping script has finished.
    void LateUpdate()
    {
        // 1. Check the Parent's X Scale

        float parentScaleX = player.transform.localScale.x;

        // 2. Check if the parent is flipped (i.e., its X scale is negative)
        if (parentScaleX < 0)
        {
            // The parent is flipped. We must flip the child back.
            // We multiply the original X scale by -1 (e.g., 1 * -1 = -1)
            Vector3 newScale = originalLocalScale;
            newScale.x *= -1f;

            transform.localScale = newScale;
        }
        else
        {
            // The parent is not flipped (X scale is positive). 
            // Ensure the child is set to its original, non-flipped scale (e.g., 1, 1, 1)
            transform.localScale = originalLocalScale;
        }
    }
}
