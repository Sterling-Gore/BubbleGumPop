using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : SoundManager //MonoBehaviour
{

    
    /*[SerializeField] private AudioMixer Mixer;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private TextMeshProUGUI ValueText;
    [SerializeField] private AudioMixMode MixMode;
    */
    public void OnChangeSlider(float Value)
    {

        SoundManager.Instance.OnChangeSlider(Value);
        /*ValueText.SetText($"{Value.ToString("N4")}");

        switch(MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                SoundManager.Instance.OnChangeSlider(Value);
                break;
            case AudioMixMode.LinearMixerVolume:
                SoundManager.Instance.OnChangeSlider.Mixer.SetFloat
                Mixer.SetFloat("Volume", (-80 + Value * 80));
                break;
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;
        }*/
    }

    //PlayerPrefs.SetFloat("Volume", Value);
    //PlayerPrefs.Save();

    /*public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogrithmicMixerVolume

    }*/
}
