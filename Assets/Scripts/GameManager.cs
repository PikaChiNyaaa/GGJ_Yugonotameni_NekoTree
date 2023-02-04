using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void PlayGame()
    {
        isPlayingGame = true;
        // Loads Game Scene
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
