using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioMixer Mixer;
    [SerializeField] public AudioSource AudioSource;
    [SerializeField] public AudioSource EffectsSource;
    [SerializeField] public TextMeshProUGUI ValueText;
    [SerializeField] public AudioMixMode MixMode;

	// Singleton instance.
	public static SoundManager Instance = null;

	// Initialize the singleton instance.
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

    // Play a single clip through the sound effects source.
	public void Play(AudioClip clip)
	{
		EffectsSource.clip = clip;
		EffectsSource.Play();
	}

    // Update Volume when Option Menu Volume slider is adjusted.
    public void OnChangeSlider(float Value)
    {
        ValueText.SetText($"{Value.ToString("N4")}");

        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = Value;
                break;
            case AudioMixMode.LinearMixerVolume:
                Mixer.SetFloat("Volume", (-80 + Value * 80));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;
        }
    }

    //PlayerPrefs.SetFloat("Volume", Value);
    //PlayerPrefs.Save();

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume

    }

	
}