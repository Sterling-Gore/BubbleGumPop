using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad (gameObject);
    }

    private void Start()
    {
        // Set initial volume levels
        UpdateMusicVolume();
        UpdateSFXVolume();
    }

    /// <summary>
    /// Plays a music clip.
    /// </summary>
    /// <param name="clip">The AudioClip to play as music.</param>
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return; // Prevent restarting the same clip

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    /// <summary>
    /// Plays a sound effect.
    /// </summary>
    /// <param name="clip">The AudioClip to play as a sound effect.</param>
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    /// <summary>
    /// Updates the music volume.
    /// </summary>
    public void UpdateMusicVolume()
    {
        musicSource.volume = musicVolume;
    }

    /// <summary>
    /// Updates the SFX volume.
    /// </summary>
    public void UpdateSFXVolume()
    {
        sfxSource.volume = sfxVolume;
    }

    /// <summary>
    /// Sets the music volume dynamically.
    /// </summary>
    /// <param name="volume">The new music volume (0 to 1).</param>
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        UpdateMusicVolume();
    }

    /// <summary>
    /// Sets the SFX volume dynamically.
    /// </summary>
    /// <param name="volume">The new SFX volume (0 to 1).</param>
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        UpdateSFXVolume();
    }
}
