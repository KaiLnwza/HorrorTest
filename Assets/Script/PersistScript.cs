using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static PersistScript Instance;

    void Awake()
    {
        // 1. Check if an instance already exists
        if (Instance == null)
        {
            // This is the first instance, make it the official instance
            Instance = this;

            // 2. CRITICAL STEP: Prevent this GameObject from being destroyed 
            // when a new scene is loaded
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // An instance already exists, so destroy this new duplicate object
            // This ensures only one GameManager (or Player) exists across scenes
            Destroy(gameObject);
        }
    }
}
