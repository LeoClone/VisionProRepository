using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSingleton : MonoBehaviour
{
    public static FollowSingleton Instance { get; private set; }

    public Vector3 finalPosition = Vector3.zero;

    public bool hasFollowed = false;


    private void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            // If no, this instance becomes the Singleton instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            // If an instance already exists and it's not this:
            // Destroy this instance, enforce singleton pattern
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
