using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    /*Audio Manager:
     * Keeps track of all audio in the game
     * 
     * Referenced video tutorial: https://youtu.be/6OT43pvUyfY
     * Tutorial by: Brackeys
     * 
     * Updated by: PikaChiNyaaa
     * Date: 7 Nov 2022
     */

    private static AudioManager _singleton;
    public static AudioManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(AudioManager)} instance already exists, destroying duplicate!");
                Destroy(value.gameObject);
            }
        }
    }

    [SerializeField] private Sound[] soundList;

    private void Awake()
    {
        Singleton = this;

        // Initialize audio sources for all clips
        if (soundList.Length > 0)
        {
            for (int s = 0; s < soundList.Length; s++)
            {
                soundList[s].source = gameObject.AddComponent<AudioSource>();
                soundList[s].source.clip = soundList[s].clip;

                soundList[s].source.volume = soundList[s].volume;
                soundList[s].source.pitch = soundList[s].pitch;

                soundList[s].source.loop = soundList[s].loop;
            }
        }

        Play("MAIN_BGM");

        DontDestroyOnLoad(gameObject);
    }

    public void Play(string name)
    {
        bool foundSound = false;
        bool isBGM = name.Contains("BGM");

        for (int s = 0; s < soundList.Length; s++)
        {
            if (soundList[s].name == name)
            {
                foundSound = true;
                soundList[s].source.Play();
                if (!isBGM)
                    return;
            }
            else if (isBGM)
            {
                // If the new sound to play is a BGM, turn off all other BGMs AND AMBIENCE
                if (soundList[s].name.Contains("BGM") || soundList[s].name.Contains("AMBIENCE"))
                {
                    soundList[s].source.Stop();
                }
            }
        }

        if (!foundSound)
            Debug.Log("Sound " + name + " not found");
    }

    public void Stop(string name)
    {
        for (int s = 0; s < soundList.Length; s++)
        {
            if (soundList[s].name == name)
            {
                soundList[s].source.Stop();
                return;
            }
        }
        Debug.Log("Sound " + name + " not found");
    }

    public void ResetAudio()
    {
        foreach(Sound s in soundList)
        {
            // If the new sound to play is a BGM, turn off all other BGMs AND AMBIENCE
            if (s.name.Contains("_BGM") || s.name.Contains("AMBIENCE_"))
                s.source.Stop();
        }

        Play("MAIN_BGM");
    }

}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
