using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer _audioMixer;
    public float lastValueMusic = 0f;
    public float lastValueSFX = 0f;

    public void SetLevel(float sliderValue)
    {
        _audioMixer.SetFloat("VolumeOfMusic", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSFX(float sliderValueSFX)
    {
        _audioMixer.SetFloat("SFX", Mathf.Log10(sliderValueSFX) * 20);
    }

    public void OnOffMusic(bool isToggled)
    {
        if(isToggled)
        {
            _audioMixer.GetFloat("VolumeOfMusic", out lastValueMusic);
            _audioMixer.SetFloat("VolumeOfMusic", -80f);
        }
        else
        {
            _audioMixer.SetFloat("VolumeOfMusic", lastValueMusic);
        }
    }

    public void OnOffSFX(bool isToggled)
    {
        if (isToggled)
        {
            _audioMixer.GetFloat("SFX", out lastValueSFX);
            _audioMixer.SetFloat("SFX", -80f);
        }
        else
        {
            _audioMixer.SetFloat("SFX", lastValueSFX);
        }
    }
}
