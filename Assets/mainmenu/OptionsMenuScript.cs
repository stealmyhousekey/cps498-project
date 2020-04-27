using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    // allows the music volume to be controlled
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
