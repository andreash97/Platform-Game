using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer music;
    public AudioMixer effect;
    

    public void SetMusicVolume (float Volume)
    {
        music.SetFloat("Volume", Volume);
    }
    public void SetEffectVolume(float Volume)
    {
        effect.SetFloat("Volume", Volume);
    }

}
