using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Make GameManager a Singleton
    public static GameManager Instance { get; private set; }
    public static bool isPlayingGame { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it is not this instance, delete this
        // Deletes new instances aside from initial

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
